namespace Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSubCategory { get; set; }
     
        public int? TagId { get; set; }

        public Tag Tag { get; set; }
    }
}