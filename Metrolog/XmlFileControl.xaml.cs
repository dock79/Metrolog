using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;


namespace Metrolog
{
    public class ChangeResultEventArgs
    {
        recInfo _res;
        int _index;

        public recInfo Result
        {
            get { return _res; }
        }

        public int Index
        {
            get { return _index; }
        }

        public ChangeResultEventArgs(recInfo res, int index)
        {
            _res = res;
            _index = index;
        }
    }

    /// <summary>
    /// Interaction logic for NewXmlFileControl.xaml
    /// </summary>
    public partial class XmlFileControl : UserControl, INotifyPropertyChanged
    {
        private recInfo _currentresult;
        private int _currentIndex;

        public XmlFileControl()
        {
            InitializeComponent();
            RecordsTabControl.SelectionChanged += RecordsTabControlSelectionChanged;
            _currentIndex = -1;
            //ChangeCurrentResult(0);
            CreateEmptyresultList(); //resultList = new List<recInfo>();
            //resultList.Add(new recInfo());
            XmlFileButton.DataContext = this;
            DeleteRecordButton.DataContext = this;
            SaveXmlButton.DataContext = this;
            ViewXmlFileButton.DataContext = this;
            
            IsValidate = App.ApplicationSettings.IsValidate;
            IsValidateToSchema = App.ApplicationSettings.IsValidateToSchema;
            SchemaFile = App.ApplicationSettings.SchemaFile;
            XmlViewerType = App.ApplicationSettings.XmlViewer;
            
            ChangeFlag = false;
            
            App.ApplicationSettings.PropertyChanged += ApplicationSettingsOnPropertyChanged;
        }

        private void ApplicationSettingsOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ApplicationSettings applicationSettings = sender as ApplicationSettings;
            if (applicationSettings != null)
            {
                switch (e.PropertyName)
                {
                    case "IsValidate":
                        IsValidate = applicationSettings.IsValidate;
                        if (Currentresult != null)
                        {
                            Currentresult.IsValidate = IsValidate;
                        }
                        break;
                    case "IsValidateToSchema":
                        IsValidateToSchema = applicationSettings.IsValidateToSchema;
                        break;
                    case "SchemaFile":
                        SchemaFile = applicationSettings.SchemaFile;
                        break;
                    case "XmlViewer":
                        XmlViewerType = applicationSettings.XmlViewer;
                        break;
                    default:
                        break;
                }
            }
        }

        
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        

       

        public List<recInfo> resultList { get; set; }

       
        public delegate void ChangeResultHandler(object sender, ChangeResultEventArgs e);
        public event ChangeResultHandler ChangeResult;
        
        public recInfo Currentresult
        {
            get { return this._currentresult; }
            set { this._currentresult = value; }
        }

        /// <summary>
        /// Имя файла в который сохраняются данные поверки СИ
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Имя файла, который содержит данные для отправки на сайт поверки
        /// </summary>
        public string XmlFileName { get; set; }

        public bool ChangeFlag { get; set; }
        
        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                _currentIndex = value;
                OnPropertyChanged();
            }
        }

        public event RoutedEventHandler ReturnToMainViewClick;

        #region Event

        public static readonly RoutedEvent CurrentResultChangeEvent;

        // обертка над событием
        public event RoutedEventHandler CurrentResultChange
        {
            add
            {
                // добавление обработчика
                base.AddHandler(XmlFileControl.CurrentResultChangeEvent, value);
            }
            remove
            {
                // удаление обработчика
                base.RemoveHandler(XmlFileControl.CurrentResultChangeEvent, value);
            }
        }

        /// <summary>
        /// Нужно ли проводить проверку файла на соответсвие схеме
        /// </summary>
        public bool IsValidateToSchema { get; set; }

        public bool IsValidate { get; set; }

        public XmlViewer XmlViewerType  { get; set; }

        public string SchemaFile { get; set; }
        
        static XmlFileControl()
        {
            // регистрация маршрутизированного события
            CurrentResultChangeEvent = EventManager.RegisterRoutedEvent("CurrentResultChange", RoutingStrategy.Direct,
                typeof(RoutedEventHandler), typeof(XmlFileControl));
        }

        #endregion

       

        void ChangeCurrentResult(int index, bool setStartIndex = false)
        {
            //if (_currentIndex == index) return;
            if ((resultList.Count == 0) || (index < 0))
            {
                _currentIndex = -1;
                CurrentIndex = -1;

                RecordsTabControl.IsEnabled = false;
                RecordsTabControl.Visibility = Visibility.Hidden;
                return;
            }

            _currentIndex = index;
            CurrentIndex = index;
            Currentresult = resultList[_currentIndex];
            
            tabItemControl1.result = Currentresult;
            tabItemControl2.result = Currentresult;
            tabItemControl3.result = Currentresult;
            tabItemControl4.result = Currentresult;
            
            comboBox1.IsEnabled = true;
            comboBox1.SelectedIndex = _currentIndex;
            
            RecordsTabControl.Visibility = Visibility.Visible;
            RecordsTabControl.IsEnabled = true;

            if (setStartIndex) RecordsTabControl.SelectedIndex = 0;
            //Currentresult.miInfo.etaMI.primaryRec.IsValidate=true;
            //Currentresult.miInfo.etaMI.primaryRec.Validate();
            RoutedEventArgs newEventArgs = new RoutedEventArgs(XmlFileControl.CurrentResultChangeEvent, this);
            RaiseEvent(newEventArgs);
        }

        void RecordsTabControlSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                //if (tabControl1.SelectedIndex == 0) Currentresult.miInfo.etaMI.primaryRec.Validate();
            }
        }

        void XmlFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (resultList.Count > 0)
            {
                CreateXmlFile();
                //SaveresultList();
            }
        }

        /// <summary>
        /// Формирует xml файл для отправки на портал метрологии
        /// </summary>
        private void CreateXmlFile()
        {
            XmlDocument xmlDoc = CreateBlankXml();
            //IsValidateToSchema = true;
            if (IsValidateToSchema)
            {
                bool validzateResult = ValidateXmlToSchema(xmlDoc, SchemaFile);
                if (!validzateResult)
                {
                    MessageBoxResult res = MessageBox.Show("При проверке на соответствие схеме возникли ошибки и предупреждения. Сформировать файл?",
                        "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (res == MessageBoxResult.No) return;
                }
            }
            
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Документы xml (.xml)|*.xml|Все файлы (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                // string filePath = dlg.FileName;// @"a344444.xml";
                XmlFileName = dlg.FileName;
                //сохраняем в документ
                //xmlDoc.Save(filePath);
            }
            else
                return;

            xmlDoc.Save(XmlFileName);
        }

        #region ValidationRegion

        private bool ValidateXmlToSchema(XmlDocument xmlDoc, string schemaFile)
        {
            var result = ValidatorXmlSchema.ValidateAndGetCommonText(xmlDoc, schemaFile);
            File.WriteAllText("ErrorsAndWarnings.txt", result.errorsAndWarningsText);

            /*using (TextWriter tw = new StreamWriter("ErrorsAndWarnings.txt"))
            {
                tw.Write(result.errorsAndWarningsText);
                tw.Close();
            }*/

            if (result.errors || result.warnings) return false;
            return true;
        }

        #endregion

        private void CreateEmptyresultList()
        {
            resultList = new List<recInfo>();
            //Установка элементов в состояние по умолчанию
            comboBox1.Items.Clear();
            comboBox1.IsEnabled = false;

            RecordsTabControl.IsEnabled = false;
            RecordsTabControl.Visibility = Visibility.Hidden;
            FileName = null;
            XmlFileName = null;
        }

      
        private void CreateNewResult()
        {
            recInfo newresult = new recInfo();
            newresult.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "IsValidate") return;
                ChangeFlag = true;
            };
            newresult.IsValidate = IsValidate;
            resultList.Add(newresult);
            ChangeFlag = true;
            //_currentIndex =	resultList.IndexOf(newresult);
            //Currentresult = newresult;	
            
            //ChangeCurrentResult(resultList.Count-1, true);			
        }

        /// <summary>
        /// Сохраняет файл метрологичекиой поверки в формате xml
        /// </summary>
        internal void SaveresultList()
        {
            List<recInfo> resList = new List<recInfo>();
            //MessageBox.Show(resultList.Count.ToString());
            //for (int i=0; i<resultList.Count; i++) resList.Add(CreateResultCopy(resultList[i]));

            foreach (recInfo ri in resultList)
            {
                resList.Add(ResultXml.CreateResultCopy(ri));
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<recInfo>));

            //FileName = "resultList.mtr";
            if (FileName == null)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Результаты поверки"; // Default file name
                dlg.DefaultExt = ".mtr"; // Default file extension
                dlg.Filter = "Документы Metrolog (.mtr)|*.mtr;"; //|Все файлы (*.*)|*.*"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    FileName = dlg.FileName;
                }
            }

            if (FileName != null)
            {
                using (TextWriter tw = new StreamWriter(FileName))
                {
                    formatter.Serialize(tw, resList);
                    tw.Close();
                }

                ChangeFlag = false;
            }
        }

        private List<recInfo> LoadresultList(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<recInfo>));

            // Declare an object variable of the type to be deserialized.
            List<recInfo> res;
            if (!File.Exists(path))
            {
                return null;
                List<recInfo> newList = new List<recInfo>();
                newList.Add(new recInfo());
                return newList;
            }

            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                res = (List<recInfo>) serializer.Deserialize(reader);
                reader.Close();
            }

            foreach (recInfo ri in res)
            {
                ri.PostCreateLogic();
                ri.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "IsValidate") return;
                    ChangeFlag = true;
                };
            }

            return res;
        }

        public void LoadFile(string path)
        {
            resultList = LoadresultList(path); //new List<recInfo>();					
          
            comboBox1.Items.Clear();
            for (int i = 0; i < resultList.Count; i++)
            {
                comboBox1.Items.Add("Запись " + (i+1).ToString());
            }


            RecordsTabControl.SelectedIndex = 0;
            FileName = path;
            XmlFileName = null;
            //Изменяем иекущий result и вызываем события
            //_currentIndex=0;
            //Currentresult = resultList[0];			
            //ChangeResult += XmlFileControl_ChangeResult;
            //if (ChangeResult != null) ChangeResult(this, new ChangeResultEventArgs(Currentresult,0));

            ChangeCurrentResult(0);
            //splitButton1.Content = "Запись " + (resultList.IndexOf(Currentresult)+1);
            //tabItemControl1.result = Currentresult;
        }
        
        void SaveXmlButton_OnClick(object sender, RoutedEventArgs e)
        {
            /*SettingsWindow sw = new SettingsWindow();
            sw.Owner = App.Current.MainWindow;
            sw.ShowDialog();			
            */
            SaveresultList();
        }
      

        void NewRecordButton_OnClick(object sender, RoutedEventArgs e)
        {
            CreateNewResult();
            ChangeCurrentResult(resultList.Count - 1, true);
            comboBox1.Items.Add("Запись " + resultList.Count.ToString());
            comboBox1.SelectedIndex = _currentIndex;
        }

        public void CreateNewFile()
        {
            CreateEmptyresultList();
            CreateNewResult();
            ChangeCurrentResult(resultList.Count - 1, true);
            comboBox1.Items.Add("Запись " + resultList.Count.ToString());
            comboBox1.SelectedIndex = _currentIndex;
        }

        void BackToMainWindowButton_OnClick(object sender, RoutedEventArgs e)
        {
            //CheckChanges();

            /*bool isChange = false;
            foreach (recInfo ri in resultList)
            {
                if (ri.ChangeFlag)
                {
                    isChange = true;
                    break;
                }
            }*/
            //MessageBox.Show(ChangeFlag.ToString());

            if ((ChangeFlag) && (resultList.Count > 0))
            {
                MessageBoxResult res = MessageBox.Show("Сохранить файл результатов поверки?", "Metrolog",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                if (res == MessageBoxResult.Cancel) return;

                if (res == MessageBoxResult.Yes) SaveresultList();
            }

            ChangeFlag = false;

            //Передать это событие наверх родителю
            if (this.ReturnToMainViewClick != null) this.ReturnToMainViewClick(this, e);
        }

        private void DeleteResult(int index)
        {
            if (index < 0) return;

            /*if (resultList.Count == 1)
            {
                MessageBox.Show("Невозможно удалить последнюю запись", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            */
            resultList.RemoveAt(index);
            //_currentresult = resultList.IndexOf(_currentIndex);
           ChangeFlag = true;

            /////////Комбо бокс. Удаляем запись и переименовываем последующие (т.е. "Запись 3" становится "Запись 2") 
            for (int i = index + 1; i < comboBox1.Items.Count; i++)
            {
                object item1 = comboBox1.Items[i] as object;
                comboBox1.Items[i] = "Запись " + i.ToString();
            }

            //comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            comboBox1.Items.RemoveAt(index);
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.Refresh();
            ChangeCurrentResult(0, true);
        }

        void DeleteRecordButton_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteResult(_currentIndex);
            /*comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.Refresh();
            ChangeCurrentResult(0, true);*/
        }

        private void ComboBox1_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selIndex = (sender as ComboBox).SelectedIndex;
            ChangeCurrentResult(selIndex, true);
        }

        private void ViewXmlFileButton_OnClick(object sender, RoutedEventArgs e)
        {
           XmlDocument document = CreateBlankXml();
           XmlFileViewerUserControl1.XmlViewerType = XmlViewerType;
           XmlFileViewerUserControl1.LoadXmlToView(document);
           XmlFilePopup.IsOpen = true;
           //popupXmlFile.PlacementTarget = ButtonXmlFile;
           //popupXmlFile.StaysOpen = true;
        }
        
        private XmlDocument CreateBlankXml()
        {
            //создание главного объекта документа
            XmlDocument document = new XmlDocument();
            /*<?xml version="1.0" encoding="utf-8" ?> */
            //создание объявления (декларации) документа
            XmlDeclaration XmlDec = document.CreateXmlDeclaration("1.0", "utf-8", null);
            document.AppendChild(XmlDec);

            //комментарий уровня root
            XmlComment Comment0 = document.CreateComment(
                "Пример для публикации Организация: условный шифр ЭЭЭ содержит записи: 1.СИ, применяемом в качестве эталона(Тип СИ), поверка по Методике поверки, периодическая поверка. Средство поверки: Стандартные образцы, применяемые при поверке.");
            //добавляем в документ
            document.AppendChild(Comment0);

            //создание корневого элемента application с атрибутом xmlns="urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19"
            XmlElement applicationElement = document.CreateElement("application");
            //создание атрибута. Насчет даты спросить у Сашы
            applicationElement.SetAttribute("xmlns",
                "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19");
            //applicationElement.Attributes.Append(new XmlAttribute(("xmlns", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19"));
            //добавляем в документ
            document.AppendChild(applicationElement);

            ResultXml resultxml = new ResultXml();
            foreach (recInfo ri in resultList)
            {
                resultxml.result = ri;
                applicationElement.AppendChild(resultxml.CreateResult(document));
            }

            return document;
        }

    }
}