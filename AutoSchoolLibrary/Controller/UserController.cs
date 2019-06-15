using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSchoolLibrary.Model;

namespace AutoSchoolLibrary.Controller
{
    public class UserController : SaveController
    {
        /// <summary>
        /// Create user Auto School
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool NewUser { get; } = false;

        private const string USERS_FILE_NAME = "users.dat";

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUserData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser); 
                NewUser = true;
                Save();
            }
        }

        public UserController()
        {
        }

        private List<User> GetUserData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string name, DateTime birthDate, int age)
        {
            CurrentUser.Name = name;
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Age = age;
            Save();
        }

        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
    }
}
