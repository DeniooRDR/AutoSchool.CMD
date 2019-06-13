using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSchoolLibrary.Model
{
    [Serializable]
    class TimeClasses
    {
        public string NameClasses { get; set; }

        public TimeClasses(string NameClasses)
        {
            this.NameClasses = NameClasses;
        }

        public override string ToString()
        {
            return NameClasses;
        }
    }
}
