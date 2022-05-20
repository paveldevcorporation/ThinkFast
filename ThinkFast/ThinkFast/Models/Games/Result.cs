using System;
using SQLite;

namespace ThinkFast.Models.Games
{
    [Table("Result")]
    public class Result : Entity
    {
        public Result()
        {
        }

        public Result(double points)
        {
            Points = points;
            Date = DateTime.Now;
        }

        public DateTime Date { get; set; }

        public double Points { get; set; }
    }
}