using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace Metrolog
{
    public class ApplicationSettings
    {
        private static Configuration _configuration;
        private static bool _isValidate;
        private static bool _isValidateToSchema;
        private static int _colorTheme;
        private static int _xmlViewer;
        private static bool _isAnimate;
        
        static ApplicationSettings()
        {
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //_configuration = ConfigurationManager.OpenExeConfiguration("Metrolog.config");
            //LoadSettings();
            /*IsValidate = Convert.ToBoolean(_config.AppSettings.Settings["IsValidate"].Value);
            IsValidateToSchema = Convert.ToBoolean(_config.AppSettings.Settings["IsValidateToSchema"].Value);
            ColorTheme = Convert.ToInt32(_config.AppSettings.Settings["ColorTheme"].Value);
            XmlViewer = Convert.ToInt32(_config.AppSettings.Settings["XmlViewer"].Value);
            */
        }


        public static bool IsValidate
        {
            get => _isValidate;
            set
            {
                // _isValidate = value;
                if (value == _isValidate) return;
                _isValidate = value;
                //_config.AppSettings.Settings["IsValidate"].Value = value.ToString();
                OnGlobalPropertyChanged();
            }
        }

        public static bool IsValidateToSchema
        {
            get => _isValidateToSchema;
            set
            {
                if (value == _isValidateToSchema) return;
                _isValidateToSchema = value;
                //_config.AppSettings.Settings["IsValidateToSchema"].Value = value.ToString();
                OnGlobalPropertyChanged();
            }
        }

        public static int ColorTheme
        {
            get => _colorTheme;
            set
            {
                if (value == _colorTheme) return;
                _colorTheme = value;
                OnGlobalPropertyChanged();
            }
        }

        public static int XmlViewer
        {
            get => _xmlViewer;
            set
            {
                if (value == _xmlViewer) return;
                _xmlViewer = value;
                OnGlobalPropertyChanged();
            }
        }
        
        public static bool IsAnimate
        {
            get => _isAnimate;
            set
            {
                if (value == _isAnimate) return;
                _isAnimate = value;
                //_config.AppSettings.Settings["IsValidateToSchema"].Value = value.ToString();
                OnGlobalPropertyChanged();
            }
        }

        public static void LoadSettings()
        {
            //_configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool result = CheckConfigurationFile();
            if (result)
            {
                LoadSettingsFromConfiguration();
            }
            else
            {
                CreateConfigurationFile();
                LoadDefaultSettings();
                //SaveSettings();
            }
        }
        private  static bool CheckConfigurationFile()
        {
            try
            {
                if (!_configuration.HasFile)
                {
                    return false;
                }
               
                /*AppSettingsSection settingsSection  = (AppSettingsSection)_configuration.GetSection("appSettings");//
                if (settingsSection == null)
                {
                    return false;
                }*/
            }
            catch (ConfigurationErrorsException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        private static void CreateConfigurationFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sb.AppendLine("<configuration>");
            sb.AppendLine("</configuration>");

            string loc = Assembly.GetEntryAssembly().Location;
            File.WriteAllText(String.Concat(loc, ".config"), sb.ToString());
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        
        private static void LoadSettingsFromConfiguration()
        {
            IsValidate = Convert.ToBoolean(_configuration.AppSettings.Settings["IsValidate"].Value);
            IsValidateToSchema = Convert.ToBoolean(_configuration.AppSettings.Settings["IsValidateToSchema"].Value);
            ColorTheme = Convert.ToInt32(_configuration.AppSettings.Settings["ColorTheme"].Value);
            XmlViewer = Convert.ToInt32(_configuration.AppSettings.Settings["XmlViewer"].Value);
            IsAnimate = Convert.ToBoolean(_configuration.AppSettings.Settings["IsAnimate"].Value);
        }
        

        private static void LoadDefaultSettings()
        {
            IsValidate = false;
            IsValidateToSchema = false;
            ColorTheme = 0;
            XmlViewer = 0;
            IsAnimate = false;
            //MessageBox.Show(" LoadDefaultSettings start");
            //_configuration.Save(ConfigurationSaveMode.Modified);
            //AppSettingsSection settingsSection = new AppSettingsSection();
            //var sections = _configuration.Sections;
            //if (sections == null) MessageBox.Show("section is null");
            //_configuration.Sections.Add("appSettings", settingsSection);
            //MessageBox.Show(" LoadDefaultSettings end");
        }

        public static void SaveSettings()
        {
            _configuration.AppSettings.Settings["IsValidate"].Value = IsValidate.ToString();
            _configuration.AppSettings.Settings["IsValidateToSchema"].Value = IsValidateToSchema.ToString();
            _configuration.AppSettings.Settings["ColorTheme"].Value = ColorTheme.ToString();
            _configuration.AppSettings.Settings["XmlViewer"].Value = XmlViewer.ToString();
            _configuration.AppSettings.Settings["IsAnimate"].Value = IsAnimate.ToString();
            _configuration.Save();
        }

        public static void ChangeKey(string key, string value)
        {
            _configuration.AppSettings.Settings[key].Value = value;
        }

        public static string GetKey(string key)
        {
            return _configuration.AppSettings.Settings[key].Value;
        }
        
        
        public static bool LoadSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));

            // Declare an object variable of the type to be deserialized.
            List<recInfo> res;
            string fileName = "Metrolog.config";
            if (!File.Exists(fileName))
            {
                return false; 
            }

            using (Stream reader = new FileStream(fileName, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                this = (ApplicationSettings) serializer.Deserialize(reader);
                reader.Close();
            }
        }

        #region

        public static event PropertyChangedEventHandler GlobalPropertyChanged;

        private static void OnGlobalPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (GlobalPropertyChanged != null)
                GlobalPropertyChanged.Invoke(typeof(ApplicationSettings), new PropertyChangedEventArgs(propertyName));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}