using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LinkProject
{
    internal class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public BigInteger Phone { get; set; }
        public BigInteger Cnp { get; set; }
        public DateTime BirthDay { get; set; }
        public Calendar Calendar { get; set; }

        public User(int id,string name,string password,string email, BigInteger phone,BigInteger cnp, DateTime birthDay)
        {
           Name= name;
           Password= password;
           Email= email;
           Phone= phone;
           Cnp= cnp;  
           BirthDay= birthDay;
           UserId= id;
        }

        public User(string name, int id,string email,string password)
        {
            UserId= id;
            Name= name;
            Email = email;
            Password = password;
        }
     
        public override string ToString() => $"\nEmail:{Email}";
    }
}
