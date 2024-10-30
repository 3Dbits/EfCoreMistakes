namespace EfCoreMistakes.Models
{
    public class SubSubSubModel
    {
        public int Id { get; set; }
        public required string SubSubSubInformation { get; set; }
        public int SubSubModelId { get; set; }
        public SubSubModel SubSubModel { get; set; }
    }
}