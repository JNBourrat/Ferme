using System.ComponentModel.DataAnnotations;
using Ferme.Data.Models.Base;

namespace Ferme.Data.Models;

public class PLU : IdentifiableEntity
{
    public string Description { get; set; }
}


