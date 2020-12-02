using System;
using System.Collections.Generic;

#nullable disable

namespace Cinema.Models
{
    public partial class Репертуар
    {
        public Репертуар()
        {
            Фильмыs = new HashSet<Фильмы>();
        }

        public long КодСеанса { get; set; }
        public DateTime Дата { get; set; }
        public DateTime ВремяНачала { get; set; }
        public DateTime ВремяОкончания { get; set; }
        public double ЦенаБилета { get; set; }

        public virtual ICollection<Фильмы> Фильмыs { get; set; }
    }
}
