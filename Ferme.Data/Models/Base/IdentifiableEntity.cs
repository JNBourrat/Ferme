using System.ComponentModel.DataAnnotations;

namespace Ferme.Data.Models.Base;

public abstract class IdentifiableEntity : EntityBase
{
    [Key]
    public int Id { get; set; }
}