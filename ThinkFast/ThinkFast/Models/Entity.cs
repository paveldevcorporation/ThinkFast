using SQLite;

namespace ThinkFast.Models
{
    public abstract class Entity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}