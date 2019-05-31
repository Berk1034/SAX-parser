using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;

namespace SaxParser
{
    class Program
    {
        static void Main(string[] args)
        {
//            int Amount = 0;
            const string writePath = "result.txt";
            Console.WriteLine("Enter X for Skills: ");
            int skillsX = int.Parse(Console.ReadLine());
            List<User> users = new List<User>();
            using (XmlReader xr = XmlReader.Create(@"feed-test.xml"))
            {
                string uid = "";
                string name = "";
                string email = "";
                string city = "";
                string address = "";
                string phone = "";
                string gender = "";
                int skills = 0;
                string skill = "";

                string element = "";
                while (xr.Read())
                {
                    // reads the element
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        element = xr.Name; // the name of the current element
//                       if (element == "skill")
//                        {
//                            skill = skill + xr.Value;
//                        }
                    }
                    // reads the element value
                    else if (xr.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "name":
                                name = xr.Value;
                                break;
                            case "uid":
                                uid = xr.Value;
                                break;
                            case "email":
                                email = xr.Value;
                                break;
                            case "city":
                                city = xr.Value;
                                break;
                            case "address":
                                address = xr.Value;
                                break;
                            case "phone":
                                phone = xr.Value;
                                break;
                            case "gender":
                                gender = xr.Value;
                                break;
                            case "skill":
                                skills++;
                                skill = skill + xr.Value + ", ";
                                break;
                        }
                    }
                    // reads the closing element
                    else if ((xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "user"))
                    {
                        //                        string pattern = "^[- а-z0-9][- а-z0-9._]+@([- а-z0-9]+[.])+biz$";
                        string pattern = "^[a-zA-Z0-9][a-zA-Z0-9._]+@([a-zA-Z0-9]+[.])+biz$";
                        Regex regex = new Regex(pattern);
                        Match match = regex.Match(email);
                        if ((skills > skillsX) && match.Success)
                        {
                            if (skill.Length > 1)
                                skill = skill.Substring(0, skill.Length - 2);
                            users.Add(new User(uid, name, email, city, address, phone, gender, skill));
                            //Console.WriteLine(users[users.Count() - 1]);
                            //Amount++;
                        }
                        skill = "";
                        skills = 0;
                    }
                }
            }
            // printing the loaded objects
            
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (User u in users)
                {
                    sw.WriteLine(u);
                    Console.WriteLine(u);
                }

            }
            
            //Console.WriteLine("{0}", Amount);
            Console.ReadKey();
        }
    }
}
