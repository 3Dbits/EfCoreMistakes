namespace EfCoreMistakes.Models
{
    public class SubSubModel
    {
        public int Id { get; set; }
        public required string SubSubInformation { get; set; }
        public ICollection<SubSubSubModel> SubSubSubModels { get; set; }
        public SubModel SubModel { get; set; }
        public int SubModelId { get; set; }
    }
}