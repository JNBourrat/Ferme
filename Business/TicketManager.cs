using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.PrimaryAdapter;
using LaFermeWeb.Models;
using Microsoft.Extensions.Logging;

namespace Business
{
    public class TicketManager : ITicketManager
    {
        public TicketManager(ILogger logger)
        {
            _logger = logger;

        }

        private ILogger _logger { get; }

        public void SaveTickets(IEnumerable<CaisseLite> caisseItems)
        {
            Console.WriteLine($"{caisseItems.Count()}");

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
