using System;
using System.Collections.Generic;

#nullable disable

namespace Cinema.Models
{
    public partial class Жанры
    {
        public Жанры()
        {
            Фильмыs = new HashSet<Фильмы>();
        }

        public long КодЖанра { get; set; }
        public string Наименование { get; set; }
        public string Описание { get; set; }

        public virtual ICollection<Фильмы> Фильмыs { get; set; }
    }
}
