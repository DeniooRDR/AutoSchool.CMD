using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSchoolLibrary.Model;

namespace AutoSchoolLibrary.Controller
{
    public class ClassesController : SaveController
    {
        private readonly User user;

        public List<TimeTable> TimeTables { get; }
        private const string TIME_TABLES_FILES = "timetable.dat";
        public List<TimeClasses> TimeClasses { get; }
        private const string TIME_CLASSES_FILE = "timeclasses.dat";

        public ClassesController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            TimeTables = AllTimeTables();
            TimeClasses = AllTimeClasses();
        }

        public void Add(TimeClasses timeClasses, DateTime begin, DateTime end)
        {
            var act = TimeClasses.SingleOrDefault(a => a.NameClasses == timeClasses.NameClasses);
            if (act == null)
            {
                TimeClasses.Add(timeClasses);

                var timeTable = new TimeTable(begin, end, timeClasses, user);
                TimeTables.Add(timeTable);
            }
            else
            {
                var timeTable = new TimeTable(begin, end, timeClasses, user);
                TimeTables.Add(timeTable);
            }
            Save();
        }

        private List<TimeClasses> AllTimeClasses()
        {
            return Load<List<TimeClasses>>(TIME_CLASSES_FILE) ?? new List<TimeClasses>();
        }

        private List<TimeTable> AllTimeTables()
        {
            return Load<List<TimeTable>>(TIME_TABLES_FILES) ?? new List<TimeTable>();
        }

        private void Save()
        {
            Save(TIME_TABLES_FILES, TimeTables);
            Save(TIME_CLASSES_FILE, TimeClasses);
        }
    }
}
