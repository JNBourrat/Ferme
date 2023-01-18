using System.Xml.Serialization;

namespace LaFermeWeb.Models;

    public class CaisseLite
    {
	public int? ReceiptID { get; set; }

	public int? LocalReceiptID { get; set; }

	public DateTime ReceiptDate { get; set; }

	public List<Registration>? Registration { get; set; }

	public List<Payment>? Payment { get; set; }

	public double Weight { get; set; }

	public double PriceToPay { get; set; }

	public double OriginalSalesTotal { get; set; }

	public double PriceToPayWithoutRounding { get; set; }

	public double AmountWithoutRounding { get; set; }

	public string? FiscalState { get; set; }

	public VAT? VAT { get; set; }

	public int SequenceNumber { get; set; }

}

public class VAT
{
	public int VATID { get; set; }
	public double Percent { get; set; }
	public double Text { get; set; }
	public double VATValue { get; set; }
	public double VATTurnover { get; set; }
}

public class Registration
{

	public PLU PLU { get; set; }

	public BasePrice BasePrice { get; set; }

	public double PriceToPay { get; set; }

	public VAT VAT { get; set; }
}
public class BasePrice
{

	public double UnitPrice { get; set; }
	public int Quantity { get; set; }
	public double Text { get; set; }
	public string UnitOfMeasureCode { get; set; }
}

public class PLU
{
	public int Id { get; set; }
	public string Description { get; set; }
}

public class Payment
{
	public double PaymentValue { get; set; }
	public DateTime PaymentConfirmed { get; set; }
}


