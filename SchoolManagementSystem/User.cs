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
        private String type;
        private String phone, fname, lname, email, nic, appointeddate, joineddate, qualification, gender, dob;
        private String specializedsubject;
        private String designation;
        private String experience;

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

  

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Fname
        {
            get
            {
                return fname;
            }

            set
            {
                fname = value;
            }
        }

        public string Lname
        {
            get
            {
                return lname;
            }

            set
            {
                lname = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Nic
        {
            get
            {
                return nic;
            }

            set
            {
                nic = value;
            }
        }

        public string Appointeddate
        {
            get
            {
                return appointeddate;
            }

            set
            {
                appointeddate = value;
            }
        }

        public string Joineddate
        {
            get
            {
                return joineddate;
            }

            set
            {
                joineddate = value;
            }
        }

   

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string Dob
        {
            get
            {
                return dob;
            }

            set
            {
                dob = value;
            }
        }

        public string Specializedsubject
        {
            get
            {
                return specializedsubject;
            }

            set
            {
                specializedsubject = value;
            }
        }

        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                designation = value;
            }
        }

        public string Experience
        {
            get
            {
                return experience;
            }

            set
            {
                experience = value;
            }
        }

        public string Qualification
        {
            get
            {
                return qualification;
            }

            set
            {
                qualification = value;
            }
        }

        public String getuserID(){
            return userID;
        }
        public void setuserID(String userID)
        {
            this.userID = userID;
        }

    }
}
