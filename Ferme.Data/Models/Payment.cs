using Ferme.Data.Models.Base;

namespace Ferme.Data.Models;

public class Payment : IdentifiableEntity
{
    public double PaymentValue { get; set; }
	public DateTime PaymentConfirmed { get; set; }
}


