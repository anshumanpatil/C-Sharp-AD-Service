using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADService
{
    class Helper
    {
        public static string[] ReadParams()
        { 
            string __host;
            string __user;
            string __password;
            string __path;


            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("------------------------AD Seervice To  Get Users---------------------------");
            Console.WriteLine("----------------------------------------------------------------------------");


            Console.WriteLine("");
            Console.WriteLine("Enter Host Name - ");
            Console.WriteLine("Exampe ---->  LDAP://172.17.120.28/DC=LDAP,DC=LOCAL");
            __host = Console.ReadLine();

            Console.WriteLine("Host Selected = " + __host);
            Console.WriteLine("");


            Console.WriteLine("");
            Console.WriteLine("Enter User Name - ");
            __user = Console.ReadLine();

            Console.WriteLine("User Name = " + __user);
            Console.WriteLine("");
            

            Console.WriteLine("");
            Console.WriteLine("Enter Password - ");
            __password = Console.ReadLine();
            Console.WriteLine("");


            Console.WriteLine("");
            Console.WriteLine("Enter File Path To Save - ");
            __path = Console.ReadLine();

            Console.WriteLine("File Path = " + __path);
            Console.WriteLine("");

            if (__host == "") __host = "LDAP://172.17.120.28/DC=LDAP,DC=LOCAL";
            if (__user == "") __user = "Administrator";
            if (__password == "") __password = "Anshu@1506";
            if (__path == "") __path = "d:/logs";

            return new string[4] { __host, __user, __password, __path };
        }
    }
}
