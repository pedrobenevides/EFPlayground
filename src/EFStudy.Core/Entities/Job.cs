namespace EFStudy.Core.Entities
{
    public class Job : Entity
    {
        public string Name { get; set; }
        public virtual Client Client { get; set; }
    }
}