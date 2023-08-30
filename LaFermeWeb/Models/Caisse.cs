// using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(Root));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (Root)serializer.Deserialize(reader);
// }

using System.Xml.Serialization;

[XmlRoot(ElementName = "BasePrice")]
public class BasePrice
{

	[XmlAttribute(AttributeName = "UnitPrice")]
	public double UnitPrice { get; set; }

	[XmlAttribute(AttributeName = "PriceOverWriteFlag")]
	public bool PriceOverWriteFlag { get; set; }

	[XmlAttribute(AttributeName = "DiscountFlag")]
	public bool DiscountFlag { get; set; }

	[XmlAttribute(AttributeName = "Quantity")]
	public int Quantity { get; set; }

	[XmlText]
	public double Text { get; set; }

	[XmlAttribute(AttributeName = "UnitOfMeasureCode")]
	public string UnitOfMeasureCode { get; set; }
}
[XmlRoot(ElementName = "Discount")]
public class Discount
{

	[XmlAttribute(AttributeName = "BaseValue")]
	public double BaseValue { get; set; }

	[XmlText]
	public double Text { get; set; }
}


[XmlRoot(ElementName = "VAT")]
public class VAT
{

	[XmlAttribute(AttributeName = "VATID")]
	public int VATID { get; set; }

	[XmlAttribute(AttributeName = "Percent")]
	public double Percent { get; set; }

	[XmlText]
	public double Text { get; set; }

	[XmlAttribute(AttributeName = "VATValue")]
	public double VATValue { get; set; }

	[XmlAttribute(AttributeName = "VATTurnover")]
	public double VATTurnover { get; set; }
}

[XmlRoot(ElementName = "Registration")]
public class Registration
{

	[XmlElement(ElementName = "PLU")]
	public PLU PLU { get; set; }

	[XmlElement(ElementName = "Description")]
	public string Description { get; set; }

	[XmlElement(ElementName = "BasePrice")]
	public BasePrice BasePrice { get; set; }

	[XmlElement(ElementName = "PriceToPay")]
	public double PriceToPay { get; set; }

	[XmlElement(ElementName = "VAT")]
	public VAT VAT { get; set; }
}

[XmlRoot(ElementName = "Payment")]
public class Payment
{

	[XmlElement(ElementName = "PaymentValue")]
	public double PaymentValue { get; set; }

	[XmlElement(ElementName = "TenderValue")]
	public double TenderValue { get; set; }

	[XmlElement(ElementName = "PaymentConfirmed")]
	public DateTime PaymentConfirmed { get; set; }
}

[XmlRoot(ElementName = "Ticket")]
public class Ticket
{

	[XmlElement(ElementName = "ReceiptID")]
	public int? ReceiptID { get; set; }

	[XmlElement(ElementName = "LocalReceiptID")]
	public int? LocalReceiptID { get; set; }

	[XmlElement(ElementName = "DeviceID")]
	public int DeviceID { get; set; }

	[XmlElement(ElementName = "ReceiptDate")]
	public DateTime ReceiptDate { get; set; }

	[XmlElement(ElementName = "State")]
	public string? State { get; set; }

	[XmlElement(ElementName = "UserID")]
	public int UserID { get; set; }

	[XmlElement(ElementName = "Registration")]
	public List<Registration>? Registration { get; set; }

	[XmlElement(ElementName = "Payment")]
	public List<Payment>? Payment { get; set; }

	[XmlElement(ElementName = "Weight")]
	public double Weight { get; set; }

	[XmlElement(ElementName = "PriceToPay")]
	public double PriceToPay { get; set; }

	[XmlElement(ElementName = "OriginalSalesTotal")]
	public double OriginalSalesTotal { get; set; }

	[XmlElement(ElementName = "PriceToPayWithoutRounding")]
	public double PriceToPayWithoutRounding { get; set; }

	[XmlElement(ElementName = "AmountWithoutRounding")]
	public double AmountWithoutRounding { get; set; }

	[XmlElement(ElementName = "Discount")]
	public Discount? Discount { get; set; }

	[XmlElement(ElementName = "FiscalState")]
	public string? FiscalState { get; set; }

	[XmlElement(ElementName = "VAT")]
	public VAT? VAT { get; set; }

	[XmlElement(ElementName = "SequenceNumber")]
	public int SequenceNumber { get; set; }
}

[XmlRoot(ElementName = "PLU")]
public class PLU
{

	[XmlAttribute(AttributeName = "Type")]
	public string? Type { get; set; }

	[XmlText]
	public int Text { get; set; }
}

[XmlRoot(ElementName = "VendorContext")]
public class VendorContext
{

	[XmlElement(ElementName = "VendorKey")]
	public int VendorKey { get; set; }

	[XmlElement(ElementName = "UserId")]
	public int UserId { get; set; }

	[XmlElement(ElementName = "IPAddress")]
	public string IPAddress { get; set; }

	[XmlElement(ElementName = "VendorGroup")]
	public object VendorGroup { get; set; }

	[XmlElement(ElementName = "LocalReceiptId")]
	public int LocalReceiptId { get; set; }

	[XmlElement(ElementName = "TrainingMode")]
	public bool TrainingMode { get; set; }

	[XmlElement(ElementName = "DeviceNo")]
	public int DeviceNo { get; set; }

	[XmlElement(ElementName = "Ticket")]
	public Ticket Ticket { get; set; }
}

[XmlRoot(ElementName = "LogCounters")]
public class LogCounters
{

	[XmlElement(ElementName = "CounterName")]
	public string CounterName { get; set; }

	[XmlElement(ElementName = "CounterValue")]
	public int CounterValue { get; set; }
}

[XmlRoot(ElementName = "ReportLogCounters")]
public class ReportLogCounters
{

	[XmlElement(ElementName = "CounterName")]
	public string CounterName { get; set; }

	[XmlElement(ElementName = "CounterValue")]
	public int CounterValue { get; set; }
}

[XmlRoot(ElementName = "Caisse")]
public class Caisse
{

	[XmlElement(ElementName = "Ticket")]
	public List<Ticket> Ticket { get; set; }

	[XmlIgnore]
	public List<VendorContext> VendorContext { get; set; }

	[XmlElement(ElementName = "LogCounters")]
	public List<LogCounters> LogCounters { get; set; }

	[XmlElement(ElementName = "ReportLogCounters")]
	public List<ReportLogCounters> ReportLogCounters { get; set; }
}

