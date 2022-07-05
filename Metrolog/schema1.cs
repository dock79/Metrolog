///////////////////////////////////////////////////////////////////////////
//           Liquid XML Objects GENERATED CODE - DO NOT MODIFY           //
//            https://www.liquid-technologies.com/xml-objects            //
//=======================================================================//
// Dependencies                                                          //
//     Nuget : LiquidTechnologies.XmlObjects.Runtime                     //
//           : MUST BE VERSION 19.0.3                                    //
//=======================================================================//
// Online Help                                                           //
//     https://www.liquid-technologies.com/xml-objects-quick-start-guide //
//=======================================================================//
// Licensing Information                                                 //
//     https://www.liquid-technologies.com/eula                          //
///////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Numerics;
using LiquidTechnologies.XmlObjects;
using LiquidTechnologies.XmlObjects.Attribution;

// ------------------------------------------------------
// |                      Settings                      |
// ------------------------------------------------------
// GenerateCommonBaseClass                  = False
// GenerateUnprocessedNodeHandlers          = False
// RaiseChangeEvents                        = False
// CollectionNaming                         = Pluralize
// Language                                 = CS
// OutputNamespace                          = LiquidTechnologies.GeneratedLx
// WriteDefaultValuesForOptionalAttributes  = False
// WriteDefaultValuesForOptionalElements    = False
// GenerationModel                          = Simple
//                                            *WARNING* this simplified model that is very easy to work with
//                                            but may cause the XML to be produced without regard for element
//                                            cardinality or order. Where very high compliance with the XML Schema
//                                            standard is required use GenerationModelType.Conformant
// XSD Schema Files
//    file://sandbox/schema.xsd


namespace LiquidTechnologies.GeneratedLx
{
    #region Global Settings
    /// <summary>Contains library level properties, and ensures the version of the runtime used matches the version used to generate it.</summary>
    [LxRuntimeRequirements("19.0.3.10699", "Liquid Technologies Ltd", "8F2XHY3Q1G75DLPF", LiquidTechnologies.XmlObjects.LicenseTermsType.FullLicense)]
    public partial class LxRuntimeRequirementsWritten
    {
    }

    #endregion

}

namespace LiquidTechnologies.GeneratedLx.Xsd
{
    #region Complex Types
    /// <summary>A class representing the root XSD complexType anyType@http://www.w3.org/2001/XMLSchema</summary>
    /// <XsdPath>schema:.../www.w3.org/2001/XMLSchema/complexType:anyType</XsdPath>
    /// <XsdFile>http://www.w3.org/2001/XMLSchema</XsdFile>
    /// <XsdLocation>Empty</XsdLocation>
    [LxSimpleComplexTypeDefinition("anyType", "http://www.w3.org/2001/XMLSchema")]
    public partial class AnyTypeCt : XElement
    {
        /// <summary>Constructor : create a <see cref="AnyTypeCt" /> element &lt;anyType xmlns='http://www.w3.org/2001/XMLSchema'&gt;</summary>
        public AnyTypeCt()  : base(XName.Get("anyType", "http://www.w3.org/2001/XMLSchema")) { }

    }

    #endregion

}

namespace LiquidTechnologies.GeneratedLx.Tns
{
    #region Complex Types
    /// <summary>A class representing the root XSD complexType recInfo@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19</summary>
    /// <remarks>Тип данных: запись о результатах поверки СИ</remarks>
    /// <XsdPath>schema:schema.xsd/complexType:recInfo</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>83:5-778:23</XsdLocation>
    [LxSimpleComplexTypeDefinition("recInfo", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19")]
    public partial class RecInfoCt
    {
        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm" />, Required : should not be set to null</summary>
        /// <remarks>Сведения о СИ, применяемом в качестве эталона / СИ</remarks>
        [LxElementRef(MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm MiInfo { get; set; } = new LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm();

        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
        /// <remarks>Условный шифр знака поверки</remarks>
        [LxElementValue("signCipher", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, Pattern = "[А-Я]{1,3}")]
        public System.String SignCipher { get; set; } = "";

        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
        /// <remarks>Владелец СИ</remarks>
        [LxElementValue("miOwner", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "512")]
        public System.String MiOwner { get; set; } = "";

        /// <summary>A <see cref="LiquidTechnologies.XmlObjects.LxDateTime" />, Required</summary>
        /// <remarks>Дата поверки СИ</remarks>
        [LxElementValue("vrfDate", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdDate, MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.XmlObjects.LxDateTime VrfDate { get; set; }

        /// <summary>A nullable <see cref="LiquidTechnologies.XmlObjects.LxDateTime" />, Optional : null when not set</summary>
        /// <remarks>
        ///   <br/>
        ///       Поверка действительна до<br/>
        ///       Не указывается в случае, когда предусмотрена только первичная поверка<br/>
        ///   
        /// </remarks>
        [LxElementValue("validDate", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdDate, MinOccurs = 0, MaxOccurs = 1)]
        public LiquidTechnologies.XmlObjects.LxDateTime? ValidDate { get; set; }

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.TypeEnum" />, Required</summary>
        /// <remarks>Признак первичной или периодической поверки</remarks>
        [LxElementValue("type", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Enum, XsdType.Enum, MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.TypeEnum Type { get; set; }

        /// <summary>A <see cref="System.Boolean" />, Required</summary>
        /// <remarks>Признак поверки средства измерений с использованием результатов калибровки</remarks>
        [LxElementValue("calibration", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdBoolean, MinOccurs = 1, MaxOccurs = 1)]
        public System.Boolean Calibration { get; set; }

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.ApplicableElm" />, Optional : null when not set</summary>
        /// <remarks>СИ пригодно</remarks>
        [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.ApplicableElm Applicable { get; set; }

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.InapplicableElm" />, Optional : null when not set</summary>
        /// <remarks>СИ не пригодно</remarks>
        [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.InapplicableElm Inapplicable { get; set; }

        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
        /// <remarks>Наименование документа, на основании которого выполнена поверка</remarks>
        [LxElementValue("docTitle", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
        public System.String DocTitle { get; set; } = "";

        /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
        /// <remarks>Ф.И.О. поверителя</remarks>
        [LxElementValue("metrologist", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
        public System.String Metrologist { get; set; }

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm" />, Required : should not be set to null</summary>
        /// <remarks>Средства поверки</remarks>
        [LxElementRef(MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm Means { get; set; } = new LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm();

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.ConditionsElm" />, Required : should not be set to null</summary>
        /// <remarks>Условия проведения поверки</remarks>
        [LxElementRef(MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.ConditionsElm Conditions { get; set; } = new LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.ConditionsElm();

        /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
        /// <remarks>Состав СИ, представленного на поверку</remarks>
        [LxElementValue("structure", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "1024")]
        public System.String Structure { get; set; }

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.Brief_ProcedureElm" />, Optional : null when not set</summary>
        /// <remarks>Поверка в сокращенном объеме</remarks>
        [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.Brief_ProcedureElm Brief_Procedure { get; set; }

        /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
        /// <remarks>Прочие сведения</remarks>
        [LxElementValue("additional_info", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "1024")]
        public System.String Additional_Info { get; set; }

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.ProtocolElm" />, Optional : null when not set</summary>
        /// <remarks>Протокол поверки</remarks>
        [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.ProtocolElm Protocol { get; set; }

        /// <summary>An enumeration representing XSD simple type type@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19</summary>
        /// <remarks>Признак первичной или периодической поверки</remarks>
        /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:type</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>353:13-377:27</XsdLocation>
        public enum TypeEnum
        {
            /// <summary>Represents the value '1' in the XML</summary>
            [LxEnumValue("1")]
            N1,
            /// <summary>Represents the value '2' in the XML</summary>
            [LxEnumValue("2")]
            N2,
        }
        /// <summary>Represent the inline xs:element miInfo@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
        /// <remarks>Сведения о СИ, применяемом в качестве эталона / СИ</remarks>
        /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:miInfo</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>90:13-318:27</XsdLocation>
        [LxSimpleElementDefinition("miInfo", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
        public partial class MiInfoElm
        {
            /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm" />, Optional : null when not set</summary>
            /// <remarks>СИ, применяемое в качестве эталона</remarks>
            [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
            public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm EtaMI { get; set; }

            /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.SingleMIElm" />, Optional : null when not set</summary>
            /// <remarks>Сведения о единичном СИ</remarks>
            [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
            public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.SingleMIElm SingleMI { get; set; }

            /// <summary>Represent the inline xs:element etaMI@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
            /// <remarks>СИ, применяемое в качестве эталона</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:miInfo/sequence/choice/element:etaMI</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>99:29-250:43</XsdLocation>
            [LxSimpleElementDefinition("etaMI", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
            public partial class EtaMIElm
            {
                /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm.PrimaryRecElm" />, Optional : null when not set</summary>
                /// <remarks>
                ///   <br/>
                ///       Первая поверка СИ, применяемого в качестве эталона<br/>
                ///       Раздел заполняется, если СИ отсутствует в реестре ФИФ ОЕИ<br/>
                ///   
                /// </remarks>
                [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
                public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm.PrimaryRecElm PrimaryRec { get; set; }

                /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                /// <remarks>
                ///   <br/>
                ///       Повторная поверка СИ, применяемого в качестве эталона<br/>
                ///       Регистрационный номер СИ в реестре ФИФ ОЕИ<br/>
                ///   
                /// </remarks>
                [LxElementValue("regNumber", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "32")]
                public System.String RegNumber { get; set; }

                /// <summary>Represent the inline xs:element primaryRec@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
                /// <remarks>
                ///   <br/>
                ///       Первая поверка СИ, применяемого в качестве эталона<br/>
                ///       Раздел заполняется, если СИ отсутствует в реестре ФИФ ОЕИ<br/>
                ///   
                /// </remarks>
                /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:miInfo/sequence/choice/element:etaMI/sequence/choice/element:primaryRec</XsdPath>
                /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
                /// <XsdLocation>108:45-238:59</XsdLocation>
                [LxSimpleElementDefinition("primaryRec", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
                public partial class PrimaryRecElm
                {
                    /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                    /// <remarks>Номер в Госреестре утвержденного типа СИ</remarks>
                    [LxElementValue("mitypeNumber", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "32")]
                    public System.String MitypeNumber { get; set; } = "";

                    /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                    /// <remarks>Модификация СИ</remarks>
                    [LxElementValue("modification", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                    public System.String Modification { get; set; } = "";

                    /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                    /// <remarks>Заводской номер СИ</remarks>
                    [LxElementValue("manufactureNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                    public System.String ManufactureNum { get; set; } = "";

                    /// <summary>A <see cref="LiquidTechnologies.XmlObjects.LxDateTime" />, Required</summary>
                    /// <remarks>Год выпуска СИ</remarks>
                    [LxElementValue("manufactureYear", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdGYear, MinOccurs = 1, MaxOccurs = 1)]
                    public LiquidTechnologies.XmlObjects.LxDateTime ManufactureYear { get; set; }

                    /// <summary>A <see cref="System.Boolean" />, Required</summary>
                    /// <remarks>Поверитель является владельцем СИ, применяемого в качестве эталона</remarks>
                    [LxElementValue("isOwner", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdBoolean, MinOccurs = 1, MaxOccurs = 1)]
                    public System.Boolean IsOwner { get; set; }

                    /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm.PrimaryRecElm.GpsElm" />, Optional : null when not set</summary>
                    /// <remarks>Государственная поверочная схема</remarks>
                    [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
                    public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm.PrimaryRecElm.GpsElm Gps { get; set; }

                    /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm.PrimaryRecElm.LpsElm" />, Optional : null when not set</summary>
                    /// <remarks>Локальная поверочная схема</remarks>
                    [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
                    public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm.PrimaryRecElm.LpsElm Lps { get; set; }

                    /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm.PrimaryRecElm.MpElm" />, Optional : null when not set</summary>
                    /// <remarks>Методики поверки</remarks>
                    [LxElementRef(MinOccurs = 0, MaxOccurs = 1)]
                    public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MiInfoElm.EtaMIElm.PrimaryRecElm.MpElm Mp { get; set; }

                    /// <summary>Represent the inline xs:element gps@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
                    /// <remarks>Государственная поверочная схема</remarks>
                    /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:miInfo/sequence/choice/element:etaMI/sequence/choice/element:primaryRec/sequence/choice/element:gps</XsdPath>
                    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
                    /// <XsdLocation>153:61-184:75</XsdLocation>
                    [LxSimpleElementDefinition("gps", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
                    public partial class GpsElm
                    {
                        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                        /// <remarks>Наименование Государственной поверочной схемы</remarks>
                        [LxElementValue("title", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                        public System.String Title { get; set; } = "";

                        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                        /// <remarks>Регистрационный номер ГПЭ, к которому прослеживается СИ, применяемое в качестве эталона</remarks>
                        [LxElementValue("npeNumber", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "32")]
                        public System.String NpeNumber { get; set; } = "";

                        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                        /// <remarks>Разряд в поверочной схеме</remarks>
                        [LxElementValue("rank", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "32")]
                        public System.String Rank { get; set; } = "";

                    }

                    /// <summary>Represent the inline xs:element lps@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
                    /// <remarks>Локальная поверочная схема</remarks>
                    /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:miInfo/sequence/choice/element:etaMI/sequence/choice/element:primaryRec/sequence/choice/element:lps</XsdPath>
                    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
                    /// <XsdLocation>185:61-216:75</XsdLocation>
                    [LxSimpleElementDefinition("lps", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
                    public partial class LpsElm
                    {
                        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                        /// <remarks>Наименование локальной поверочной схемы</remarks>
                        [LxElementValue("title", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                        public System.String Title { get; set; } = "";

                        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                        /// <remarks>Регистрационный номер ГПЭ, к которому прослеживается СИ, применяемое в качестве эталона</remarks>
                        [LxElementValue("npeNumber", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "32")]
                        public System.String NpeNumber { get; set; } = "";

                        /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                        /// <remarks>Разряд в поверочной схеме</remarks>
                        [LxElementValue("rank", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "32")]
                        public System.String Rank { get; set; } = "";

                    }

                    /// <summary>Represent the inline xs:element mp@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
                    /// <remarks>Методики поверки</remarks>
                    /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:miInfo/sequence/choice/element:etaMI/sequence/choice/element:primaryRec/sequence/choice/element:mp</XsdPath>
                    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
                    /// <XsdLocation>217:61-234:75</XsdLocation>
                    [LxSimpleElementDefinition("mp", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
                    public partial class MpElm
                    {
                        /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                        /// <remarks>Наименования методик поверки</remarks>
                        [LxElementValue("title", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                        public System.String Title { get; set; }

                    }

                }

            }

            /// <summary>Represent the inline xs:element singleMI@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
            /// <remarks>Сведения о единичном СИ</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:miInfo/sequence/choice/element:singleMI</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>251:29-314:43</XsdLocation>
            [LxSimpleElementDefinition("singleMI", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
            public partial class SingleMIElm
            {
                /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                /// <remarks>Номер в Госреестре утвержденного типа СИ</remarks>
                [LxElementValue("mitypeNumber", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "32")]
                public System.String MitypeNumber { get; set; }

                /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                /// <remarks>Метрологическая аттестация: наименование типа СИ</remarks>
                [LxElementValue("crtmitypeTitle", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "512")]
                public System.String CrtmitypeTitle { get; set; }

                /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                /// <remarks>СИ двойного назначения: наименование типа СИ</remarks>
                [LxElementValue("milmitypeTitle", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "512")]
                public System.String MilmitypeTitle { get; set; }

                /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                /// <remarks>Заводской номер СИ</remarks>
                [LxElementValue("manufactureNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                public System.String ManufactureNum { get; set; }

                /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                /// <remarks>Инвентарный номер СИ</remarks>
                [LxElementValue("inventoryNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                public System.String InventoryNum { get; set; }

                /// <summary>A nullable <see cref="LiquidTechnologies.XmlObjects.LxDateTime" />, Optional : null when not set</summary>
                /// <remarks>Год выпуска СИ</remarks>
                [LxElementValue("manufactureYear", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdGYear, MinOccurs = 0, MaxOccurs = 1)]
                public LiquidTechnologies.XmlObjects.LxDateTime? ManufactureYear { get; set; }

                /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                /// <remarks>Модификация СИ</remarks>
                [LxElementValue("modification", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                public System.String Modification { get; set; } = "";

            }

        }

        /// <summary>Represent the inline xs:element applicable@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
        /// <remarks>СИ пригодно</remarks>
        /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/choice/element:applicable</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>386:17-417:31</XsdLocation>
        [LxSimpleElementDefinition("applicable", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
        public partial class ApplicableElm
        {
            /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
            /// <remarks>Номер наклейки</remarks>
            [LxElementValue("stickerNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
            public System.String StickerNum { get; set; }

            /// <summary>A <see cref="System.Boolean" />, Required</summary>
            /// <remarks>Знак поверки в паспорте</remarks>
            [LxElementValue("signPass", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdBoolean, MinOccurs = 1, MaxOccurs = 1)]
            public System.Boolean SignPass { get; set; }

            /// <summary>A <see cref="System.Boolean" />, Required</summary>
            /// <remarks>Знак поверки на СИ</remarks>
            [LxElementValue("signMi", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdBoolean, MinOccurs = 1, MaxOccurs = 1)]
            public System.Boolean SignMi { get; set; }

        }

        /// <summary>Represent the inline xs:element inapplicable@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
        /// <remarks>СИ не пригодно</remarks>
        /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/choice/element:inapplicable</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>418:17-435:31</XsdLocation>
        [LxSimpleElementDefinition("inapplicable", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
        public partial class InapplicableElm
        {
            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            /// <remarks>Причины непригодности</remarks>
            [LxElementValue("reasons", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "1024")]
            public System.String Reasons { get; set; } = "";

        }

        /// <summary>Represent the inline xs:element means@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
        /// <remarks>Средства поверки</remarks>
        /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>451:13-665:27</XsdLocation>
        [LxSimpleElementDefinition("means", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
        public partial class MeansElm
        {
            /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.NpeElm" /></summary>
            /// <remarks>Государственные первичные эталоны</remarks>
            [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
            public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.NpeElm> Npes { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.NpeElm>();

            /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.UveElm" /></summary>
            /// <remarks>Эталоны единицы величины</remarks>
            [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
            public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.UveElm> Uves { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.UveElm>();

            /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.SesElm" /></summary>
            /// <remarks>Стандартные образцы</remarks>
            [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
            public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.SesElm> Sess { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.SesElm>();

            /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MietaElm" /></summary>
            /// <remarks>Средство измерения, применяемое в качестве эталона</remarks>
            [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
            public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MietaElm> Mietas { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MietaElm>();

            /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MisElm" /></summary>
            /// <remarks>Средства измерения, применяемые при поверке</remarks>
            [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
            public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MisElm> Mis { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MisElm>();

            /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.ReagentElm" /></summary>
            /// <remarks>Вещество (материал), применяемый при поверке</remarks>
            [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
            public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.ReagentElm> Reagents { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.ReagentElm>();

            /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.OMethodEnum" /></summary>
            /// <remarks>Доп. методы, использованные при поверке</remarks>
            [LxElementValue("oMethod", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Enum, XsdType.Enum, MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
            public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.OMethodEnum> OMethods { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.OMethodEnum>();

            /// <summary>An enumeration representing XSD simple type oMethod@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19</summary>
            /// <remarks>Доп. методы, использованные при поверке</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:oMethod</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>624:25-662:39</XsdLocation>
            public enum OMethodEnum
            {
                /// <summary>Represents the value '1' in the XML</summary>
                [LxEnumValue("1")]
                N1,
                /// <summary>Represents the value '2' in the XML</summary>
                [LxEnumValue("2")]
                N2,
                /// <summary>Represents the value '3' in the XML</summary>
                [LxEnumValue("3")]
                N3,
                /// <summary>Represents the value '4' in the XML</summary>
                [LxEnumValue("4")]
                N4,
            }
            /// <summary>Represent the inline xs:element npe@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
            /// <remarks>Государственные первичные эталоны</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:npe</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>459:25-476:39</XsdLocation>
            [LxSimpleElementDefinition("npe", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
            public partial class NpeElm
            {
                /// <summary>A collection of <see cref="System.String" /></summary>
                /// <remarks>Номер ГПЭ по реестру</remarks>
                [LxElementValue("number", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = LxConstants.Unbounded, MinLength = "1", MaxLength = "32")]
                public List<System.String> Numbers { get; } = new List<System.String>();

            }

            /// <summary>Represent the inline xs:element uve@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
            /// <remarks>Эталоны единицы величины</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:uve</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>477:25-494:39</XsdLocation>
            [LxSimpleElementDefinition("uve", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
            public partial class UveElm
            {
                /// <summary>A collection of <see cref="System.String" /></summary>
                /// <remarks>Номер эталона по реестру</remarks>
                [LxElementValue("number", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = LxConstants.Unbounded, MinLength = "1", MaxLength = "32")]
                public List<System.String> Numbers { get; } = new List<System.String>();

            }

            /// <summary>Represent the inline xs:element ses@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
            /// <remarks>Стандартные образцы</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:ses</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>495:25-544:39</XsdLocation>
            [LxSimpleElementDefinition("ses", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
            public partial class SesElm
            {
                /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.SesElm.SeElm" /></summary>
                /// <remarks>Стандартный образец</remarks>
                [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
                public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.SesElm.SeElm> Ses { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.SesElm.SeElm>();

                /// <summary>Represent the inline xs:element se@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
                /// <remarks>Стандартный образец</remarks>
                /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:ses/sequence/element:se</XsdPath>
                /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
                /// <XsdLocation>503:37-541:51</XsdLocation>
                [LxSimpleElementDefinition("se", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
                public partial class SeElm
                {
                    /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                    /// <remarks>Номер типа СО по реестру</remarks>
                    [LxElementValue("typeNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                    public System.String TypeNum { get; set; } = "";

                    /// <summary>A <see cref="LiquidTechnologies.XmlObjects.LxDateTime" />, Required</summary>
                    /// <remarks>Год выпуска</remarks>
                    [LxElementValue("manufactureYear", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdGYear, MinOccurs = 1, MaxOccurs = 1)]
                    public LiquidTechnologies.XmlObjects.LxDateTime ManufactureYear { get; set; }

                    /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                    /// <remarks>Заводские номера / Номера партии</remarks>
                    [LxElementValue("manufactureNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                    public System.String ManufactureNum { get; set; }

                    /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                    /// <remarks>Метрологические характеристики СО</remarks>
                    [LxElementValue("metroChars", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "1024")]
                    public System.String MetroChars { get; set; }

                }

            }

            /// <summary>Represent the inline xs:element mieta@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
            /// <remarks>Средство измерения, применяемое в качестве эталона</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:mieta</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>545:25-562:39</XsdLocation>
            [LxSimpleElementDefinition("mieta", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
            public partial class MietaElm
            {
                /// <summary>A collection of <see cref="System.String" /></summary>
                /// <remarks>Номер СИ по реестру</remarks>
                [LxElementValue("number", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = LxConstants.Unbounded, MinLength = "1", MaxLength = "32")]
                public List<System.String> Numbers { get; } = new List<System.String>();

            }

            /// <summary>Represent the inline xs:element mis@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
            /// <remarks>Средства измерения, применяемые при поверке</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:mis</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>563:25-605:39</XsdLocation>
            [LxSimpleElementDefinition("mis", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
            public partial class MisElm
            {
                /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MisElm.MiElm" /></summary>
                /// <remarks>Средство измерения, применяемое при поверке</remarks>
                [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
                public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MisElm.MiElm> Mis { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.MeansElm.MisElm.MiElm>();

                /// <summary>Represent the inline xs:element mi@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
                /// <remarks>Средство измерения, применяемое при поверке</remarks>
                /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:mis/sequence/element:mi</XsdPath>
                /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
                /// <XsdLocation>571:37-602:51</XsdLocation>
                [LxSimpleElementDefinition("mi", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
                public partial class MiElm
                {
                    /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
                    /// <remarks>Регистрационный номер типа СИ</remarks>
                    [LxElementValue("typeNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "32")]
                    public System.String TypeNum { get; set; } = "";

                    /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                    /// <remarks>Заводской номер СИ</remarks>
                    [LxElementValue("manufactureNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                    public System.String ManufactureNum { get; set; }

                    /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
                    /// <remarks>Инвентарный номер СИ</remarks>
                    [LxElementValue("inventoryNum", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
                    public System.String InventoryNum { get; set; }

                }

            }

            /// <summary>Represent the inline xs:element reagent@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
            /// <remarks>Вещество (материал), применяемый при поверке</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:means/choice/element:reagent</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>606:25-623:39</XsdLocation>
            [LxSimpleElementDefinition("reagent", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
            public partial class ReagentElm
            {
                /// <summary>A collection of <see cref="System.String" /></summary>
                /// <remarks>Номер вещества (материала) по реестру</remarks>
                [LxElementValue("number", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = LxConstants.Unbounded, MinLength = "1", MaxLength = "32")]
                public List<System.String> Numbers { get; } = new List<System.String>();

            }

        }

        /// <summary>Represent the inline xs:element conditions@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
        /// <remarks>Условия проведения поверки</remarks>
        /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:conditions</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>666:13-704:27</XsdLocation>
        [LxSimpleElementDefinition("conditions", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
        public partial class ConditionsElm
        {
            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            /// <remarks>Температура</remarks>
            [LxElementValue("temperature", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
            public System.String Temperature { get; set; } = "";

            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            /// <remarks>Атмосферное давление</remarks>
            [LxElementValue("pressure", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
            public System.String Pressure { get; set; } = "";

            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            /// <remarks>Относительная влажность</remarks>
            [LxElementValue("hymidity", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
            public System.String Hymidity { get; set; } = "";

            /// <summary>A <see cref="System.String" />, Optional : null when not set</summary>
            /// <remarks>Другие влияющие факторы</remarks>
            [LxElementValue("other", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 0, MaxOccurs = 1, MinLength = "1", MaxLength = "128")]
            public System.String Other { get; set; }

        }

        /// <summary>Represent the inline xs:element brief_procedure@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
        /// <remarks>Поверка в сокращенном объеме</remarks>
        /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:brief_procedure</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>712:13-729:27</XsdLocation>
        [LxSimpleElementDefinition("brief_procedure", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
        public partial class Brief_ProcedureElm
        {
            /// <summary>A <see cref="System.String" />, Required : should not be set to null</summary>
            /// <remarks>Краткая характеристика объема поверки</remarks>
            [LxElementValue("characteristics", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, MinOccurs = 1, MaxOccurs = 1, MinLength = "1", MaxLength = "1024")]
            public System.String Characteristics { get; set; } = "";

        }

        /// <summary>Represent the inline xs:element protocol@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19.</summary>
        /// <remarks>Протокол поверки</remarks>
        /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:protocol</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>737:13-776:27</XsdLocation>
        [LxSimpleElementDefinition("protocol", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.InlineElement)]
        public partial class ProtocolElm
        {
            /// <summary>The value for the attribute mimetype@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19</summary>
            /// <remarks>Тип файла</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:protocol/attribute:mimetype</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>753:21-767:37</XsdLocation>
            [LxAttribute("mimetype", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Enum, XsdType.Enum, Required = true, WhiteSpace = WhiteSpaceType.Preserve)]
            public LiquidTechnologies.GeneratedLx.Tns.RecInfoCt.ProtocolElm.MimetypeEnum Mimetype { get; set; }

            /// <summary>The value for the attribute filename@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19</summary>
            /// <remarks>Наименование файла</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:protocol/attribute:filename</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>768:21-774:37</XsdLocation>
            [LxAttribute("filename", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdString, Required = true, MinLength = "1", MaxLength = "128")]
            public System.String Filename { get; set; } = "";

            /// <summary>A <see cref="System.Byte" />[], Required : should not be set to null</summary>
            /// <remarks>Содержимое файла протокола поверки</remarks>
            [LxElementValue("content", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", LxValueType.Value, XsdType.XsdBase64Binary, MinOccurs = 1, MaxOccurs = 1)]
            public System.Byte[] Content { get; set; } = new byte[0];

            /// <summary>An enumeration representing XSD simple type mimetype@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19</summary>
            /// <remarks>Тип файла</remarks>
            /// <XsdPath>schema:schema.xsd/complexType:recInfo/sequence/element:protocol/attribute:mimetype</XsdPath>
            /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
            /// <XsdLocation>753:21-767:37</XsdLocation>
            public enum MimetypeEnum
            {
                /// <summary>Represents the value 'application/pdf' in the XML</summary>
                [LxEnumValue("application/pdf")]
                Application_Pdf,
                /// <summary>Represents the value 'application/msword' in the XML</summary>
                [LxEnumValue("application/msword")]
                Application_Msword,
                /// <summary>Represents the value 'application/zip' in the XML</summary>
                [LxEnumValue("application/zip")]
                Application_Zip,
                /// <summary>Represents the value 'image/vnd.djvu' in the XML</summary>
                [LxEnumValue("image/vnd.djvu")]
                Image_Vnd_Djvu,
            }
        }

    }

    #endregion

    #region Elements
    /// <summary>A class representing the root XSD element application@urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19</summary>
    /// <remarks>Заявка на публикацию сведений о результатах поверки СИ</remarks>
    /// <XsdPath>schema:schema.xsd/element:application</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>15:5-32:19</XsdLocation>
    [LxSimpleElementDefinition("application", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", ElementScopeType.GlobalElement)]
    public partial class ApplicationElm
    {
        /// <summary>
        ///   A class derived from <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt" />.<br/><br/>
        ///   Allowable types are <br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Tns.RecInfoCt" />
        /// </summary>
        /// <remarks>Сведения о результатах поверки СИ</remarks>
        [LxElementCt("result", "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19", MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
        public List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt> Results { get; } = new List<LiquidTechnologies.GeneratedLx.Tns.RecInfoCt>();

    }

    #endregion

}

namespace LiquidTechnologies.GeneratedLx
{
    public static class NamespaceRegistrationExtension
    {
        /// <summary>
        /// Adds all the namespaces defined within the schema to the <paramref name="settings"/> objects namespace map.
        /// </summary>
        /// <remarks>
        /// Any existing namespace mappings that clash are overwritten.
        /// </remarks>
        public static void AddDefaultNamespaces(this LiquidTechnologies.XmlObjects.LxWriterSettings settings) 
        {
            settings.NamespaceMap["tns"] = "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19";
            settings.NamespaceMap["xsd"] = "http://www.w3.org/2001/XMLSchema";
        }
    }
}