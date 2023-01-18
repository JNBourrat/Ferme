using LaFermeWeb.Models;

namespace Repository
{
    public sealed class MockBdd
    {
		private static readonly MockBdd instance = new MockBdd();

		public IList<CaisseLite> CaissesItems { get; set; }

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static MockBdd()
		{
		}

		private MockBdd()
		{
		}

		public static MockBdd Instance
		{
			get
			{
				return instance;
			}
		}
	}
}