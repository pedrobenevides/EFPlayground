using System.ComponentModel.DataAnnotations;

namespace EFStudy.Core.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        public byte[] TimeStamp { get; set; }
    }
}
