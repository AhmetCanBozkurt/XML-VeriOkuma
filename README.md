# XML Aktarma ve Okuma DLL

Bu proje, bir XML dosyasındaki belirli öğeleri okuyup işlemek için kullanılan bir sınıf içerir. XML dosyasından belirli verileri çekmek için `XmlDocument` sınıfı ve XPath ifadeleri kullanılır. Örneğin, bir sigorta poliçesindeki sigorta ettirenlerin bilgilerini çıkarabilirsiniz.

## Özellikler

- XML dosyasındaki belirli öğeleri okumak için XPath ifadeleri kullanılır.
- Sigorta poliçesindeki `SigortaEttiren` bilgilerine kolayca erişim sağlanır.
- Her `SigortaEttiren` öğesinin altında yer alan `MusteriKodu` gibi verilere ulaşılır.
- XML dosyasındaki öğeler `XmlNodeList` ile sırasıyla okunur.

## Kullanım

1. **XMLAktarma** sınıfını projenize dahil edin.
2. `XmlDocument` sınıfını kullanarak XML dosyasını yükleyin.
3. XPath ifadeleriyle XML dosyasındaki öğelere erişin.

### Örnek Kullanım

```csharp
using XMLAktarma;

class Program
{
    static void Main()
    {
        // XML dosyasının yolu
        string xmlFilePath = "Police.xml";

        // XML dosyasındaki verileri okuma işlemi
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            // XML dosyasını yükle
            xmlDoc.Load(xmlFilePath);

            // Police öğelerini seç
            XmlNodeList Policeler = xmlDoc.SelectNodes("//Police");

            foreach (XmlNode Police in Policeler)
            {
                // SigortaEttirenler altındaki SigortaEttiren öğelerini seç
                XmlNodeList sigortaEttirenlerList = Police.SelectNodes("SigortaEttirenler/SigortaEttiren");

                foreach (XmlNode sigortaEttiren in sigortaEttirenlerList)
                {
                    // MusteriKodu bilgisini yazdır
                    XmlNode musteriKoduNode = sigortaEttiren.SelectSingleNode("MusteriKodu");
                    if (musteriKoduNode != null)
                    {
                        Console.WriteLine("MusteriKodu: " + musteriKoduNode.InnerText);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }

        Console.ReadLine();
    }
}
