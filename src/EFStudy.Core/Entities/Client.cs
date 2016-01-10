using System.Collections.Generic;

namespace EFStudy.Core.Entities
{
    public class Client : Entity
    {
        public string Name { get; set; }

        public virtual IList<Job> Jobs { get; set; }
    }
}