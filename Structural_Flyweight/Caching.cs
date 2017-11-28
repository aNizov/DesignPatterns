using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Flyweight.Caching
{
    public class Client
    {
        public void Main()
        {
            var user = new UserFactory()
                .GetUser(1);
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<User> Followers { get; set; }

        public static User GetUser(int userId)
        {
            //Здесь будет, например код обращения к БД

            //Заглушка
            return new User()
            {
                UserId = 1
            };
        }
    }

    public class UserFactory
    {
        public static int UsersCount = 0;

        //Этот словарь вся мяготка паттерна.
        private Dictionary<int,User> Users = new Dictionary<int, User>();

        //При обращении к фабричному методу проверяется есть ли данный объект в словаре-кэше
        //И instance создается только если его нет.
        //Таким образом экономятся ресурсы обращения к БД
        //Или ресурсы необходимые, для инициализации "тяжелых" объектов
        public User GetUser(int userId)
        {
            if (Users.ContainsKey(userId))
            {
                return Users[userId];
            }
            User user = User.GetUser(userId);
            Users.Add(userId, user);
            UsersCount++;
            return user;
        }
    }
}
