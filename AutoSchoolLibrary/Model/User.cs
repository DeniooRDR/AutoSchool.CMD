using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSchoolLibrary.Model
{
    [Serializable]
    public class User
    {
        private string userName;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Birth Date
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }

        public User(string Name, DateTime BirthDate, int Age)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(Name));
            }

            if (BirthDate < DateTime.Parse("01.01.1918") || BirthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможна дата рождения", nameof(BirthDate));
            }
        }

        public User(string userName)
        {
            this.userName = userName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
