using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.PrimaryAdapter;
using Business.SecondaryAdapter;
using LaFermeWeb.Models;
using Microsoft.Extensions.Logging;

namespace Business
{
    public class TicketManager : ITicketManager
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketManager(ILogger<TicketManager> logger, ITicketRepository ticketRepository)
        {
            _logger = logger;
            this._ticketRepository = ticketRepository;
        }

        private ILogger<TicketManager> _logger { get; }

        public void SaveTickets(IEnumerable<CaisseLite> caisseItems)
        {
            Console.WriteLine($"{caisseItems.Count()}");
            _ticketRepository.SaveTickets(caisseItems);
            var totM = caisseItems.GroupBy(x => x.ReceiptDate.Month)
                .Select(g => new {
                    Month = g.Key,
                    TotalBrut = g.Sum(x => x.PriceToPayWithoutRounding),
                    Total = g.Sum(x => x.PriceToPay),
                    StartDate = g.Min(x => x.ReceiptDate)
                });

        }
    }
}
