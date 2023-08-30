using System.ComponentModel.DataAnnotations;
using Ferme.Data.Models.Base;

namespace Ferme.Data.Models;

public class BasePrice : IdentifiableEntity
{
    public double UnitPrice { get; set; }
	public int Quantity { get; set; }
	public double Text { get; set; }
	public string UnitOfMeasureCode { get; set; }
}


