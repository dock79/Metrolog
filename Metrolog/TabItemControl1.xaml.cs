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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
	/// Interaction logic for TabItemControl1.xaml
	/// </summary>
	public partial class TabItemControl1 : UserControl
	{
		//recInfoMiInfo miInfo = new recInfoMiInfo();
		/*recInfoMiInfoEtaMI etaMI = new recInfoMiInfoEtaMI(); 
		recInfoMiInfoEtaMIPrimaryRec primaryRec = new recInfoMiInfoEtaMIPrimaryRec();
		recInfoMiInfoEtaMIPrimaryRecGps gps = new recInfoMiInfoEtaMIPrimaryRecGps();
		recInfoMiInfoEtaMIPrimaryRecLps lps = new recInfoMiInfoEtaMIPrimaryRecLps();
		recInfoMiInfoEtaMIPrimaryRecMP mp =	new recInfoMiInfoEtaMIPrimaryRecMP();
		recInfoMiInfoEtaMIRegNumber regNumber = new recInfoMiInfoEtaMIRegNumber();		
		recInfoMiInfoSingleMI singleMI = new recInfoMiInfoSingleMI();						
		*/
		recInfo _result = new recInfo();
		
		public TabItemControl1()
		{
			InitializeComponent();
			_result = new recInfo();
			//miInfo = new recInfoMiInfo();
			
			//LoadData();
			//CreateBindings();				
						
			//primaryRec.modification =";llll2222299999";
			//MessageBox.Show(primaryRec.modification);
			//BindingExpression be = modification_1_TextBox.GetBindingExpression(TextBox.TextProperty);
			//be.UpdateTarget();
				
		}
		
		/*public recInfoMiInfo miInfo
		{
			get;
			set;
		}*/
		
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
		
		
		public void CreateBindings()
		{	
			//miInfo.Type = MIType.singleMI;			
			etaMIRadioButton.DataContext = _result.miInfo;
			singleMIRadioButton.DataContext = _result.miInfo;
			
			//etaMI.Type = etaMIType.primaryRec;
			primaryRecRadioButton.DataContext = _result.miInfo.etaMI;
			regNumberRadioButton.DataContext = _result.miInfo.etaMI;
			
			//this.DataContext = etaMI;
			Binding binding1 = new Binding();
			binding1.Source = _result.miInfo.etaMI.primaryRec;
			binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			//binding1.Mode = BindingMode.TwoWay;
			binding1.Path = new PropertyPath("mitypeNumber");
			//binding1.ValidationRules.Add(new NonEmptyRule());			
			mitypeNumber_1_TextBox.SetBinding(TextBox.TextProperty, binding1);		
						
			Binding binding2 = new Binding();
			binding2.Source = _result.miInfo.etaMI.primaryRec;            
			binding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding2.ValidatesOnNotifyDataErrors = true;
			//binding2.NotifyOnValidationError=true;
			//binding2.ValidatesOnDataErrors=true;			
			//binding2.ValidatesOnExceptions = true;			
			binding2.Path = new PropertyPath("modification");
			modification_1_TextBox.SetBinding(TextBox.TextProperty, binding2);           
			
			//primaryRec.manufactureNum= "k324242";
			Binding binding3 = new Binding();
			binding3.Source = _result.miInfo.etaMI.primaryRec;
			binding3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding3.Path = new PropertyPath("manufactureNum");
			//binding3.Mode = BindingMode.TwoWay;            
			manufactureNum_1_TextBox.SetBinding(TextBox.TextProperty, binding3);            
                        
			Binding binding4 = new Binding();
			binding4.Source = _result.miInfo.etaMI.primaryRec;
			binding4.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding4.Path = new PropertyPath("manufactureYear");
			manufactureYearTextBox1.SetBinding(TextBox.TextProperty, binding4); 
			
			// Здесь комбобокс с "да, нет" 
			//primaryRec.isOwner = false;
			Binding binding5 = new Binding();
			binding5.Source = _result.miInfo.etaMI.primaryRec;
			binding5.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding5.Path = new PropertyPath("isOwner");            
			//binding5.Converter = new YesNoToBooleanConverter1();
			isOwnerComboBox.SetBinding(ComboBox.SelectedItemProperty, binding5);
           
			//primaryRec.Type = PSType.mp;
			psRadioButton.DataContext = _result.miInfo.etaMI.primaryRec;
			gpsRadioButton.DataContext = _result.miInfo.etaMI.primaryRec.ps;
			lpsRadioButton.DataContext = _result.miInfo.etaMI.primaryRec.ps;
			mpRadioButton.DataContext = _result.miInfo.etaMI.primaryRec;
            
			Binding binding6 = new Binding();
			binding6.Source = _result.miInfo.etaMI.primaryRec.ps;
			binding6.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding6.Path = new PropertyPath("title");
			title_TextBox.SetBinding(TextBox.TextProperty, binding6);

			Binding binding7 = new Binding();
			binding7.Source = _result.miInfo.etaMI.primaryRec.ps;
			binding7.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding7.Path = new PropertyPath("npeNumber");
			npeNumber_TextBox.SetBinding(TextBox.TextProperty, binding7);
            
			// Здесь комбобокс со значениями
			//gps.rank= rankEnum.Item4;
			Binding binding8 = new Binding();
			binding8.Source = _result.miInfo.etaMI.primaryRec.ps;
			binding8.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;            
			binding8.Path = new PropertyPath("rank");
			//rank_1_ComboBox.SetBinding(TextBox.TextProperty, binding8);
			rank_ComboBox.SetBinding(ComboBox.SelectedItemProperty, binding8);           
						
			Binding binding12 = new Binding();
			binding12.Source = _result.miInfo.etaMI.primaryRec.mp;
			binding12.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding12.Path = new PropertyPath("title");
			//binding12.ValidationRules.Add(new DataErrorValidationRule()); 
			title_3_TextBox.SetBinding(TextBox.TextProperty, binding12);

			Binding binding13 = new Binding();
			binding13.Source = _result.miInfo.etaMI.regNumber;//etaMI;
			binding13.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding13.Path = new PropertyPath("regNumber");
			regNumberTextBox.SetBinding(TextBox.TextProperty, binding13);
			
			//Устанавливаем радиокнопки
			//singleMI.Item1Type = Item1ChoiceType.crtmitypeTitle;
			mitypeNumberRadioButton.DataContext = _result.miInfo.singleMI;
			crtmitypeTitleRadioButton.DataContext = _result.miInfo.singleMI;
			milmitypeTitleRadioButton.DataContext = _result.miInfo.singleMI;
			//singleMI.Item2Type = Item2ChoiceType.inventoryNum;
			manufactureNum_1_RadioButton.DataContext = _result.miInfo.singleMI;
			inventoryNum_1_RadioButton.DataContext = _result.miInfo.singleMI;
            
			Binding binding14 = new Binding();
			binding14.Source = _result.miInfo.singleMI;
			binding14.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding14.Path = new PropertyPath("mitypeNumber");                     
			mitypeNumber_2_TextBox.SetBinding(TextBox.TextProperty, binding14);
            
			Binding binding15 = new Binding();
			binding15.Source = _result.miInfo.singleMI;
			binding15.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding15.Path = new PropertyPath("crtmitypeTitle");           
			crtmitypeTitleTextBox.SetBinding(TextBox.TextProperty, binding15);
            
			Binding binding16 = new Binding();
			binding16.Source = _result.miInfo.singleMI;
			binding16.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding16.Path = new PropertyPath("milmitypeTitle");            
			milmitypeTitleTextBox.SetBinding(TextBox.TextProperty, binding16);
            
			Binding binding17 = new Binding();
			binding17.Source = _result.miInfo.singleMI;
			binding17.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding17.Path = new PropertyPath("manufactureNum");
			manufactureNum_2_TextBox.SetBinding(TextBox.TextProperty, binding17);
            
			Binding binding18 = new Binding();
			binding18.Source = _result.miInfo.singleMI;
			binding18.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding18.Path = new PropertyPath("inventoryNum");           
			inventoryNumTextBox.SetBinding(TextBox.TextProperty, binding18);
            
			Binding binding19 = new Binding();
			binding19.Source = _result.miInfo.singleMI;
			binding19.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding19.Path = new PropertyPath("manufactureYear");
			manufactureYearTextBox2.SetBinding(TextBox.TextProperty, binding19);
            
			Binding binding20 = new Binding();
			binding20.Source = _result.miInfo.singleMI;
			binding20.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			binding20.Path = new PropertyPath("modification");
			modification_2_TextBox.SetBinding(TextBox.TextProperty, binding20);
            
			//singleMI.ItemElementName = ItemChoiceType.crtmitypeTitle;
		}
	}
}