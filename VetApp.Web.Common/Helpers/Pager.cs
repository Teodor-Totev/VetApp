namespace VetApp.Web.Common.Helpers
{
	public class Pager
	{
        public Pager()
        {
            
        }

        public Pager(int page, int pageSize, int totalItems)
		{
			int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
			int currentPage = page;

			int startPage = currentPage - 5;
			int endPage = currentPage + 4;

			if (startPage < 1)
			{
				endPage = endPage - (startPage - 1);
				startPage = 1;
			}

			if (endPage > totalPages) 
			{
				endPage = totalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalItems = totalItems;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
		}

		public int CurrentPage { get; set; }

		public int PageSize { get; set; }

		public int TotalItems { get; set; }

		public int TotalPages { get; set; }

		public int StartPage { get; set; }

        public int EndPage { get; set; }

		public bool HasPreviousPage => CurrentPage > 1;

		public bool HasNextPage => CurrentPage < TotalPages;
	}
}
