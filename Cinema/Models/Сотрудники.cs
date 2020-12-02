using System;
using System.Collections.Generic;

#nullable disable

namespace Cinema.Models
{
    public partial class Сотрудники
    {
        public Сотрудники()
        {
            Местаs = new HashSet<Места>();
        }

        public long КодСотрудника { get; set; }
        public string Фио { get; set; }
        public long Возраст { get; set; }
        public string Пол { get; set; }
        public string Адрес { get; set; }
        public string Телефон { get; set; }
        public string ПаспортныеДанные { get; set; }
        public long КодДолжности { get; set; }

        public virtual Должности КодДолжностиNavigation { get; set; }
        public virtual ICollection<Места> Местаs { get; set; }
    }
}
