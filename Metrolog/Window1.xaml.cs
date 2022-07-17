using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Configuration;

namespace Metrolog
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	
	public enum ViewType
	{
		MainView,
		NewFile,
		EditFile,
		ShowFile
	}
	
	public enum XmlViewer
	{
		Browser = 0,
		TreeView = 1
	}

	public enum ColorTheme
	{
		Light = 0,
		Dark = 1
	}

	public partial class Window1 : Window, INotifyPropertyChanged
	{
		public ViewType ViewType
		{
			get;
			set;
		}
		
		private MainViewControl _mainViewControl;		
		private XmlFileControl _xmlFileControl;
		private XmlFileViewer _xmlFileViewer;
		private ContentControl _currentContent;
		
		public ContentControl CurrentContent
		{
			get
			{
	            return this._currentContent;
       		}
        	set 
        	{
    			if (value == this._currentContent) return;
				this._currentContent = value;
				OnPropertyChanged();
        	}
		}
		
		#region
		public event PropertyChangedEventHandler PropertyChanged;
	
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		
		public Window1()
		{
			InitializeComponent();
			
			_mainViewControl = new MainViewControl();		
			_xmlFileControl = new XmlFileControl();
			_xmlFileViewer = new XmlFileViewer();
			_currentContent = new ContentControl();
			
			
			ViewType = ViewType.MainView;
			//mainViewControl = new MainViewControl();
			_mainViewControl.NewXmlFileClick += mainViewControl_NewXmlFileClick;
			_mainViewControl.LoadXmlFileClick += mainViewControl_EditXmlFileClick;
			_mainViewControl.ShowXmlFileClick += mainViewControl_ShowXmlFileClick;
			
			_xmlFileControl.ReturnToMainViewClick += _newXmlFileControl_ReturnToMainViewClick;
			_xmlFileViewer.ReturnToMainViewClick += XmlFileViewerOnReturnToMainViewClick;
			CurrentContent = _mainViewControl; // _xmlFileControl;
			contentControl.DataContext = this;
			
			//contentControl.Content = new MainViewControl();

		}

		private void LoadAndSetSettings()
		{
			/*bool value1 = Convert.ToBoolean(ApplicationSettings.GetKey("ValidateToSchema"));
			_xmlFileControl.IsValidateToSchema = value1;
			bool value2 = Convert.ToBoolean(ApplicationSettings.GetKey("HighLightFields"));
			_xmlFileControl.IsValidate = value2;
			*/
			
		}
		
		
		private void XmlFileViewerOnReturnToMainViewClick(object sender, RoutedEventArgs e)
		{
			CurrentContent = _mainViewControl;
		}

		void mainViewControl_NewXmlFileClick(object sender, RoutedEventArgs e)
		{
			
			//MessageBox.Show(("lll"));
			//if (!ChangeFlag) _XmlFileControl.CreateNewResult();
			//ChangeFlag = true;
			//_XmlFileControl.CreateEmptyresultList();
			//_XmlFileControl.CreateNewResult();
			_xmlFileControl.CreateNewFile();
			CurrentContent = _xmlFileControl;
			//contentControl.Content= _newXmlFileControl;
		}
		
		void mainViewControl_EditXmlFileClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = ".mtr"; // Default file extension
			dlg.Filter = "Документы Metrolog (.mtr)|*.mtr|Все файлы (*.*)|*.*"; //"Документы Metrolog (.mtr)|*.mtr"; // Filter files by extension
			dlg.InitialDirectory = Environment.CurrentDirectory;
			//dlg.DefaultExt = ".docx"; // Default file extension
			//dlg.Filter = "Text documents (.docx)|*.docxtxt"; // Filter files by extension
			
			if (dlg.ShowDialog(this) == true)
			{
				string filePath = dlg.FileName;
				//MessageBox.Show(FilePath);
				_xmlFileControl.LoadFile(filePath);
				CurrentContent = _xmlFileControl;
				//return true;
			}
			//return false;
			
		}

		void mainViewControl_ShowXmlFileClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = ".xml"; // Default file extension
			dlg.Filter = "Документы Metrolog (.xml)|*.xml|Все файлы (*.*)|*.*"; // Filter files by extension
			dlg.InitialDirectory = Environment.CurrentDirectory;
			
			if (dlg.ShowDialog(this) == true)
			{
				string filePath = dlg.FileName;
				//_XmlFileControl.LoadFile(filePath);
				CurrentContent = _xmlFileViewer;
				_xmlFileViewer.LoadXmlToView(filePath);
				//return true;
			}
			//return false;
		}

		void _newXmlFileControl_ReturnToMainViewClick(object sender, RoutedEventArgs e)
		{
			CurrentContent = _mainViewControl;
		}
		
		private void Window1_OnClosing(object sender, CancelEventArgs e)
		{
			if (_xmlFileControl.ChangeFlag)
			{
				MessageBoxResult res = MessageBox.Show("Сохранить файл результатов поверки?", "Metrolog",
						MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

				if (res == MessageBoxResult.Cancel)
				{
					e.Cancel = true;
					return;
				}

				if (res == MessageBoxResult.Yes)
				{
					_xmlFileControl.SaveresultList();
					e.Cancel = true;
					return;
				}

				_xmlFileControl.ChangeFlag = false;
			}
		}

		private void Window1_OnLoaded(object sender, RoutedEventArgs e)
		{
			SetSettings();
		}

		private void SetSettings()
		{
			_xmlFileControl.IsValidate = App.ApplicationSettings.IsValidate;
			_xmlFileControl.IsValidateToSchema = App.ApplicationSettings.IsValidateToSchema;
			_xmlFileViewer.XmlViewerType = App.ApplicationSettings.XmlViewer;
			_xmlFileControl.XmlViewerType = App.ApplicationSettings.XmlViewer;
		}
	}
}