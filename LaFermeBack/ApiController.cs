using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

[ApiController]
public class FermeController
{
	private readonly ILogger<FermeController> _logger;

	public FermeController(ILogger<FermeController> logger)
	{
		_logger = logger;
	}

	public void OnGet()
	{

	}

	[BindProperty]
	public IFormFile Upload { get; set; }
	public async Task OnPostAsync()
	{
		//var str = await FileHelper.ReadFormFileAsync(Upload);
		//var xml = XDocument.Parse("<Caisse>" + str + "</Caisse>");

		//var caisseItems = XmlHelper.Deserialize<Caisse>(xml.ToString());
		//Console.WriteLine(caisseItems.Ticket.Count);

		//var specificite = caisseItems.Ticket
		//	.Where(x => x.PriceToPay != x.PriceToPayWithoutRounding
		//	|| x.PriceToPay != x.AmountWithoutRounding
		//	|| x.PriceToPay != x.OriginalSalesTotal)
		//	.Where(x => x.Discount is null)
		//	.ToList();

		//var discount = caisseItems.Ticket
		//	.Where(x => x.Discount is not null && x.Discount.BaseValue != 10)
		//	.ToList();

		//var totM = caisseItems.Ticket.GroupBy(x => x.ReceiptDate.Month)
		//	.Select(g => new {
		//		Month = g.Key,
		//		TotalBrut = g.Sum(x => x.PriceToPayWithoutRounding),
		//		Total = g.Sum(x => x.PriceToPay),
		//		Ristourne = g.Sum(x => x.Discount?.Text),
		//		StartDate = g.Min(x => x.ReceiptDate)
		//	});

		//var tempDate = caisseItems.ReportLogCounters.First(x => x.CounterName == "Report.PeriodADelTime").CounterValue;

		//var lastExport = DateTimeOffset.FromUnixTimeMilliseconds(tempDate);

		//_logger.LogDebug(lastExport.DateTime.ToString());

	}
}
