namespace TraineeTracker.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<SubCategory> SubCategories { get; } = new List<SubCategory>();
    }
}
