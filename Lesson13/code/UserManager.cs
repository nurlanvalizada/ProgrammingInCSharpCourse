using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    public class UserManager
    {
        private User[] _users = new User[10];
        private int _currentPosition = 0;

        private readonly ISMSService _smsService;

        public UserManager(ISMSService smsService)
        {
            _smsService = smsService;
        }

        public void RegisterNewUser(User user) 
        {
            _users[_currentPosition] = user;
            _currentPosition++;

            _smsService.SendSMS("0518963524", $"New user is registered with Name: {user.Name}");
        }

        public void EditUser(User user) 
        {
            var oldUser = GetUserById(user.Id);
            string oldName = oldUser.Name;
            oldUser.Name = user.Name;

            var smsService = new SMSService1();

            _smsService.SendSMS("0518963524", $"{oldName} changes his/her name to {user.Name}");
        }

        private User GetUserById(int id) 
        {
            foreach (var user in _users)
            {
                if (user.Id == id)
                    return user;
            }

            return null;
        }
    }
}
