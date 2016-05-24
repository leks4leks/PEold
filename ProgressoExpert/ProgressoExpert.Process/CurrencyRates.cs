using ProgressoExpert.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProgressoExpert.Process
{
    public static class CurrencyRates
    {
        public static List<CurrencyRate> GetExchangeRates()
        {
            List<CurrencyRate> result = new List<CurrencyRate>();
            XmlReader reader = new XmlTextReader(@"http://www.nationalbank.kz/rss/rates_all.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "item")
                {
                    if (reader.Name == "item")
                    {
                        var currency = new CurrencyRate();
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                if (reader.Name == "title")
                                {
                                    reader.Read();
                                    if (reader.Value != "USD" && reader.Value != "RUB" && reader.Value != "EUR")
                                    {
                                        break;
                                    }
                                    currency.Name = reader.Value;
                                }
                                if (reader.Name == "description")
                                {
                                    reader.Read();
                                    currency.ExchangeRate = Convert.ToDouble(reader.Value.Replace(".", ","));
                                }

                                if (reader.Name == "change")
                                {
                                    reader.Read();
                                    currency.Change = reader.Value;
                                }
                            }
                            if (reader.Name == "item" && reader.NodeType == XmlNodeType.EndElement)
                            {
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(currency.Name))
                        {
                            result.Add(currency);
                        }
                    }
                }
            }
            return result;
        }
    }
}
