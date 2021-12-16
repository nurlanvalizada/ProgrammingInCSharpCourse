using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18
{
    public class UserManager
    {
        private readonly List<User> _users = new();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void Update(int id, User user)
        {
            var oldUser = _users.FirstOrDefault(u => u.Id == id);
            if (oldUser is null)
            {
                throw new Exception($"User with id: {id} is not found");
            }

            oldUser.Name = user.Name;
            oldUser.DateOfBirth = user.DateOfBirth;
        }

        public void Delete(int id)
        {
            _users.RemoveAll(u => u.Id == id);
        }

        public User this[int index, int y] 
        {
            get => _users[index];
            set => _users[index] = value;
        }

        //public List<User> GetAll()
        //{
        //    return _users;
        //}

        //public List<User> GetUsersFiltered(Func<User, bool> predicate)
        //{
        //    return _users.Where(predicate).ToList();
        //}
    }
}
