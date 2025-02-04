using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLAktarma
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // XML dosyasının yolunu belirtin
            string xmlFilePath = "Police.xml";

            // XmlDocument sınıfıyla XML dosyasını yükleyin
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFilePath);

                // Örnek: XML dosyasındaki belirli bir öğeyi seçin ve değerini yazdırın
                XmlNodeList Policeler = xmlDoc.SelectNodes("//Police"); // elementName, okumak istediğiniz XML öğesinin adıdır
                foreach (XmlNode Police in Policeler)
                {
                    

                    //XmlNodeList SigortaEttirenler = Police.SelectNodes("//SigortaEttiren");

                    //foreach (XmlNode SigortaEttiren in SigortaEttirenler)
                    //{

                    //    Console.WriteLine(SigortaEttiren["AdSoyadUnvan"].InnerText);

                    //}

                    //-----------------
                    // Police öğesinin içerisindeki SigortaEttirenler bilgilerine erişmek için XPath ifadesi kullanılır.
                    XmlNodeList sigortaEttirenlerList = Police.SelectNodes("SigortaEttirenler/SigortaEttiren");

                    foreach (XmlNode sigortaEttiren in sigortaEttirenlerList)
                    {
                        XmlNode musteriKoduNode = sigortaEttiren.SelectSingleNode("MusteriKodu");
                        if (musteriKoduNode != null)
                        {
                            Console.WriteLine("MusteriKodu: " + musteriKoduNode.InnerText);
                        }

                        // Diğer SigortaEttiren bilgilerine de benzer şekilde erişebilirsiniz.
                        // Örneğin: AdSoyadUnvan, Uyruk, MukellefTuru vb.
                    }

                    //----------------


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            Console.ReadLine();

        }
    }
}
