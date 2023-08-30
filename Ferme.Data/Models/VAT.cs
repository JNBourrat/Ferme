using System.ComponentModel.DataAnnotations;
using Ferme.Data.Models.Base;

namespace Ferme.Data.Models;

public class VAT : IdentifiableEntity
{
    public int VATID { get; set; }
	public double Percent { get; set; }
	public double Text { get; set; }
	public double VATValue { get; set; }
	public double VATTurnover { get; set; }
}


