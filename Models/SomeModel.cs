namespace EfCoreMistakes.Models
{
    public class SomeModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public ICollection<SubModel>? SubModels { get; set; }
    }
}
