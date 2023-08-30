
using LaFermeWeb.Models;

namespace LaFermeWeb.Profile;

public class WebProfile : AutoMapper.Profile
{
    public WebProfile()
    {
        CreateMap<Ticket, CaisseLite>().ReverseMap();
        CreateMap<LaFermeWeb.Models.BasePrice, BasePrice>().ReverseMap();
        CreateMap<LaFermeWeb.Models.Payment, Payment>().ReverseMap();
        CreateMap<LaFermeWeb.Models.PLU, PLU>().ReverseMap();
        CreateMap<LaFermeWeb.Models.Registration, Registration>().ReverseMap();
        CreateMap<LaFermeWeb.Models.VAT, VAT>().ReverseMap();

    }
}

