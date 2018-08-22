using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace GatewayLibrary
{
    public class AccountDatabase : GameDatabase
    {
        //check to see whether a username/password combination exists in the database
        public AccountRecord LookUpAccountRecord(string userName, string password)
        {
            AccountRecord accountRecord = new AccountRecord();
            //send a sql query asking for a record that matches an entry in AccountTable with the specified username
            string findCommandText = $"SELECT * FROM AccountTable WHERE Username = '{userName}';";
            SqlCommand findCommand = new SqlCommand(findCommandText, databaseConnection);
            try
            {
                //read the account that matches the username request
                using (SqlDataReader accountReader = findCommand.ExecuteReader())
                {
                    accountReader.Read();
                    //store account data from SQL record in the AccountRecord object
                    accountRecord.Username = accountReader["Username"].ToString();
                    accountRecord.Salt = accountReader["Salt"].ToString();
                    accountRecord.SaltedHash = accountReader["SaltedHash"].ToString();
                }
                accountRecord.ErrorString = "valid record";
                if (accountRecord.SaltedHash != GeneratePasswordHash(password, accountRecord.Salt))
                {
                    accountRecord = new AccountRecord();
                    accountRecord.ErrorString = "password incorrect";
                }
            }
            catch (Exception e)
            {
                //if no record found, return an empty object with error message labeled "No record found"
                accountRecord = new AccountRecord();
                accountRecord.ErrorString = "no record found";
            }
            return accountRecord;
        }
        public bool AddAccountRecord(AccountRecord accountRecord, string password)
        {
            //Look for existing username in database
            AccountRecord existingAccountRecord = new AccountRecord();
            existingAccountRecord = LookUpAccountRecord(accountRecord.Username, null);
            if (existingAccountRecord.ErrorString != "no record found")
            {
                return true;
            }
            else
            {
                //Generate a salt for the account
                accountRecord.Salt = GenerateSalt();
                //Generate Salted Hash from Password
                accountRecord.SaltedHash = GeneratePasswordHash(password, accountRecord.Salt);
                //build SQL Command String from AccountRecord class
                string insertCommandText = $"INSERT INTO AccountTable (Username, Salt, SaltedHash) " +
                                           $"VALUES ('{accountRecord.Username}','{accountRecord.Salt}','{accountRecord.SaltedHash}');";
                try
                {
                    ExecuteSqlSendCommand(insertCommandText);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return true;
                }
                return false;
            }
        }

        private static string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltArray = new byte[3];
            rng.GetBytes(saltArray);
            //return a string version of the random number generated as salt
            return Convert.ToBase64String(saltArray);
        }
        private static string GeneratePasswordHash(string password, string salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            //combine salt and password
            string saltAndPassword = String.Concat(password, salt);
            //generate hash
            byte[] saltAndPasswordBytes = Encoding.ASCII.GetBytes(saltAndPassword);
            byte[] passwordHashBytes = algorithm.ComputeHash(saltAndPasswordBytes);
            //return a string version of the generated hash
            return Convert.ToBase64String(passwordHashBytes);
        }

        public void ChangeAccountRecordPassword()
        {
            //pull the salt and user, generate a new hash and store it
        }

        private void FindAccountRecord()
        {
            //returns an account record for use elsewhere
        }

        private void ComparePassword(AccountRecord accountRecord, string password)
        {
            //pulls the hash and salt from the account record and compares it to the string
        }
    }
}
