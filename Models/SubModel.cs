using System.Security.Policy;

namespace EfCoreMistakes.Models
{
    public class SubModel
    {
        public int Id { get; set; }
        public required string Information { get; set; }
        public int SomeModelId { get; set; }
        public SomeModel SomeModel { get; set; }
        public ICollection<SubSubModel> SubSubModels { get; set; }
    }
}
