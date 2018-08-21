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
        public void AddAccountRecord(AccountRecord accountRecord, string password)
        {
            //Generate a salt for the account
            accountRecord.salt = GenerateSalt();
            //Generate Salted Hash from Password
            accountRecord.saltedHash = GeneratePasswordHash(password, accountRecord.salt);
            //build SQL Command String from AccountRecord class
            string insertCommandText = $"INSERT INTO AccountTable (Username, Salt, SaltedHash) " +
                                       $"VALUES ('{accountRecord.userName}','{accountRecord.salt}','{accountRecord.saltedHash}');";
            SqlCommand command = new SqlCommand(insertCommandText, databaseConnection);
            command.ExecuteNonQuery();
        }

        private static string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltArray = new byte[12];
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
            byte[] saltAndPasswordBytes = Convert.FromBase64String(saltAndPassword);
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
