using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaxParser
{
    class User
    {
        public string Uid { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string Gender { get; private set; }
        public string Skills { get; private set; }

        public User(string uid, string name, string email, string city, string address, string phone, string gender, string skills)
        {
            Name = name;
            Uid = uid;
            Email = email;
            City = city;
            Address = address;
            Phone = phone;
            Gender = gender;
            Skills = skills;
        }

        public override string ToString()
        {
            return String.Format("[UID: {0}], [Name: {1}], [Email: {2}], [City: {3}], [Address: {4}], [Phone: {5}], [Gender: {6}], [Skills: {7}]", Uid, Name, Email, City, Address, Phone, Gender, Skills);
        }
    }
}
