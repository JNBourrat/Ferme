
using System.ComponentModel.DataAnnotations;
using Ferme.Data.Models.Base;

namespace Ferme.Data.Models;

public class CaisseLite : IdentifiableEntity
{
	public int ReceiptID { get; set; }

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


