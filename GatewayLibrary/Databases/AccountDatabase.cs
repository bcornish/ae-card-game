﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using GatewayLibrary.Records;

namespace GatewayLibrary.Databases
{
    public class AccountDatabase : GameDatabase
    {
        #region Public Methods
        // Check to see whether a username/password combination exists in the Account Database
        public AccountRecord LookUpAccountRecord(string userName, string password)
        {
            AccountRecord accountRecord = new AccountRecord();
            // Send a SQL query asking for a record that matches the Username in AccountRecord
            string findCommandText = $"SELECT * FROM AccountTable WHERE Username = '{userName}';";
            SqlCommand findCommand = new SqlCommand(findCommandText, databaseConnection);
            try
            {
                // Read the account that matches the Username request
                using (SqlDataReader accountReader = findCommand.ExecuteReader())
                {
                    accountReader.Read();
                    // Store all account data from the acquired SQL record in the AccountRecord object
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
                // If no record is found, return an empty object with error message labeled "No record found"
                accountRecord = new AccountRecord();
                accountRecord.ErrorString = "no record found";
            }
            return accountRecord;
        }
        public bool AddAccountRecord(AccountRecord accountRecord, string password)
        {
            // Make sure there is not an existing Username in Account Database
            AccountRecord existingAccountRecord = new AccountRecord();
            existingAccountRecord = LookUpAccountRecord(accountRecord.Username, null);
            if (existingAccountRecord.ErrorString != "no record found")
            {
                return true;
            }
            else
            {
                // Generate a salt for the account
                accountRecord.Salt = GenerateSalt();
                // Generate Salted Hash from Password and Salt
                accountRecord.SaltedHash = GeneratePasswordHash(password, accountRecord.Salt);
                // build SQL Command String to send new record to SQL
                string insertCommandText = $"INSERT INTO AccountTable (Username, Salt, SaltedHash) " +
                                           $"VALUES ('{accountRecord.Username}','{accountRecord.Salt}','{accountRecord.SaltedHash}');";
                try
                {
                    ExecuteSqlSendCommand(insertCommandText);
                }
                catch (Exception e)
                {
                    //TODO: Determine whether any additional error reporting is necessary
                    return true;
                }
                return false;
            }
        }

        public void ChangeAccountRecordPassword()
        {
            //TODO: pull the Username, generate a new hash and store it
        }
#endregion

        #region Private Methods
        private static string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltArray = new byte[3];
            rng.GetBytes(saltArray);
            // Return a string version of the random number generated as salt
            return Convert.ToBase64String(saltArray);
        }
        private static string GeneratePasswordHash(string password, string salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            // Combine the salt and password
            string saltAndPassword = String.Concat(password, salt);
            // Generate the salted hash
            byte[] saltAndPasswordBytes = Encoding.ASCII.GetBytes(saltAndPassword);
            byte[] passwordHashBytes = algorithm.ComputeHash(saltAndPasswordBytes);
            // Return a string version of the generated hash
            return Convert.ToBase64String(passwordHashBytes);
        }
        #endregion
    }
}
