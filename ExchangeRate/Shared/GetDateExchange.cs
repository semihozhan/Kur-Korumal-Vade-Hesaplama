using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ExchangeRate.Shared
{
    public static class GetDateExchange
    {
        public static string GetExchangeRate(string exchangeDate)
        {
            if(exchangeDate==null || exchangeDate == "")
            {
                exchangeDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            string[] datePart = exchangeDate.Split("-");
            string yilAy = datePart[0] + "" + datePart[1];
            string gunAyYil = datePart[2] + "" + datePart[1] + "" + datePart[0];
            string startDate = "https://www.tcmb.gov.tr/kurlar/"+ yilAy + "/"+ gunAyYil + ".xml";
            var xmlDocument = new XmlDocument();
            string usdAlis;
            try
            {
                xmlDocument.Load(startDate);
                usdAlis=xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            }
            catch (Exception)
            {

                usdAlis = string.Empty;
            }
            
            return usdAlis;
        }

    }
}
