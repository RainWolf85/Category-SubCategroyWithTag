using System.Collections.Generic;

namespace Entities
{
    public class Tag : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}