using System.Xml.Linq;
using AutoMapper;
using Business.PrimaryAdapter;
using LaFermeWeb.Helper;
using LaFermeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaFermeWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITicketManager _ticketManager;
        private readonly IMapper _mapper;

        public IndexModel(ILogger<IndexModel> logger, ITicketManager tickerManager, IMapper mapper)
        {
            _logger = logger;
            _ticketManager = tickerManager;
            _mapper = mapper;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task OnPostAsync()
        {
            var str = await FileHelper.ReadFormFileAsync(Upload);
            var xml = XDocument.Parse("<Caisse>" + str + "</Caisse>");

            var caisseItems = XmlHelper.Deserialize<Caisse>(xml.ToString());
            //Console.WriteLine(caisseItems.Ticket.Count);

            var caisseItemLite = _mapper.Map<IEnumerable<CaisseLite>>(caisseItems);

            _ticketManager.SaveTickets(caisseItemLite);
            //var specificite = caisseItems.Ticket
            //	.Where(x => x.PriceToPay != x.PriceToPayWithoutRounding
            //	|| x.PriceToPay != x.AmountWithoutRounding
            //	|| x.PriceToPay != x.OriginalSalesTotal)
            //	.Where(x=> x.Discount is null)
            //	.ToList();

            //var discount = caisseItems.Ticket
            //	.Where(x => x.Discount is not null && x.Discount.BaseValue != 10)
            //	.ToList();

            //var totM = caisseItems.Ticket.GroupBy(x => x.ReceiptDate.Month)
            //	.Select(g => new {
            //		Month = g.Key,
            //		TotalBrut = g.Sum(x => x.PriceToPayWithoutRounding),
            //		Total = g.Sum(x => x.PriceToPay),
            //		Ristourne = g.Sum(x=> x.Discount?.Text),
            //		StartDate = g.Min(x=> x.ReceiptDate)
            //	});

            var tempDate = caisseItems.ReportLogCounters.First(x => x.CounterName == "Report.PeriodADelTime").CounterValue;

            var lastExport = DateTimeOffset.FromUnixTimeMilliseconds(tempDate);

            _logger.LogDebug(lastExport.DateTime.ToString());

        }
    }
}