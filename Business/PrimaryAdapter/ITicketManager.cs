using LaFermeWeb.Models;

namespace Business.PrimaryAdapter
{
    public interface ITicketManager
    {
        void SaveTickets(IEnumerable<CaisseLite> tickets);
    }
}