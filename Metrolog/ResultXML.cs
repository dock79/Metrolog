/*
 * Created by SharpDevelop.
 * User: yudin.sv
 * Date: 05.08.2021
 * Time: 13:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Xml;

namespace Metrolog
{
    /// <summary>
    /// Создает xml элемент result на основе передаваемого класса recInfo
    /// </summary>
    public class ResultXml
    {
        public ResultXml()
        {
            result = new recInfo();
            xmlDoc = new XmlDocument();
        }

        public ResultXml(XmlDocument xmlDocument)
        {
            result = new recInfo();
            xmlDoc = xmlDocument;
        }

        public recInfo result { get; set; }

        private XmlDocument xmlDoc { get; set; }

        public XmlElement CreateResult(XmlDocument xmlDocument)
        {
            xmlDoc = xmlDocument;
            XmlElement resultElement = xmlDoc.CreateElement("result");

            try
            {
                // Получаем данные из перовой формы
                XmlElement xmlElement = CreatemiInfoSection();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                // Получаем данные из второй формы
                xmlElement = Create_signCipher_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                xmlElement = Create_miOwner_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                xmlElement = Create_vrfDate_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                if (result.type != recInfoType.Item1)
                {
                    xmlElement = Create_validDate_Section();
                    if (xmlElement != null) resultElement.AppendChild(xmlElement);
                }

                xmlElement = Create_type_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                xmlElement = Create_calibration_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                xmlElement = Create_app_inapplicable_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                xmlElement = Create_docTitle_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                xmlElement = Create_metrologist_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                // Получаем данные из третьей формы
                xmlElement = Create_means_Section();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                // Получаем данные из четвертой формы
                xmlElement = CreateconditionsSection();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                xmlElement = CreatestructureSection();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                if (result.IsBriefProcedure)
                {
                    xmlElement = Createbrief_procedureSection();
                    if (xmlElement != null) resultElement.AppendChild(xmlElement);
                }

                xmlElement = Createadditional_infoSection();
                if (xmlElement != null) resultElement.AppendChild(xmlElement);

                if (result.IsProtocol)
                {
                    xmlElement = CreateprotocolSection();
                    if (xmlElement != null) resultElement.AppendChild(xmlElement);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            return resultElement;
        }

        private XmlElement CreatemiInfoSection()
        {
            XmlElement miInfoElement = xmlDoc.CreateElement("miInfo");

            if (result.miInfo.Type == MIType.etaMI)
            {
                XmlElement etaMIElement = CreateetaMISection();
                miInfoElement.AppendChild(etaMIElement);
                return miInfoElement;
            }
            else if (result.miInfo.Type == MIType.singleMI)
            {
                XmlElement singleMIElement = CreatesingleMISection();
                miInfoElement.AppendChild(singleMIElement);
                return miInfoElement;
            }

            return miInfoElement;
        }

        private XmlElement CreateetaMISection()
        {
            XmlElement etaMIElement = xmlDoc.CreateElement("etaMI");

            if (result.miInfo.etaMI.Type == etaMIType.primaryRec)
            {
                XmlElement primaryRecElement = xmlDoc.CreateElement("primaryRec");
                etaMIElement.AppendChild(primaryRecElement);

                XmlElement mitypeNumberElement = xmlDoc.CreateElement("mitypeNumber");
                if (!String.IsNullOrWhiteSpace(result.miInfo.etaMI.primaryRec.mitypeNumber))
                {
                    mitypeNumberElement.InnerText = result.miInfo.etaMI.primaryRec.mitypeNumber.Trim();
                    //result.miInfo.etaMI.primaryRec.mitypeNumber = result.miInfo.etaMI.primaryRec.mitypeNumber.Trim();// Добавить здесь проверку на null
                    primaryRecElement.AppendChild(mitypeNumberElement);
                }

                XmlElement modificationElement = xmlDoc.CreateElement("modification");
                if (!String.IsNullOrWhiteSpace(result.miInfo.etaMI.primaryRec.modification))
                {
                    modificationElement.InnerText = result.miInfo.etaMI.primaryRec.modification.Trim();
                    primaryRecElement.AppendChild(modificationElement);
                }

                XmlElement manufactureNumElement = xmlDoc.CreateElement("manufactureNum");
                if (!String.IsNullOrWhiteSpace(result.miInfo.etaMI.primaryRec.manufactureNum))
                {
                    manufactureNumElement.InnerText = result.miInfo.etaMI.primaryRec.manufactureNum.Trim();
                    primaryRecElement.AppendChild(manufactureNumElement);
                }

                XmlElement manufactureYearElement = xmlDoc.CreateElement("manufactureYear");
                if (!String.IsNullOrWhiteSpace(result.miInfo.etaMI.primaryRec.manufactureYear))
                {
                    manufactureYearElement.InnerText = result.miInfo.etaMI.primaryRec.manufactureYear.Trim();
                    primaryRecElement.AppendChild(manufactureYearElement);
                }

                XmlElement isOwnerElement = xmlDoc.CreateElement("isOwner");
                isOwnerElement.InnerText = result.miInfo.etaMI.primaryRec.isOwner.ToString().ToLower();
                primaryRecElement.AppendChild(isOwnerElement);

                #region

                if (result.miInfo.etaMI.primaryRec.IsPS)
                {
                    XmlElement psElement = xmlDoc.CreateElement(result.miInfo.etaMI.primaryRec.ps.Type.ToString());

                    XmlElement titleElement = xmlDoc.CreateElement("title");
                    if (!String.IsNullOrWhiteSpace(result.miInfo.etaMI.primaryRec.ps.title))
                    {
                        titleElement.InnerText = result.miInfo.etaMI.primaryRec.ps.title.Trim();
                        psElement.AppendChild(titleElement);
                    }

                    XmlElement npeNumberElement = xmlDoc.CreateElement("npeNumber");
                    if (!String.IsNullOrWhiteSpace(result.miInfo.etaMI.primaryRec.ps.npeNumber))
                    {
                        npeNumberElement.InnerText = result.miInfo.etaMI.primaryRec.ps.npeNumber.Trim();
                        psElement.AppendChild(npeNumberElement);
                    }

                    XmlElement rankElement = xmlDoc.CreateElement("rank");
                    rankElement.InnerText = EnumHelper.GetDescription(result.miInfo.etaMI.primaryRec.ps.rank);
                    psElement.AppendChild(rankElement);

                    primaryRecElement.AppendChild(psElement);
                }
                else
                {
                    XmlElement mpElement = xmlDoc.CreateElement("mp");

                    XmlElement mptitleElement = xmlDoc.CreateElement("title");
                    if (!String.IsNullOrWhiteSpace(result.miInfo.etaMI.primaryRec.mp.title))
                    {
                        mptitleElement.InnerText = result.miInfo.etaMI.primaryRec.mp.title.Trim();
                        mpElement.AppendChild(mptitleElement);

                        primaryRecElement.AppendChild(mpElement);
                    }
                }

                #endregion

                return etaMIElement;
            }
            else if (result.miInfo.etaMI.Type == etaMIType.regNumber)
            {
                XmlElement regNumberElement = xmlDoc.CreateElement("regNumber");
                if (!String.IsNullOrWhiteSpace(result.miInfo.etaMI.regNumber.regNumber))
                {
                    regNumberElement.InnerText = result.miInfo.etaMI.regNumber.regNumber.Trim();
                    etaMIElement.AppendChild(regNumberElement);
                }

                return etaMIElement;
            }

            return etaMIElement;
        }

        private XmlElement CreatesingleMISection()
        {
            XmlElement singleMIElement = xmlDoc.CreateElement("singleMI");

            #region

            // Секция СИ специального назначения: наименование СИ, Заводской номер СИ, Буквенно-цифровое обозначение            	
            if (result.miInfo.singleMI.Item1Type == Item1ChoiceType.mitypeNumber)
            {
                XmlElement mitypeNumberElement = xmlDoc.CreateElement("mitypeNumber");
                if (!String.IsNullOrWhiteSpace(result.miInfo.singleMI.mitypeNumber))
                {
                    mitypeNumberElement.InnerText = result.miInfo.singleMI.mitypeNumber.Trim();
                    singleMIElement.AppendChild(mitypeNumberElement);
                }
            }

            if (result.miInfo.singleMI.Item1Type == Item1ChoiceType.crtmitypeTitle)
            {
                XmlElement crtmitypeTitleElement = xmlDoc.CreateElement("crtmitypeTitle");
                if (!String.IsNullOrWhiteSpace(result.miInfo.singleMI.crtmitypeTitle))
                {
                    crtmitypeTitleElement.InnerText = result.miInfo.singleMI.crtmitypeTitle.Trim();
                    singleMIElement.AppendChild(crtmitypeTitleElement);
                }
            }

            if (result.miInfo.singleMI.Item1Type == Item1ChoiceType.milmitypeTitle)
            {
                XmlElement milmitypeTitleElement = xmlDoc.CreateElement("milmitypeTitle");
                if (!String.IsNullOrWhiteSpace(result.miInfo.singleMI.milmitypeTitle))
                {
                    milmitypeTitleElement.InnerText = result.miInfo.singleMI.milmitypeTitle.Trim();
                    singleMIElement.AppendChild(milmitypeTitleElement);
                }
            }

            #endregion

            #region

            //Секция Заводской номер СИ и Буквенно-цифровое обозначение 
            if (result.miInfo.singleMI.Item2Type == Item2ChoiceType.manufactureNum)
            {
                XmlElement manufactureNumElement = xmlDoc.CreateElement("manufactureNum");
                if (!String.IsNullOrWhiteSpace(result.miInfo.singleMI.manufactureNum))
                {
                    manufactureNumElement.InnerText = result.miInfo.singleMI.manufactureNum.Trim();
                    singleMIElement.AppendChild(manufactureNumElement);
                }
            }

            if (result.miInfo.singleMI.Item2Type == Item2ChoiceType.inventoryNum)
            {
                XmlElement inventoryNumElement = xmlDoc.CreateElement("inventoryNum");
                if (!String.IsNullOrWhiteSpace(result.miInfo.singleMI.inventoryNum))
                {
                    inventoryNumElement.InnerText = result.miInfo.singleMI.inventoryNum.Trim();
                    singleMIElement.AppendChild(inventoryNumElement);
                }
            }

            #endregion

            XmlElement manufactureYearElement = xmlDoc.CreateElement("manufactureYear");
            if (!String.IsNullOrWhiteSpace(result.miInfo.singleMI.manufactureYear))
            {
                manufactureYearElement.InnerText = result.miInfo.singleMI.manufactureYear.Trim();
                singleMIElement.AppendChild(manufactureYearElement);
            }

            XmlElement modificationElement = xmlDoc.CreateElement("modification");
            if (!String.IsNullOrWhiteSpace(result.miInfo.singleMI.modification))
            {
                modificationElement.InnerText = result.miInfo.singleMI.modification.Trim();
                singleMIElement.AppendChild(modificationElement);
            }

            return singleMIElement;
        }

        private XmlElement Create_signCipher_Section()
        {
            XmlElement signCipherElement = xmlDoc.CreateElement("signCipher");
            if (!String.IsNullOrWhiteSpace(result.signCipher))
            {
                signCipherElement.InnerText = result.signCipher.Trim();
                return signCipherElement;
            }

            return null;
        }

        private XmlElement Create_miOwner_Section()
        {
            XmlElement miOwnerElement = xmlDoc.CreateElement("miOwner");
            if (!String.IsNullOrWhiteSpace(result.miOwner))
            {
                miOwnerElement.InnerText = result.miOwner.Trim();
                return miOwnerElement;
            }

            return null;
        }

        private XmlElement Create_vrfDate_Section()
        {
            XmlElement vrfDateElement = xmlDoc.CreateElement("vrfDate");
            //MessageBox.Show(result.vrfDate.Value.ToString("yyyy-mm-dd"));
            if (result.vrfDate != null)
            {
                vrfDateElement.InnerText = result.vrfDate.Value.ToString("yyyy-MM-dd");
                return vrfDateElement;
            }

            return null;
        }

        private XmlElement Create_validDate_Section()
        {
            XmlElement validDateElement = xmlDoc.CreateElement("validDate");
            if (result.validDate != null)
            {
                validDateElement.InnerText = result.validDate.Value.ToString("yyyy-MM-dd");
                return validDateElement;
            }

            return null;
        }

        private XmlElement Create_type_Section()
        {
            XmlElement typeElement = xmlDoc.CreateElement("type");
            typeElement.InnerText = ((int) (result.type)).ToString();
            return typeElement;
        }

        private XmlElement Create_calibration_Section()
        {
            XmlElement calibrationElement = xmlDoc.CreateElement("calibration");
            calibrationElement.InnerText = result.calibration.ToString().ToLower();
            return calibrationElement;
        }

        private XmlElement Create_applicable_Section()
        {
            XmlElement applicableElement = xmlDoc.CreateElement("applicable");

            XmlElement stickerNumElement = xmlDoc.CreateElement("stickerNum");
            if (!String.IsNullOrWhiteSpace(result.applicable.stickerNum))
            {
                stickerNumElement.InnerText = result.applicable.stickerNum.Trim();
                applicableElement.AppendChild(stickerNumElement);
            }

            XmlElement signPassElement = xmlDoc.CreateElement("signPass");
            signPassElement.InnerText = result.applicable.signPass.ToString().ToLower();
            applicableElement.AppendChild(signPassElement);

            XmlElement signMiElement = xmlDoc.CreateElement("signMi");
            signMiElement.InnerText = result.applicable.signMi.ToString().ToLower();
            applicableElement.AppendChild(signMiElement);

            return applicableElement;
        }

        private XmlElement Create_inapplicable_Section()
        {
            XmlElement inapplicableElement = xmlDoc.CreateElement("inapplicable");
            XmlElement reasonsElement = xmlDoc.CreateElement("reasons");
            if (!String.IsNullOrWhiteSpace(result.inapplicable.reasons))
            {
                reasonsElement.InnerText = result.inapplicable.reasons.Trim();
                inapplicableElement.AppendChild(reasonsElement);
                return inapplicableElement;
            }

            return null;
        }

        private XmlElement Create_app_inapplicable_Section()
        {
            if (result.ApplicableType == ApplicableType.applicable)
            {
                XmlElement applicableElement = Create_applicable_Section();
                return applicableElement;
            }

            if (result.ApplicableType == ApplicableType.inapplicable)
            {
                XmlElement inapplicableElement = Create_inapplicable_Section();
                return inapplicableElement;
            }

            return null;
        }

        private XmlElement Create_docTitle_Section()
        {
            XmlElement docTitleElement = xmlDoc.CreateElement("docTitle");
            if (!String.IsNullOrWhiteSpace(result.docTitle))
            {
                docTitleElement.InnerText = result.docTitle.Trim();
                return docTitleElement;
            }

            return null;
        }

        private XmlElement Create_metrologist_Section()
        {
            XmlElement metrologistElement = xmlDoc.CreateElement("metrologist");
            if (!String.IsNullOrWhiteSpace(result.metrologist))
            {
                metrologistElement.InnerText = result.metrologist.Trim();
                return metrologistElement;
            }

            return null;
        }

        private XmlElement Create_means_Section()
        {
            XmlElement meansElement = xmlDoc.CreateElement("means");

            if (result.means.npe.Count != 0)
            {
                XmlElement npe = Create_npe_Section();
                meansElement.AppendChild(npe);
            }

            if (result.means.uve.Count != 0)
            {
                XmlElement uve = Create_uve_Section();
                meansElement.AppendChild(uve);
            }

            if (result.means.ses.Count != 0)
            {
                XmlElement ses = Create_ses_Section();
                meansElement.AppendChild(ses);
            }

            if (result.means.mieta.Count != 0)
            {
                XmlElement mieta = Create_mieta_Section();
                meansElement.AppendChild(mieta);
            }

            if (result.means.mis.Count != 0)
            {
                XmlElement mis = Create_mis_Section();
                meansElement.AppendChild(mis);
            }

            if (result.means.reagent.Count != 0)
            {
                XmlElement reagent = Create_reagent_Section();
                if (reagent != null) meansElement.AppendChild(reagent);
            }

            if (result.means.IsoMethod)
            {
                XmlElement oMethod = Create_oMethod_Section();
                meansElement.AppendChild(oMethod);
            }

            return meansElement;
        }

        private XmlElement Create_npe_Section()
        {
            XmlElement npeElement = xmlDoc.CreateElement("npe");
            foreach (var n in result.means.npe)
            {
                XmlElement numberElement = xmlDoc.CreateElement("number");
                if (!String.IsNullOrWhiteSpace(n.number))
                {
                    numberElement.InnerText = n.number.Trim();
                    npeElement.AppendChild(numberElement);
                }
            }

            return npeElement;
        }

        private XmlElement Create_uve_Section()
        {
            XmlElement uveElement = xmlDoc.CreateElement("uve");

            foreach (var n in result.means.uve)
            {
                XmlElement numberElement = xmlDoc.CreateElement("number");
                if (!String.IsNullOrWhiteSpace(n.number))
                {
                    numberElement.InnerText = n.number.Trim();
                    uveElement.AppendChild(numberElement);
                }
            }

            return uveElement;
        }

        private XmlElement Create_ses_Section()
        {
            XmlElement sesElement = xmlDoc.CreateElement("ses");

            foreach (var se in result.means.ses)
            {
                // СМоздание элемента se
                XmlElement seElement = xmlDoc.CreateElement("se");

                XmlElement typeNumElement = xmlDoc.CreateElement("typeNum");
                if (!String.IsNullOrWhiteSpace(se.typeNum))
                {
                    typeNumElement.InnerText = se.typeNum.Trim();
                    seElement.AppendChild(typeNumElement);
                }

                XmlElement manufactureYearElement = xmlDoc.CreateElement("manufactureYear");
                if (!String.IsNullOrWhiteSpace(se.manufactureYear))
                {
                    manufactureYearElement.InnerText = se.manufactureYear.Trim();
                    seElement.AppendChild(manufactureYearElement);
                }

                XmlElement manufactureNumElement = xmlDoc.CreateElement("manufactureNum");
                if (!String.IsNullOrWhiteSpace(se.manufactureNum))
                {
                    manufactureNumElement.InnerText = se.manufactureNum.Trim();
                    seElement.AppendChild(manufactureNumElement);
                }

                XmlElement metroCharsElement = xmlDoc.CreateElement("metroChars");
                if (!String.IsNullOrWhiteSpace(se.metroChars))
                {
                    metroCharsElement.InnerText = se.metroChars.Trim();
                    seElement.AppendChild(metroCharsElement);
                }

                sesElement.AppendChild(seElement);
            }

            return sesElement;
        }

        private XmlElement Create_mieta_Section()
        {
            XmlElement mietaElement = xmlDoc.CreateElement("mieta");

            foreach (var n in result.means.mieta)
            {
                XmlElement numberElement = xmlDoc.CreateElement("number");
                if (!String.IsNullOrWhiteSpace(n.number))
                {
                    numberElement.InnerText = n.number.Trim();
                    mietaElement.AppendChild(numberElement);
                }
            }

            return mietaElement;
        }

        private XmlElement Create_mis_Section()
        {
            XmlElement misElement = xmlDoc.CreateElement("mis");

            foreach (var mi in result.means.mis)
            {
                // Создание элемента mi
                XmlElement miElement = xmlDoc.CreateElement("mi");

                XmlElement typeNumElement = xmlDoc.CreateElement("typeNum");
                if (!String.IsNullOrWhiteSpace(mi.typeNum))
                {
                    typeNumElement.InnerText = mi.typeNum.Trim();
                    miElement.AppendChild(typeNumElement);
                }

                if (mi.Type == Item2ChoiceType.manufactureNum)
                {
                    XmlElement manufactureNumElement = xmlDoc.CreateElement("manufactureNum");
                    if (!String.IsNullOrWhiteSpace(mi.manufactureNum))
                    {
                        manufactureNumElement.InnerText = mi.manufactureNum.Trim();
                        miElement.AppendChild(manufactureNumElement);
                    }
                }
                else
                {
                    XmlElement inventoryNumElement = xmlDoc.CreateElement("inventoryNum");
                    if (!String.IsNullOrWhiteSpace(mi.inventoryNum))
                    {
                        inventoryNumElement.InnerText = mi.inventoryNum.Trim();
                        miElement.AppendChild(inventoryNumElement);
                    }
                }

                misElement.AppendChild(miElement);
            }

            return misElement;
        }

        private XmlElement Create_reagent_Section()
        {
            XmlElement reagentElement = xmlDoc.CreateElement("reagent");

            foreach (var n in result.means.reagent)
            {
                XmlElement numberElement = xmlDoc.CreateElement("number");
                if (!String.IsNullOrWhiteSpace(n.number))
                {
                    numberElement.InnerText = n.number.Trim();
                    reagentElement.AppendChild(numberElement);
                }
            }

            return reagentElement;
        }

        private XmlElement Create_oMethod_Section()
        {
            XmlElement oMethodElement = xmlDoc.CreateElement("oMethod");
            if ((result.means.oMethod != null) && result.means.IsoMethod)
                oMethodElement.InnerText = ((int) result.means.oMethod).ToString();
            return oMethodElement;
        }

        private XmlElement CreateconditionsSection()
        {
            XmlElement conditionsElement = xmlDoc.CreateElement("conditions");

            XmlElement temperatureElement = xmlDoc.CreateElement("temperature");
            if (!String.IsNullOrWhiteSpace(result.conditions.temperature))
            {
                temperatureElement.InnerText = result.conditions.temperature.Trim();
                conditionsElement.AppendChild(temperatureElement);
            }

            XmlElement pressureElement = xmlDoc.CreateElement("pressure");
            if (!String.IsNullOrWhiteSpace(result.conditions.pressure))
            {
                pressureElement.InnerText = result.conditions.pressure.Trim();
                conditionsElement.AppendChild(pressureElement);
            }

            XmlElement hymidityElement = xmlDoc.CreateElement("hymidity");
            if (!String.IsNullOrWhiteSpace(result.conditions.hymidity))
            {
                hymidityElement.InnerText = result.conditions.hymidity.Trim();
                conditionsElement.AppendChild(hymidityElement);
            }

            XmlElement otherElement = xmlDoc.CreateElement("other");
            if (!String.IsNullOrWhiteSpace(result.conditions.other))
            {
                otherElement.InnerText = result.conditions.other.Trim();
                conditionsElement.AppendChild(otherElement);
            }

            return conditionsElement;
        }

        private XmlElement CreatestructureSection()
        {
            XmlElement conditionsElement = xmlDoc.CreateElement("structure");
            if (!String.IsNullOrWhiteSpace(result.structure))
            {
                conditionsElement.InnerText = result.structure.Trim();
                return conditionsElement;
            }

            return null;
        }

        private XmlElement Createbrief_procedureSection()
        {
            XmlElement brief_procedureElement = xmlDoc.CreateElement("brief_procedure");
            XmlElement characteristicsElement = xmlDoc.CreateElement("characteristics");
            if (!String.IsNullOrWhiteSpace(result.brief_procedure.characteristics))
            {
                characteristicsElement.InnerText = result.brief_procedure.characteristics.Trim();
                brief_procedureElement.AppendChild(characteristicsElement);
                return brief_procedureElement;
            }

            return null;
        }

        private XmlElement Createadditional_infoSection()
        {
            XmlElement additional_infoElement = xmlDoc.CreateElement("additional_info");
            if (!String.IsNullOrWhiteSpace(result.additional_info))
            {
                additional_infoElement.InnerText = result.additional_info.Trim();
                return additional_infoElement;
            }

            return null;
        }

        private XmlElement CreateprotocolSection()
        {
            XmlElement protocolElement = xmlDoc.CreateElement("protocol");

            if (!String.IsNullOrWhiteSpace(result.protocol.filename))
                protocolElement.SetAttribute("filename", result.protocol.filename);
            if (result.protocol.mimetype != null)
                protocolElement.SetAttribute("mimetype", NullableEnumHelper.GetDescription(result.protocol.mimetype));

            XmlElement contentElement = xmlDoc.CreateElement("content");

            //ЗДЕСЬ ДОБАВИТЬ ДВОИЧНЫЕ ДАННЫЕ ИЗ ФАЙЛА. СДЕЛАЛ В КОДИРОВКЕ 64. ВРОДЕ РАБОТАЕТ. ОБРАТНО ТОЖЕ НАДО СДЕЛАТЬ ДЕКОДИРОВКУ.
            if (result.protocol.content != null)
                contentElement.InnerText = Convert.ToBase64String(result.protocol.content);
            //if (protocol.contentString != null) contentElement.InnerText = protocol.contentString;

            // Некоторые файлы почему-то не добавляются с помощью InnerText, может из-за большого размера, с помощью просто записи текстовой строки. Нужно найти в файле место и вставить строку.
            // Пока задокументировал			
            /*TextWriter tw = new StreamWriter("serioz33333333.txt");
            tw.WriteLine(protocol.contentString);
            tw.Close();*/
            //XmlText text = xmlDoc.CreateTextNode(protocol.contentString);   
            //contentElement.AppendChild(text);			

            protocolElement.AppendChild(contentElement);
            return protocolElement;
        }

        public static recInfo CreateResultCopy(recInfo source)
        {
            //recInfo copyresult = new recInfo();
            //res.CopyTo(copyresult);
            recInfo copyresult = source.DeepCopy();

            if (copyresult.miInfo.Type == MIType.etaMI)
            {
                if (copyresult.miInfo.etaMI.Type == etaMIType.primaryRec)
                {
                    #region

                    //Секция с поверочными схемами					
                    if (copyresult.miInfo.etaMI.primaryRec.IsPS)
                    {
                        copyresult.miInfo.etaMI.primaryRec.mp = new recInfoMiInfoEtaMIPrimaryRecMP();
                    }
                    else
                    {
                        copyresult.miInfo.etaMI.primaryRec.ps = new recInfoMiInfoEtaMIPrimaryRecPs();
                        //copyresult.miInfo.etaMI.primaryRec.mp = new recInfoMiInfoEtaMIPrimaryRecMP();
                        //copyresult.miInfo.etaMI.primaryRec.Type = PSType.mp;				
                    }

                    #endregion

                    copyresult.miInfo.etaMI.regNumber = new recInfoMiInfoEtaMIRegNumber();
                }
                else if (copyresult.miInfo.etaMI.Type == etaMIType.regNumber)
                {
                    copyresult.miInfo.etaMI.primaryRec = new recInfoMiInfoEtaMIPrimaryRec();
                }

                copyresult.miInfo.singleMI = new recInfoMiInfoSingleMI();
            }
            else if (copyresult.miInfo.Type == MIType.singleMI)
            {
                //recInfoMiInfoSingleMI newsingleMI = new recInfoMiInfoSingleMI();	

                #region

                // Секция СИ специального назначения: наименование СИ, Заводской номер СИ, Буквенно-цифровое обозначение       	
                switch (copyresult.miInfo.singleMI.Item1Type)
                {
                    case Item1ChoiceType.mitypeNumber:
                        copyresult.miInfo.singleMI.crtmitypeTitle = String.Empty;
                        copyresult.miInfo.singleMI.milmitypeTitle = String.Empty;
                        break;
                    case Item1ChoiceType.crtmitypeTitle:
                        copyresult.miInfo.singleMI.mitypeNumber = String.Empty;
                        copyresult.miInfo.singleMI.milmitypeTitle = String.Empty;
                        break;
                    case Item1ChoiceType.milmitypeTitle:
                        copyresult.miInfo.singleMI.mitypeNumber = String.Empty;
                        copyresult.miInfo.singleMI.crtmitypeTitle = String.Empty;
                        break;
                }

                #endregion

                #region

                //Секция Заводской номер СИ и Буквенно-цифровое обозначение        
                switch (copyresult.miInfo.singleMI.Item2Type)
                {
                    case Item2ChoiceType.manufactureNum:
                        copyresult.miInfo.singleMI.inventoryNum = String.Empty;
                        break;
                    case Item2ChoiceType.inventoryNum:
                        copyresult.miInfo.singleMI.manufactureNum = String.Empty;
                        break;
                }

                #endregion

                copyresult.miInfo.etaMI = new recInfoMiInfoEtaMI();
            }

            if (copyresult.ApplicableType == ApplicableType.applicable)
            {
                copyresult.inapplicable = new recInfoInapplicable();
            }
            else if (copyresult.ApplicableType == ApplicableType.inapplicable)
            {
                copyresult.applicable = new recInfoApplicable();
            }

            if (!copyresult.means.IsoMethod)
            {
                copyresult.means.oMethod = recInfoOMethod.Item1;
            }

            if (!copyresult.IsBriefProcedure) copyresult.brief_procedure = new recInfoBrief_procedure();

            if (!copyresult.IsProtocol) copyresult.protocol = new recInfoProtocol();

            return copyresult;
        }
    }
}