using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
namespace ADService
{
    public class ADUser
    {
        #region constants

        public const string SamAccountNameProperty = "sAMAccountName";
        public const string EmailAddressProperty = "EmailAddress";
        public const string CanonicalNameProperty = "CN";

        #endregion

        #region Properties
        public string CN { get; set; }
        public string SamAcountName { get; set; }
        public string EmailAddress { get; set; }

        #endregion


        public static List<ADUser> GetUsers(string domain, string userName, string passWord)
        {
            List<ADUser> users = new List<ADUser>();

            using (DirectoryEntry searchRoot = new DirectoryEntry(domain, userName, passWord))
            using (DirectorySearcher directorySearcher = new DirectorySearcher(searchRoot))
            {
                // Set the filter
                directorySearcher.Filter = "(&(objectCategory=person)(objectClass=user))";

                // Set the properties to load.
                directorySearcher.PropertiesToLoad.Add(CanonicalNameProperty);
                directorySearcher.PropertiesToLoad.Add(SamAccountNameProperty);
                directorySearcher.PropertiesToLoad.Add(EmailAddressProperty);



                using (SearchResultCollection searchResultCollection = directorySearcher.FindAll())
                {
                    foreach (SearchResult searchResult in searchResultCollection)
                    {
                        // Create new ADUser instance
                        var user = new ADUser();

                        // Set CN if available.
                        if (searchResult.Properties[CanonicalNameProperty].Count > 0)
                            user.CN = searchResult.Properties[CanonicalNameProperty][0].ToString();

                        // Set sAMAccountName if available
                        if (searchResult.Properties[SamAccountNameProperty].Count > 0)
                            user.SamAcountName = searchResult.Properties[SamAccountNameProperty][0].ToString();

                        if (searchResult.Properties[EmailAddressProperty].Count > 0)
                            user.EmailAddress = searchResult.Properties[EmailAddressProperty][0].ToString();

                        // Add user to users list.
                        users.Add(user);
                    }
                }
            }

            // Return all found users.
            return users;
        }
        public static string CSVWriter(List<ADUser> users, string path)
        {
            DateTime dttm = DateTime.UtcNow;
            long fileName = ((DateTimeOffset)dttm).ToUnixTimeSeconds();
            string fullFileName = path + "/" + fileName + ".csv";

            using (StreamWriter writer = new StreamWriter(fullFileName))
            {
                var header = "Date,CN,SamAcountName,EmailAddress";
                writer.WriteLine(header);
                foreach (ADUser __tempUser in users)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------");
                    Console.WriteLine(__tempUser.CN);
                    Console.WriteLine(__tempUser.SamAcountName);
                    Console.WriteLine(__tempUser.EmailAddress);

                    var line = string.Format("{0},{1},{2},{3}", dttm, __tempUser.CN, __tempUser.SamAcountName, __tempUser.EmailAddress);
                    writer.WriteLine(line);
                }
                writer.Flush();
            }
            return fullFileName;
        }
    }
}
