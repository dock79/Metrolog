/*
 * Created by SharpDevelop.
 * User: yudin.sv
 * Date: 03/31/2021
 * Time: 11:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
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

namespace Metrolog
{
	/// <summary>
	/// Interaction logic for TabItemControl2.xaml
	/// </summary>
	public partial class TabItemControl2 : UserControl
	{
		//recInfo result = new recInfo();
		//recInfoApplicable applicable = new recInfoApplicable();
		//recInfoInapplicable inapplicable = new recInfoInapplicable();
		
		/*public string signCipher
		{
			get;
			set;
		}
		
        public string miOwner
        {
			get;
			set;
		}        
            
        public DateTime? vrfDate
        {
			get;
			set;
		}
        
        public DateTime? validDate
		{
			get;
			set;
		}        	
            
       	public recInfoType type
       	{
			get;
			set;
		}	
       		
      	public bool calibration
      	{
			get;
			set;
		}
      	
       	public string docTitle
		{
			get;
			set;
		}   
       	
       	public string metrologist
       	{
			get;
			set;
		}           
		
       	ApplicableType ApplicableType;
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
		
		public TabItemControl2()
		{
			InitializeComponent();
			_result = new recInfo();
			//LoadData();		
			//CreateBindings();
			
		
		}		
	
		
		
		public void CreateBindings()
		{		
			Binding binding1 = new Binding();
            binding1.Source = _result;
            binding1.Path = new PropertyPath("signCipher");
            binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            signCipherTextBox.SetBinding(TextBox.TextProperty, binding1);
            
            Binding binding2 = new Binding();
            binding2.Source = _result;
            binding2.Path = new PropertyPath("miOwner");
            binding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            miOwnerTextBox.SetBinding(TextBox.TextProperty, binding2);
            
            Binding binding3 = new Binding();
            binding3.Source = _result;
            binding3.Path = new PropertyPath("vrfDate");
            binding3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            vrfDateDatePicker.SetBinding(DatePicker.SelectedDateProperty, binding3);
            
            Binding binding4 = new Binding();
            binding4.Source = _result;
            binding4.Path = new PropertyPath("validDate");
            binding4.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            validDateDatePicker.SetBinding(DatePicker.SelectedDateProperty, binding4);
            
            // Здесь комбобокс со значениями
            //result.type = recInfoType.Item2;
            Binding binding5 = new Binding();
            binding5.Source = _result;
            //binding5.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding5.Path = new PropertyPath("type");
            //typeComboBox.SetBinding(TextBox.TextProperty, binding5);
           	typeComboBox.SetBinding(ComboBox.SelectedItemProperty, binding5);
            
			// Здесь комбобокс со значениями
            result.calibration = false;
			Binding binding6 = new Binding();
            binding6.Source = _result;
            binding6.Path = new PropertyPath("calibration");
            //calibrationComboBox.SetBinding(TextBox.TextProperty, binding6);
            calibrationComboBox.SetBinding(ComboBox.SelectedItemProperty, binding6);
			            
            applicableRadioButton.DataContext = _result;
            inapplicableRadioButton.DataContext = _result;
            
            Binding binding7 = new Binding();
            binding7.Source = _result.applicable;
            binding7.Path = new PropertyPath("stickerNum");
            binding7.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            stickerNumTextBox.SetBinding(TextBox.TextProperty, binding7);
            
            // Здесь комбобокс со значениями
            //result.applicable.signPass=false;
            Binding binding8 = new Binding();
            binding8.Source = _result.applicable;
            binding8.Path = new PropertyPath("signPass");
            //signPassComboBox.SetBinding(TextBox.TextProperty, binding8);
            signPassComboBox.SetBinding(ComboBox.SelectedItemProperty, binding8);
            
            // Здесь комбобокс со значениями
            //result.applicable.signMi=false;
            Binding binding9 = new Binding();
            binding9.Source = _result.applicable;
            binding9.Path = new PropertyPath("signMi");            
            signMiComboBox.SetBinding(ComboBox.SelectedItemProperty, binding9);
                        
            Binding binding10 = new Binding();
            binding10.Source = _result.inapplicable;
            binding10.Path = new PropertyPath("reasons");
            binding10.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            reasonsTextBox.SetBinding(TextBox.TextProperty, binding10);
            
            Binding binding11 = new Binding();
            binding11.Source = _result;
            binding11.Path = new PropertyPath("docTitle");
            binding11.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            docTitleTexrtBox.SetBinding(TextBox.TextProperty, binding11);
            
            Binding binding12 = new Binding();
            binding12.Source = _result;
            binding12.Path = new PropertyPath("metrologist");
            binding12.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            metrologistTextBox.SetBinding(TextBox.TextProperty, binding12);      
       }
	
	}	
}