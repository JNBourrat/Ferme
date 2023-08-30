using AutoMapper;
using Ferme.Data;

namespace Repository;

public abstract class BddRepositoryBase
{
    protected readonly FermeContext db;
    protected readonly IMapper mapper;

    protected BddRepositoryBase(FermeContext fermeContext, IMapper mapper)
    {
        db = fermeContext;
        this.mapper = mapper;
    }

    public void SaveChange()
    {
        db.SaveChanges();
    }
}
