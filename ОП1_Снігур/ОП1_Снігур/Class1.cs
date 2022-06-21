using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ОП1_Снігур
{
    public class Завдання1
    {
        public string time0 { get; set; }
        public string time { get; set; }
        public string Lesson { get; set; }
        public string Сomment { get; set; }

        public string ToTime { get { return time0 + "-" + time; } set { } }
    }
}