using System;
using System.Collections.Generic;

#nullable disable

namespace Cinema.Models
{
    public partial class Места
    {
        public Места()
        {
            Фильмыs = new HashSet<Фильмы>();
        }

        public long НомерМеста { get; set; }
        public string Занятость { get; set; }
        public long КодСотрудника { get; set; }

        public virtual Сотрудники КодСотрудникаNavigation { get; set; }
        public virtual ICollection<Фильмы> Фильмыs { get; set; }
    }
}
