using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSchoolLibrary.Model
{
    [Serializable]
    class TimeTable
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public TimeClasses TimeClasses { get; set; }
        public User User { get; }

        public TimeTable(DateTime Start, DateTime Finish, TimeClasses TimeClasses, User User)
        {
            this.Start = Start;
            this.Finish = Finish;
            this.TimeClasses = TimeClasses;
            this.User = User;
        }
    }

}
