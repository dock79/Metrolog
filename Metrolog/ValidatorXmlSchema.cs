using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Schema;

namespace Metrolog
{
    public static class ValidatorXmlSchema
    {
        public static (bool errors, List<string> errorsList, bool warnings, List<string> warningsList) ValidateToSchema(XmlDocument xmlDoc, string schemaUri)
        {
            bool errors = false;
            bool warnings = false;
            List<string> errorsList = new List<string>();
            List<string> warningsList = new List<string>();
            
            try
            {
                ///////////////////// Почему-то не работает, может что-то с потоком sw
                /*XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, "schema.xsd");
                settings.ValidationType = ValidationType.Schema;
                ValidationEventHandler eventHandler = new ValidationEventHandler(validation);
               
                // Create the XmlSchemaSet class.
                XmlSchemaSet sc = new XmlSchemaSet();
                // Add the schema to the collection.
                sc.Add(null, "schema.xsd");
                xmlDoc.Schemas.Add(null,"schema.xsd");
                xmlDoc.Validate(validation);
                sw = new StreamWriter("writePath.txt");
                sw.WriteLine(";l;;");
                 sw.Close();
                      sw = new StreamWriter("23.txt");
                      sw.WriteLine("llll");
                sw.Write((";;;;"));
                */ ///////////////////

                
                XmlReaderSettings validateSettings = new XmlReaderSettings();
                validateSettings.Schemas.Add(null, schemaUri);
                validateSettings.ValidationType = ValidationType.Schema;
                validateSettings.ValidationEventHandler += (o, e) =>
                {
                    switch (e.Severity)
                    {
                        case XmlSeverityType.Error:
                            errorsList.Add(e.Message);
                            errors = true;
                            break;
                        case XmlSeverityType.Warning:
                            warningsList.Add(e.Message);
                            warnings = true;
                            break;
                    }
                };
                
                MemoryStream strm = new MemoryStream();
                xmlDoc.Save(strm);
                strm.Position = 0;
                XmlReader xmlReader = XmlReader.Create(strm, validateSettings);
                while (xmlReader.Read())
                {
                }
                strm.Close();

            }
            catch (Exception ex)
            {
                throw;
                //MessageBox.Show(ex.Message, "Ошибка");
            }

            var result = (errors, errorsList, warnings, warningsList);
            return result;
        }
        
        public static (bool errors, string errorsText, bool warnings, string warningsText) ValidateAndGetText(XmlDocument xmlDoc, string schemaUri)
        {
            var validateTuple = ValidateToSchema(xmlDoc, schemaUri);
            
            StringBuilder errorsStringBuilder = new StringBuilder();
            foreach (var s in validateTuple.errorsList)
            {
                errorsStringBuilder.AppendLine("ERROR: " + s);
            }
            
            StringBuilder warningsStringBuilder = new StringBuilder();
            foreach (var s in validateTuple.warningsList)
            {
                warningsStringBuilder.AppendLine("WARNING: " + s);
            }
            var result = (validateTuple.errors, errorsStringBuilder.ToString(), validateTuple.warnings, warningsStringBuilder.ToString());
            return result;
        }
        
        public static (bool errors, bool warnings, string errorsAndWarningsText) ValidateAndGetCommonText(XmlDocument xmlDoc, string schemaUri)
        {
            var validateTuple = ValidateAndGetText(xmlDoc, schemaUri);

            string resultText = validateTuple.errorsText + validateTuple.warningsText;
            
            var result = (validateTuple.errors, validateTuple.warnings, resultText);
            return result;
        }
        
    }
}