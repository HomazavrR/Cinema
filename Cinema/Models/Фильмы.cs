using System;
using System.Collections.Generic;

#nullable disable

namespace Cinema.Models
{
    public partial class Фильмы
    {
        public long КодФильма { get; set; }
        public string Наименование { get; set; }
        public double Длительность { get; set; }
        public string ФирмаПроизводителя { get; set; }
        public string СтранаПроизводителя { get; set; }
        public string Актеры { get; set; }
        public string ВозрастныеОграничения { get; set; }
        public string Описание { get; set; }
        public long КодЖанра { get; set; }
        public long КодСеанса { get; set; }
        public long НомерМеста { get; set; }

        public virtual Жанры КодЖанраNavigation { get; set; }
        public virtual Репертуар КодСеансаNavigation { get; set; }
        public virtual Места НомерМестаNavigation { get; set; }
    }
}
