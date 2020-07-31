using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADService
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                args = Helper.ReadParams();
            }

            string fullFileName = "";
            string __host = args[0];
            string __user = args[1];
            string __password = args[2];
            string __path = args[3];
            
            if (__host != "" && __user != "" && __password != "")
            {
                List<ADUser> users = ADUser.GetUsers(__host, __user, __password);
                fullFileName = ADUser.CSVWriter(users, __path);
            }
            if (fullFileName != "")
            {
                Console.WriteLine("File Written at - " + fullFileName);
            }
            else
            {
                Console.WriteLine("Error!!!!");
            }
            Console.ReadLine();

        }
    }
}
