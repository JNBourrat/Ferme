

using LaFermeWeb.Models;

namespace Repository.Profile;

public class RepositoryProfile : AutoMapper.Profile
{
    public RepositoryProfile()
    {
        CreateMap<CaisseLite, Ferme.Data.Models.CaisseLite>().ReverseMap();
        CreateMap<BasePrice, Ferme.Data.Models.BasePrice>().ReverseMap();
        CreateMap<Payment, Ferme.Data.Models.Payment>().ReverseMap();
        CreateMap<PLU, Ferme.Data.Models.PLU>().ReverseMap();
        CreateMap<Registration, Ferme.Data.Models.Registration>().ReverseMap();
        CreateMap<VAT, Ferme.Data.Models.VAT>().ReverseMap();
    }
}

