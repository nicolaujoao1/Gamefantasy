using System.Text.Json.Serialization;

namespace GameFantasy.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
