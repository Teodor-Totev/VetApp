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
			int currentPage = Math.Max(Math.Min(page, totalPages), 1);

			int startPage = Math.Max(1, currentPage - 5);
			int endPage = Math.Min(totalPages, startPage + 9);

			StartRecord = (currentPage - 1) * pageSize + 1;
			EndRecord = Math.Min(StartRecord + pageSize - 1, totalItems);

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

        public int StartRecord { get; set; }

        public int EndRecord { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

		public bool HasNextPage => CurrentPage < TotalPages;
	}
}
