using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Metrolog.Annotations;

namespace Metrolog
{
    public class ApplicationSettings : INotifyPropertyChanged
    {
    private bool _isValidate;
    private bool _isValidateToSchema;
    private int _colorTheme;
    private XmlViewer _xmlViewer;
    private bool _isAnimate;
    private string _schemaFile;

    public ApplicationSettings()
    {
        IsValidate = false;
        IsValidateToSchema = false;
        ColorTheme = 0;
        XmlViewer = 0;
        IsAnimate = false;
        _schemaFile = null;
    }


    public bool IsValidate
    {
        get => _isValidate;
        set
        {
            // _isValidate = value;
            if (value == _isValidate) return;
            _isValidate = value;
            //_config.AppSettings.Settings["IsValidate"].Value = value.ToString();
            OnPropertyChanged();
        }
    }

    public bool IsValidateToSchema
    {
        get => _isValidateToSchema;
        set
        {
            if (value == _isValidateToSchema) return;
            _isValidateToSchema = value;
            //_config.AppSettings.Settings["IsValidateToSchema"].Value = value.ToString();
            OnPropertyChanged();
        }
    }

    public int ColorTheme
    {
        get => _colorTheme;
        set
        {
            if (value == _colorTheme) return;
            _colorTheme = value;
            OnPropertyChanged();
        }
    }

    public XmlViewer XmlViewer
    {
        get => _xmlViewer;
        set
        {
            if (value == _xmlViewer) return;
            _xmlViewer = value;
            OnPropertyChanged();
        }
    }

    public bool IsAnimate
    {
        get => _isAnimate;
        set
        {
            if (value == _isAnimate) return;
            _isAnimate = value;
            OnPropertyChanged();
        }
    }

    /*
    /// <summary>
    /// Событие, возникающее при изменении свойства
    /// </summary>
    public static event PropertyChangedEventHandler SettingsChanged;
    
    protected static void OnSettingsChanged([CallerMemberName] string propertyName = null)
    {
        SettingsChanged?.Invoke(typeof(ApplicationSettings), new PropertyChangedEventArgs(propertyName));
    } 
    */
    
    public string SchemaFile
    {
        get => _schemaFile;
        set
        {
            if (value == _schemaFile) return;
            _schemaFile = value;
            OnPropertyChanged();
        }
    }
   
    
    public static ApplicationSettings LoadSettings(string fileName)
    {
        bool result = CheckApplicationSettingsFileExisting(fileName);
        ApplicationSettings settings;
        if (result)
        {
            try
            {
                settings = LoadSettingsFromFile(fileName);
            }
            catch (Exception e)
            {
                settings = LoadDefaultSettings();
            }
            return settings;
        }
        else
        {
            settings = LoadDefaultSettings();
            return settings;
        }
    }
 
    private static bool CheckApplicationSettingsFileExisting(string fileName)
    {
        bool result = File.Exists(fileName);
        if (result)
        {
            return true;
        }

        return false;
    }

    private static ApplicationSettings LoadSettingsFromFile(string fileName)
    {
        // Declare an object variable of the type to be deserialized.
        XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));
        ApplicationSettings settings;
        using (Stream reader = new FileStream(fileName, FileMode.Open))
        {
            // Call the Deserialize method to restore the object's state.
            settings = (ApplicationSettings) serializer.Deserialize(reader);
            reader.Close();
        }

        return settings;
    }
    
    
    private static ApplicationSettings LoadDefaultSettings() => new ApplicationSettings();
    
    public static void SaveSettings(ApplicationSettings settings, string fileName)
    {
        XmlSerializer formatter = new XmlSerializer(typeof(ApplicationSettings));

        try
        {
            if (fileName != null)
            {
                using (TextWriter tw = new StreamWriter(fileName))
                {
                    formatter.Serialize(tw, settings);
                    tw.Close();
                }
            }
        }
        catch (Exception e)
        {
				
        }
    }
    
    #region
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } 
    #endregion
    
    }
}