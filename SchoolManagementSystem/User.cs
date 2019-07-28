using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    class User
    {
        private String userID;
        
        public String getuserID(){
            return userID;
        }
        public void setuserID(String userID)
        {
            this.userID = userID;
        }

    }
}
