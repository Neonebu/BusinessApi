using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BusinessApi.Models
{
    public class Currency
    {
		[Key]
		public int crId { get; set; }
		[XmlElement(ElementName = "Unit")]
		public string Unit { get; set; }
		[XmlElement(ElementName = "Isim")]
		public string Isim { get; set; }
		[XmlElement(ElementName = "CurrencyName")]
		public string CurrencyName { get; set; }
		[XmlElement(ElementName = "ForexBuying")]
		public string ForexBuying { get; set; }
		[XmlElement(ElementName = "ForexSelling")]
		public string ForexSelling { get; set; }
		[XmlElement(ElementName = "BanknoteBuying")]
		public string BanknoteBuying { get; set; }
		[XmlElement(ElementName = "BanknoteSelling")]
		public string BanknoteSelling { get; set; }
		[XmlElement(ElementName = "CrossRateUSD")]
		public string CrossRateUSD { get; set; }
		[XmlElement(ElementName = "CrossRateOther")]
		public string CrossRateOther { get; set; }
		[XmlAttribute(AttributeName = "CrossOrder")]
		public string CrossOrder { get; set; }
		[XmlAttribute(AttributeName = "Kod")]
		public string Kod { get; set; }
		[XmlAttribute(AttributeName = "CurrencyCode")]
		public string CurrencyCode { get; set; }
		public int tarihId { get; set; }
	}
	[XmlRoot(ElementName = "Tarih_Date")]
	public class Tarih_Date
	{
		[Key]
		public int trId { get; set; }
		[XmlElement(ElementName = "Currency")]
		public List<Currency> Cur { get; set; }
		[XmlAttribute(AttributeName = "Tarih")]
		public string Tarih { get; set; }
		[XmlAttribute(AttributeName = "Date")]
		public string Date { get; set; }
		[XmlAttribute(AttributeName = "Bulten_No")]
		public string Bulten_No { get; set; }
	}
}
