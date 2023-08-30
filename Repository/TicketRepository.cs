using AutoMapper;
using Business.SecondaryAdapter;
using Ferme.Data;
using LaFermeWeb.Models;

namespace Repository
{
    public class TicketRepository : BddRepositoryBase, ITicketRepository
    {
        public TicketRepository(FermeContext fermeContext, IMapper mapper): base(fermeContext, mapper) { }

        public void SaveTickets(IEnumerable<CaisseLite> tickets)
        {
            var caisseItemsEntity = mapper.Map<IEnumerable<Ferme.Data.Models.CaisseLite>>(tickets);
            db.AddRange(caisseItemsEntity);
            db.SaveChanges();
        }
    }
}
