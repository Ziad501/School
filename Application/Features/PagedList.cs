namespace Application.Features
{
    public class PagedList<T>
    {
        public int CurrentPage { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<T> Items { get; } = new();

        public PagedList(List<T> items, int count, int currentPage, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items.AddRange(items);
        }

        public static PagedList<T> Create(
            IEnumerable<T> source,
            int currentPage,
            int pageSize)
        {
            currentPage = currentPage <= 0 ? 1 : currentPage;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            var count =  source.Count();

            if (count == 0)
                return new PagedList<T>(new List<T>(), 0, currentPage, pageSize);

            var items = source
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, count, currentPage, pageSize);
        }
    }
}