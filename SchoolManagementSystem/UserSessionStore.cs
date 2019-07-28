using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    class UserSessionStore
    {
        private static UserSessionStore instance = null;

        private User user = null;

        private UserSessionStore()
        {
        }

        public void setUser(User u)
        {
            user = u;
        }

        public User getUser()
        {
            return user;
        } 

        public static UserSessionStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSessionStore();
                }
                return instance;
            }
        }
    }
}
