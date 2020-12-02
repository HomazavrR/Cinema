using System;
using System.Collections.Generic;

#nullable disable

namespace Cinema.Models
{
    public partial class Должности
    {
        public Должности()
        {
            Сотрудникиs = new HashSet<Сотрудники>();
        }

        public long КодДолжности { get; set; }
        public string НаименованиеДолжности { get; set; }
        public double Оклад { get; set; }
        public string Обязанности { get; set; }
        public string Требования { get; set; }

        public virtual ICollection<Сотрудники> Сотрудникиs { get; set; }
    }
}
