/*
 * Created by SharpDevelop.
 * User: yudin.sv
 * Date: 03/31/2021
 * Time: 11:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Metrolog
{	
		
	/// <summary>
	/// Interaction logic for TabItemControl3.xaml
	/// </summary>
	public partial class TabItemControl3 : UserControl
	{	
		
		

		
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
	
		public TabItemControl3()
		{
			InitializeComponent();
			result = new recInfo();
			//means = new recInfoMeans();
			//LoadData();	
			CreateBindings();
			
		}
				
		public void CreateBindings()
		{			
		
			// Добавление и привязка	
			npeListBox.ItemsSource = _result.means.npe;            
            npeListBox.DataContext = _result.means.npe;          
           
			uveListBox.ItemsSource = _result.means.uve;
			uveListBox.DataContext = _result.means.uve; 
			
			sesListBox.ItemsSource = _result.means.ses;
			sesListBox.DataContext = _result.means.ses; 
			
			mietaListBox.ItemsSource = _result.means.mieta;
			mietaListBox.DataContext = _result.means.mieta; 
			
			misListBox.ItemsSource = _result.means.mis;
			misListBox.DataContext = _result.means.mis; 
							
			reagentListBox.ItemsSource = _result.means.reagent;
			reagentListBox.DataContext = _result.means.reagent; 
			
			oMethodCheckBox.DataContext = _result.means;
			
			// Здесь комбобокс со значениями
			//means.oMethod = recInfoOMethod.Item3;
            Binding binding2 = new Binding();
            binding2.Source = _result.means;
            binding2.Path = new PropertyPath("oMethod");            
           	oMethodComboBox.SetBinding(ComboBox.SelectedItemProperty, binding2);       
          	
		}

		
	void button1_Click(object sender, RoutedEventArgs e)
	{
		_result.means.npe.Add(new Number());
	}
		
	void button2_Click(object sender, RoutedEventArgs e)
	{
		_result.means.uve.Add(new Number());
	}
		
	void button3_Click(object sender, RoutedEventArgs e)
	{
		_result.means.ses.Add(new recInfoSesSE());
	}
		
	void button4_Click(object sender, RoutedEventArgs e)
	{
		_result.means.mieta.Add(new Number());
	}
		
	void button5_Click(object sender, RoutedEventArgs e)
	{
		_result.means.mis.Add(new recInfoMisMI());
	}
	
	void button6_Click(object sender, RoutedEventArgs e)
	{
		_result.means.reagent.Add(new Number());
	}
	
		
		
		// команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand1
        {
	        get
            { 
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Number number = new Number();
                      _result.means.npe.Insert(0, number);
                      //SelectedPhone = phone;
                  }));
            }
        }   
   
	// команда удаления
  	private RelayCommand removeCommand1;
    private RelayCommand removeCommand2;
    private RelayCommand removeCommand3;
    private RelayCommand removeCommand4;
    private RelayCommand removeCommand5;
    private RelayCommand removeCommand6;
	    
  	public RelayCommand RemoveCommand1
   	{
           get
            {
                return removeCommand1 ??
                  (removeCommand1 = new RelayCommand(obj =>
                  {
                      Number number = obj as Number;
                      if (number != null)
                      {
                      	
                          _result.means.npe.Remove(number);
                      }
                  },
                 (obj) => _result.means.npe.Count > 0));
          }
    }
    
    public RelayCommand RemoveCommand2
    {
	    get
	    {
		    return removeCommand2 ??
		           (removeCommand2 = new RelayCommand(obj =>
			           {
				           Number number = obj as Number;
				           if (number != null)
				           {
                      	
					           _result.means.uve.Remove(number);
				           }
			           },
			           (obj) => _result.means.uve.Count > 0));
	    }
    }
	
    public RelayCommand RemoveCommand3
    {
	    get
	    {
		    return removeCommand3 ??
		           (removeCommand3 = new RelayCommand(obj =>
			           {
				           recInfoSesSE se = obj as recInfoSesSE;
				           if (se != null)
				           {
                      	
					           _result.means.ses.Remove(se);
				           }
			           },
			           (obj) => _result.means.ses.Count > 0));
	    }
    }
    
    public RelayCommand RemoveCommand4
    {
	    get
	    {
		    return removeCommand4 ??
		           (removeCommand4 = new RelayCommand(obj =>
			           {
				           Number number = obj as Number;
				           if (number != null)
				           {
                      	
					           _result.means.mieta.Remove(number);
				           }
			           },
			           (obj) => _result.means.mieta.Count > 0));
	    }
    }
    
    public RelayCommand RemoveCommand5
    {
	    get
	    {
		    return removeCommand5 ??
		           (removeCommand5 = new RelayCommand(obj =>
			           {
				           recInfoMisMI mi = obj as recInfoMisMI;
				           if (mi != null)
				           {
					           _result.means.mis.Remove(mi);
				           }
			           },
			           (obj) => _result.means.mis.Count > 0));
	    }
    }
    
    public RelayCommand RemoveCommand6
    {
	    get
	    {
		    return removeCommand6 ??
		           (removeCommand6 = new RelayCommand(obj =>
			           {
				           Number number = obj as Number;
				           if (number != null)
				           {
					           _result.means.reagent.Remove(number);
				           }
			           },
			           (obj) => _result.means.reagent.Count > 0));
	    }
    }
    
	}
	
	
	
}
