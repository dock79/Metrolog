/*
 * Created by SharpDevelop.
 * User: yudin.sv
 * Date: 03/31/2021
 * Time: 11:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace Metrolog
{
	/// <summary>
	/// Interaction logic for TabItemControl4.xaml
	/// </summary>
	public partial class TabItemControl4 : UserControl
	{				
		//recInfoConditions conditions = new recInfoConditions();
		//recInfo result = new recInfo();
		//recInfoBrief_procedure brief_procedure = new recInfoBrief_procedure();
		//recInfoProtocol protocol = new recInfoProtocol();
				
		
		/*public recInfoConditions conditions 
		{
			get;
			set;			
		}
		
		public recInfoBrief_procedure brief_procedure 
		{
			get;
			set;
		}
		
		public recInfoProtocol protocol
		{
			get;
			set;
		}
				
		public string structure
		{
			get;
			set;
		}		
		
		public string additional_info
		{
			get;
			set;			
		}
		*/
		
			
		recInfo _result = new recInfo();
       	
		public recInfo result 
		{
			get
			{
				return _result;
			}			
			set
			{
				_result = value;
				CreateBindings();
			}		
		}
		
		public TabItemControl4()
		{
			InitializeComponent();
			//conditions = new recInfoConditions();
			//brief_procedure = new recInfoBrief_procedure();
			//protocol = new recInfoProtocol();
			//LoadData();
			_result = new recInfo();
			//CreateBindings();
		}
		
		public void CreateBindings()
		{			
			Binding binding1 = new Binding();
            binding1.Source = _result.conditions;
            binding1.Path = new PropertyPath("temperature");
            binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            temperatureTextBox.SetBinding(TextBox.TextProperty, binding1);

            Binding binding2 = new Binding();
            binding2.Source =  _result.conditions;
            binding2.Path = new PropertyPath("pressure");
            binding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            pressureTextBox.SetBinding(TextBox.TextProperty, binding2);
            
            Binding binding3 = new Binding();
            binding3.Source =  _result.conditions;
            binding3.Path = new PropertyPath("hymidity");
            binding3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            hymidityTextBox.SetBinding(TextBox.TextProperty, binding3);
            
            Binding binding4 = new Binding();
            binding4.Source =  _result.conditions;
            binding4.Path = new PropertyPath("other");
            binding4.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            otherTextBox.SetBinding(TextBox.TextProperty, binding4);
                    
            Binding binding5 = new Binding();
            binding5.Source = _result;
            binding5.Path = new PropertyPath("structure");
            binding5.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            structureTextBox.SetBinding(TextBox.TextProperty, binding5);
            
            BriefProcedureCheckBox.DataContext = _result;
            
            Binding binding6 = new Binding();
            binding6.Source =  _result.brief_procedure;
            binding6.Path = new PropertyPath("characteristics");
            binding6.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            characteristicsTextBox.SetBinding(TextBox.TextProperty, binding6);
            
            Binding binding7 = new Binding();
            binding7.Source = _result;
            binding7.Path = new PropertyPath("additional_info");
            binding7.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            additional_infoTextBox.SetBinding(TextBox.TextProperty, binding7);

            ProtocolCheckBox.DataContext = _result;
            
            /*Binding binding8 = new Binding();
            binding8.Source = protocol;
            binding8.Path = new PropertyPath("content");
            contentTextBox.SetBinding(TextBox.TextProperty, binding8);
            
            // Здесь комбобокс со значениями
            //protocol.mimetype = recInfoProtocolMimetype.applicationzip;
            Binding binding9 = new Binding();
            //binding9.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //binding9.Mode = BindingMode.TwoWay;
            binding9.Source = protocol;
            binding9.Path = new PropertyPath("mimetype");
            //typeComboBox.SetBinding(TextBox.TextProperty, binding5);
           	mimetypeComboBox.SetBinding(ComboBox.SelectedItemProperty, binding9);
            	//mimetypeComboBox.SetBinding(ComboBox.SelectedValueProperty, binding9);
           	*/ 
           	
            Binding binding10 = new Binding();
            binding10.Source =  _result.protocol;
            binding10.Path = new PropertyPath("fullfilename");
            binding10.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            filenameTextBox.SetBinding(TextBox.TextProperty, binding10);                      	
         		
		}
			
		
		void button1_Click(object sender, RoutedEventArgs e)
		{			
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Файлы Adobe PDF (*.pdf)|*.pdf" + "|Документы Word (*.doc, *.docx)|*.doc;*.docx" + "|Архивы (*.zip)|*.zip" + "|Изображения (*.djvu)|*.djvu" + "|Все файлы (*.*)|*.*";
             	
			bool? dlgresult = dlg.ShowDialog();
			
			if (dlgresult == true)
			{
				// Получаем размер файла
				FileInfo fileInfo = new FileInfo(dlg.FileName);
				if (fileInfo.Length > 1_048_576)
				{
					MessageBox.Show("Размер файла не должен превышать 1 Мб", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
					return;
				}
				
				// Open document
    			string filename = dlg.FileName;
    			 _result.protocol.filename = Path.GetFileName(filename);
    			 _result.protocol.fullfilename = filename;
   				//protocol.mimetype = filename;
   				//filenameTextBox.Text = filename;
   			
   			// Получитьо двоичные данные
   			try
			{
				byte[] bytes = File.ReadAllBytes(filename);
				//string str = Convert.ToBase64String(bytes);
				//if (str != null) protocol.content = str;
				 _result.protocol.content = bytes;
				//protocol.contentString = Convert.ToBase64String(bytes);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка");
			}		
   			   			
   			#region
   			/*BinaryReader reader = new BinaryReader(File.Open("a2.pdf", FileMode.Open));
			reader.Close();
			
			byte[] bytes = File.ReadAllBytes("a4.pdf");
         	BitArray bits = new BitArray(bytes);         	
			
         	//string str1 = Encoding.UTF8.GetString(bytes);
         	//string str = BitConverter.ToString(bytes);
         	string str2 =  Convert.ToBase64String(bytes);         	     	
         	byte[] bytes1 = File.ReadAllBytes("f1.pdf");
         	byte[] bytes2  =  Convert.FromBase64String(str2);
         	File.WriteAllBytes("a6.pdf", bytes2);         	
         	string str3 = File.ReadAllText("f1.pdf");
         	byte[] bytes3  =  Convert.FromBase64String(str3);                               
         	File.WriteAllBytes("a61.pdf", bytes2);    	
   			*/
			#endregion
         	
         	
         	string extension = Path.GetExtension(filename);
         	//filenameTextBox.Text = extension.Substring(1);
         	//filenameTextBox.Text = filename;
         	
         	//string ext= extension.Substring(1);
                  	
         	switch (extension)
         	{
         		case ".pdf":
         			_result.protocol.mimetype = recInfoProtocolMimetype.applicationpdf;
         		//mimetypeComboBox.SelectedItem=0;
         			break;
         		case "doc":         		
         		case ".docx":
         			_result.protocol.mimetype = recInfoProtocolMimetype.applicationmsword;
         			//mimetypeComboBox.SelectedItem=1;
         			break;
         		case ".zip":
         			_result.protocol.mimetype = recInfoProtocolMimetype.applicationzip;
         			//mimetypeComboBox.SelectedItem=2;
         			break;
         		case ".djvu":
         			_result.protocol.mimetype = recInfoProtocolMimetype.imagevnddjvu;
         			//mimetypeComboBox.SelectedItem=3;
         			break;
         		default:
         			_result.protocol.mimetype = null;
         			 throw new InvalidOperationException("Unexpected extension: " + extension);          			
			
			}		
		}

		}
	/*public void SaveData()
	{	    
		  // !!!!!!!!!! CloneObject() НЕ ЗДЕСЬ НЕ РАБОТАЕТ, ВОЗНИКАЕТ ОШИБКА, В ДРУГИХ МЕСТАХ ОШИБКИ ПОКА НЕТ (В ДИАЛОГЕ 1 И 3), 
		// ПОСМОТРЕТЬ МОЖЕТ УБРАТЬ И ОТТУДА
	    //recInfo copy = (recInfo)result.CloneObject();
		
		recInfo copy = new recInfo();
		result.CopyTo(copy);	    
		
		result.conditions = conditions;
		result.brief_procedure = brief_procedure;
		result.protocol = protocol;
		
			
			XmlSerializer formatter = new XmlSerializer(typeof(recInfo));			
			TextWriter tw = new StreamWriter("serioz4.xml");
			//using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
			{
				//formatter.Serialize(tw, copy);
				formatter.Serialize(tw, copy);
			}
		
			tw.Close();	     	
	        
	 }
	    
	    public void LoadData()
	    {
	    	XmlSerializer serializer = new XmlSerializer(typeof(recInfo));

        	// Declare an object variable of the type to be deserialized.
        	recInfo i;
        	if (!File.Exists("serioz4.xml")) return;
        	using (Stream reader = new FileStream("serioz4.xml", FileMode.Open))
        	{
            	// Call the Deserialize method to restore the object's state.
            	i = (recInfo)serializer.Deserialize(reader);
	    	}    	
        	
        	if (i == null) return;        	
        	result = i;
        	if (i.conditions != null) conditions = i.conditions;
        	if (i.brief_procedure != null) brief_procedure = i.brief_procedure;
        	if (i.protocol != null) protocol = i.protocol;
        	
		}
		*/
	}
	
}