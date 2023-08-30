using LaFermeWeb.Models;

namespace Business.SecondaryAdapter
{
    public interface ITicketRepository
    {
        void SaveTickets(IEnumerable<CaisseLite> tickets);
    }
}