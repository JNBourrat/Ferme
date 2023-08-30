using Ferme.Data.Models.Base;

namespace Ferme.Data.Models;

public class Registration : IdentifiableEntity
{
    public PLU PLU { get; set; }

	public BasePrice BasePrice { get; set; }

	public double PriceToPay { get; set; }

	public VAT VAT { get; set; }
}


