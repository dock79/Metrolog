using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Metrolog
{
    internal class Item2ChoiceTypeConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string name = (string) parameter;
            if (value is Item2ChoiceType)
            {
                if (name == "manufactureNum_2_RadioButton")
                {
                    if ((Item2ChoiceType) value == Item2ChoiceType.manufactureNum)
                        return true;
                    else
                        return false;
                }
                else if (name == "inventoryNum_2_RadioButton")
                {
                    if ((Item2ChoiceType) value == Item2ChoiceType.inventoryNum)
                        return true;
                    else
                        return false;
                }
            }

            return false;

            /*if (value is Item1ChoiceType)
            {
                if ((Item1ChoiceType)value == Item1ChoiceType.manufactureNum) return true;
                else return false;		
            }
            return false;*/
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            string name = (string) parameter;
            if (value is bool)
            {
                if (name == "manufactureNum_2_RadioButton")
                {
                    if ((bool) value == true) return Item2ChoiceType.manufactureNum;
                }
                else if (name == "inventoryNum_2_RadioButton")
                {
                    if ((bool) value == true) return Item2ChoiceType.inventoryNum;
                }
            }

            return Item2ChoiceType.manufactureNum;

            if (value is bool)
            {
                if ((bool) value == true)
                    return Item2ChoiceType.manufactureNum;
                else
                    return Item2ChoiceType.inventoryNum;
            }

            return Item2ChoiceType.manufactureNum;
        }

        #endregion
    }

    /* 
        Конвертирует тип bool в противоположный (true в false, и наоборот)
    */
    ///<summary>
    /// Конвертирует тип bool в противоположный (true в false, и наоборот)	
    /// </summary>
    internal class BoolInverseConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool res = (bool) value;
            return !res;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            //return value;
            return Convert(value, targetType, parameter, culture);
        }

        #endregion
    }

    internal class EnumDescriptionConverter : IValueConverter
    {
        private string GetEnumDescription(Enum enumObj)
        {
            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length == 0)
                return enumObj.ToString();
            else
            {
                DescriptionAttribute attrib = null;

                foreach (var att in attribArray)
                {
                    if (att is DescriptionAttribute) attrib = att as DescriptionAttribute;
                }

                if (attrib != null) return attrib.Description;

                return enumObj.ToString();
            }
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum)) return null;
            Enum myEnum = (Enum) value;

            string description = GetEnumDescription(myEnum);
            return description;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }

    internal class YesNoToBooleanConverter : IValueConverter
    {
        private const string YesText = "Да";

        private const string NoText = "Нет";
        //public static readonly YesNoToBooleanConverter Instance = new YesNoToBooleanConverter();

        //private YesNoToBooleanConverter ()
        // {
        // }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(true, value) ? YesText : NoText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Actually won't be used, but in case you need that
            return Equals(value, YesText);
        }
    }

    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute) attrs[0]).Description;
                }
            }

            return description;
        }
    }

    public static class NullableEnumHelper
    {
        public static string GetDescription<T>(this T? enumValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute) attrs[0]).Description;
                }
            }

            return description;
        }
    }

    public class YearAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                try
                {
                    string yearString = value.ToString();
                    DateTime year = DateTime.ParseExact(yearString, "yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);

                    //int iyear = Convert.ToInt32(dyear.Year);
                    if ((year.Year < 1950) || (year.Year > 2050))
                    {
                        this.ErrorMessage = "Год должен находиться в пределах 1950-2050.";
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    this.ErrorMessage = "Год должен находиться в пределах 1950-2050.";
                    return false;
                }
            }

            this.ErrorMessage = "Год должен находиться в пределах 1950-2050.";
            return false;
        }
    }

    public class ComparisonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return value.Equals(parameter);
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return value.Equals(true) == true ? parameter : Binding.DoNothing;
            else
                return null;

            //var Parameter = parameter as string;
            //return Parameter == null ? DependencyProperty.UnsetValue : Enum.Parse(typeof(PSType), Parameter);
            // return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }

    public class EnumBooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string parameterString = parameter as string;
            if (parameterString == null) return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false) return DependencyProperty.UnsetValue;

            object parameterValue = Enum.Parse(value.GetType(), parameterString);

            return parameterValue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            string parameterString = parameter as string;
            if (parameterString == null) return DependencyProperty.UnsetValue;

            return Enum.Parse(targetType, parameterString);
        }

        #endregion

        /*public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             return value.Equals(parameter);
         }
      
         public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             return value.Equals(true) ? parameter : Binding.DoNothing;
         }
       */
    }

    internal class ValidDateConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var si = value.ToString();
                if (si.Equals("Item2")) return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null;
        }

        #endregion
    }

    internal class gpslpsConverter : IMultiValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || !targetType.IsAssignableFrom(typeof(bool)))
            {
                return false;
            }

            foreach (var value in values)
            {
                if (!(value is bool))
                {
                    return false;
                }
                else if (!(bool) value)
                {
                    return false;
                }
            }

            return true;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool) || !targetType.Any(t => t.IsAssignableFrom(typeof(bool))))
            {
                return null;
            }

            if ((bool) value)
            {
                return targetType.Select(t => (object) true).ToArray();
            }
            else
            {
                return null;
            }
        }

        #endregion
    }

    ///<summary>
    /// Конвертор для radiobutton значения mp. Конвертирует нажата ли кнопка в зависимости от двух условий IsPS=false и Type=mp
    /// </summary>
    internal class mpConverter : IMultiValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || !targetType.IsAssignableFrom(typeof(bool)))
            {
                return false;
            }

            foreach (var value in values)
            {
                if (!(value is bool))
                {
                    return false;
                }
                else if (!(bool) value)
                {
                    return false;
                }
            }

            return true;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool) || !targetType.Any(t => t.IsAssignableFrom(typeof(bool))))
            {
                return null;
            }

            if ((bool) value)
            {
                return targetType.Select(t => (object) true).ToArray();
            }
            else
            {
                return null;
            }
        }

        #endregion
    }

    public class NonEmptyRule : ValidationRule
    {
        public NonEmptyRule()
        {
        }

        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string res = (string) value;
                if (String.IsNullOrWhiteSpace(res))
                    return new System.Windows.Controls.ValidationResult(false,
                        "Ошибка введенных данных. Поле не может быть пустым.");
                else
                    return System.Windows.Controls.ValidationResult.ValidResult;
            }
            catch (Exception ex)
            {
                return new System.Windows.Controls.ValidationResult(false, "Ошибка введенных данных " + ex.Message);
            }
        }
    }

    public class CurrentIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is int)
            {
                int res = (int) value;
                if (res >= 0)
                    return true;
                else
                    return false;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value != null && value is bool)
            {
                bool res = (bool) value;
                if (res)
                    return 0;
                else
                    return -1;
            }
            else
                return null;
        }
    }
}