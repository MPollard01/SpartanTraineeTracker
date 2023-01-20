using System.Collections;

namespace TraineeTracker.MVC.Utils
{
    public class PaginatedArrayList : ArrayList
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedArrayList(ArrayList items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedArrayList Create(ArrayList source, int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = new ArrayList();
       
            for(int i = (pageIndex - 1) * pageSize; i < count && i < pageSize; i++)
                items.Add(source[i]);

            return new PaginatedArrayList(items, count, pageIndex, pageSize);
        }
    }
}
