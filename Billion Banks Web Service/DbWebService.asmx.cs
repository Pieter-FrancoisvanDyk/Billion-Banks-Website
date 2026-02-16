/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is the form the user will use to sign up for an account. */
////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Billion_Banks_Web_Service
{
    /// <summary>
    /// Summary description for DbWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DbWebService : System.Web.Services.WebService
    {
        public static SqlConnection sqlConn;
        [WebMethod]
        public bool ConnectDB() //This webmethod is used to connect to the database.
        {
            try
            {
                string stringConn = @"Data Source=LAPTOP-TQEHJL0T\SQLEXPRESS;Initial Catalog=BankingDetails;Integrated Security=True"; //The connection string.
                
                sqlConn = new SqlConnection(stringConn); //Declaring the above string as the connection.
                sqlConn.Open(); //Opens the connection.
                return true;
                //The above statement will connect to the database if successful.
            }
            catch
            {
                return false;
                //Else, if the try fails, the false is returned and the connection fails.
            }
        }

        [WebMethod]
        public bool InsertData(string cID, string cName, string cEmail, string cPassword, string cQuestion, string cAnswer) //This webmethod is used to insert the details of the customer that just signed up.
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO CUSTOMER (cusIDNumber, cusName, cusEmail, cusPassword, cusQuestion, cusAnswer) VALUES ('" + cID + "', '" + cName + "', '" + cEmail + "', '" + cPassword + "', '" + cQuestion + "', '" + cAnswer + "')", sqlConn);
                //The above statement contains a sql insert statement that will insert the values sent to the webmethod into the customer table.
                cmd.ExecuteNonQuery(); //Executes the above command.
                return true;
                //The above statement will insert the data into the table if successful.
            }
            catch
            {
                return false;
                //Else, if the try fails, the false is returned and the insert fails.
            }
        }

        [WebMethod]
        public string VerifyLogIn(string lEmail, string lPassword) //This webmethod is used to verify wether or not the log in details entered by the user are correct.
        {
            try
            {
                SqlCommand cmdVerify = new SqlCommand("SELECT * FROM Customer WHERE cusEmail = '" + lEmail + "' AND cusPassword = '" + lPassword + "'", sqlConn);
                //The above statement contains a sql select statement that will obtain the values related to the values sent to the webmethod.
                SqlDataReader dr = cmdVerify.ExecuteReader(); //Executes the above command.

                string lID = ""; //This string will be used later on to hold the cookie.

                if (dr.Read()) //If data is read from the above statement, execute the below statement.
                {
                    lID = (string)dr["cusIDNumber"]; //The session cookie.
                    return lID; //Returns the above cookie.
                }
                //If the above is true, the user is logged in and session cookie is created.
                else
                {
                    return "";
                }
                //Else return blank for failure.
            }
            catch
            {
                return "";
            }
            //Else, if the try fails, the false is returned and the log in fails.
        }

        [WebMethod]
        public string VerifyEmail(string vEmail) //This webmethod is used to verify wether or not the email given for the forgot password page actually exists.
        {
            try
            {
                SqlCommand cmdEmail = new SqlCommand("SELECT * FROM Customer WHERE cusEmail = '" + vEmail + "'", sqlConn);
                //The above statement contains a sql select statement that will obtain the values related to the values sent to the webmethod.
                SqlDataReader drEmail = cmdEmail.ExecuteReader(); //Executes the above command.

                if (drEmail.Read()) //If data is read from the above statement, execute the below statement.
                {
                    // Obtain ID (PK)
                    string eQuestion = ""; //This string will be used later on to hold the cookie.

                    eQuestion = (string)drEmail["cusQuestion"]; //The session cookie.

                    return eQuestion; //Returns the above cookie.
                }
                //If the above is true, a cookie is created for the forgot passwrod session and that email is returned.
                else
                {
                    return "";
                }
                //Else return blank for failure.
            }
            catch
            {
                return "";
            }
            //Else, if the try fails, the false is returned and the email verification fails.
        }

        [WebMethod]
        public bool VerifyAnswer(string vAnswer) //This webmethod is used to verify wether or not the answer given for question on the forgot password page is true.
        {
            try
            {
                SqlCommand cmdAnswer = new SqlCommand("SELECT * FROM Customer WHERE cusAnswer = '" + vAnswer + "'", sqlConn);
                //The above statement contains a sql select statement that will obtain the values related to the values sent to the webmethod.
                SqlDataReader drAnswer = cmdAnswer.ExecuteReader(); //Executes the above command.

                if (drAnswer.Read()) //If data is read from the above statement, execute the below statement.
                {
                    return true;
                }
                //If the answer is found, return true.
                else
                {
                    return false;
                }
                //Else return false for failure.
            }
            catch
            {
                return false;
                //Else, if the try fails, the false is returned and the answer verification fails.
            }
        }

        [WebMethod]
        public bool UpdatePassword(string uPassWord, string uEmail) //This webmethod is used to change the password of the given email to the user's new desired password.
        {
            try
            {
                SqlCommand cmdAnswer = new SqlCommand(@"UPDATE Customer SET cusPassword = '" + uPassWord + "' WHERE cusEmail = '" + uEmail + "'", sqlConn);
                //The above statement contains a sql update statement that will change the values related to the values sent to the webmethod.
                cmdAnswer.ExecuteNonQuery(); //Executes the above command.
                return true;
            }
            //The password will be updated if the above executes successfully.
            catch
            {
                return false;
                //Else, if the try fails, the false is returned and the update on the new password fails.
            }
        }

        [WebMethod]
        public bool UpdatePersonalName(string pName, string userID) //This webmethod is used to change the name of the user to the name entered into the textbox.
        {
            try
            {
                SqlCommand cmdUpName = new SqlCommand(@"UPDATE Customer SET cusName = '" + pName + "' WHERE cusIDNumber = '" + userID + "'", sqlConn);
                //The above statement contains a sql update statement that will change the values related to the values sent to the webmethod.
                cmdUpName.ExecuteNonQuery(); //Executes the above command.
                return true;
            }
            //The name will be updated if the above executes successfully.
            catch
            {
                return false;
                //Else, if the try fails, the false is returned and the update on the new user name fails.
            }
        }

        [WebMethod]
        public bool UpdatePersonalEmail(string pEmail, string userID) //This webmethod is used to change the email of the account of the user to the email entered into the textbox.
        {
            try
            {
                SqlCommand cmdUpEmail = new SqlCommand(@"UPDATE Customer SET cusEmail = '" + pEmail + "' WHERE cusIDNumber = '" + userID + "'", sqlConn);
                //The above statement contains a sql update statement that will change the values related to the values sent to the webmethod.
                cmdUpEmail.ExecuteNonQuery(); //Executes the above command.
                return true;
            }
            //The email will be updated if the above executes successfully.
            catch
            {
                return false;
                //Else, if the try fails, the false is returned and the update on the new user email fails.
            }
        }

        [WebMethod]
        public bool UpdatePersonalPassword(string pPassword, string userID) //This webmethod is used to change the password of the account of the user to the password entered into the textbox.
        {
            try
            {
                SqlCommand cmdUpPassword = new SqlCommand(@"UPDATE Customer SET cusPassword = '" + pPassword + "' WHERE cusIDNumber = '" + userID + "'", sqlConn);
                //The above statement contains a sql update statement that will change the values related to the values sent to the webmethod.
                cmdUpPassword.ExecuteNonQuery(); //Executes the above command.
                return true;
            }
            //The password will be updated if the above executes successfully.
            catch
            {
                return false;
                //Else, if the try fails, the false is returned and the update on the new password fails.
            }
        }

        [WebMethod]
        public bool AccExists(string userID) //This webmethod is used to verify wether or not the user owns an account.
        {
            try
            {
                ConnectDB(); //Here for testing purposes.
                SqlCommand checkNumofAcc = new SqlCommand(@"SELECT * FROM Account WHERE cusIDNumber = '" + userID + "'", sqlConn);
                //The above statement contains a sql select statement that will obtain the values related to the values sent to the webmethod.
                SqlDataReader check = checkNumofAcc.ExecuteReader(); //Executes the above command.

                if (check.Read()) //If data is read from the above statement, execute the below statement.
                {
                    return true;
                    //This will indicate that the user already has an account.
                }

                else
                { 
                    return false;
                    //This will indicate that the user doesn't have an account.
                }
            }

            catch (Exception ex)
            {
                return false;
                //Else, if the try fails, the false is returned.
            }
        }

        [WebMethod]
        public bool CreateAccount(string cAccNum, DateTime cAccDate, int cAccBalance, string userID) //This webmethod will be used to create a new account..
        {
            try
            {
                ConnectDB(); //Here for testing purposes.
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Account (accNumber, accDateOC, accBalance, cusIDNumber) VALUES ('" + cAccNum + "', '" + cAccDate + "', '" + cAccBalance + "', '" + userID + "')", sqlConn);
                //The above statement contains a sql insert statement that will insert the values sent to the webmethod into the customer table.
                cmd.ExecuteNonQuery(); //Executes the above command.
                return true;
                //The above statement will insert the data into the table if successful.
            }
            catch
            {
                return false;
                //Else, if the try fails, the false is returned and the creation of a new account fails.
            }
        }

        [WebMethod]
        public string VerifyUserAccounts(string userID) //This webmethod is used to verify which accounts belong to the user.
        {
            try
            {
                ConnectDB(); //Here for testing purposes.
                SqlCommand cmdShow = new SqlCommand("SELECT accNumber, accDateOC, accBalance FROM Account WHERE cusIDNumber = '" + userID + "'", sqlConn);
                //The above statement contains a sql select statement that will obtain the values related to the values sent to the webmethod.
                SqlDataReader drShow = cmdShow.ExecuteReader(); //Executes the above command.
                string returnValue = ""; //This will be used later on to hold the string that will be returned.
                int length; //This will be used later on to remove on character from the string so that we don't end up with an empty column.

                while (drShow.Read()) //While data is read from the above statement, execute the below statement.
                {
                    returnValue += drShow[0].ToString() + "#" + drShow[1].ToString() + "#" + drShow[2].ToString() + "|";
                    //The above will put every account and all of their attributes into one string.
                }

                length = returnValue.Length - 1;
                returnValue = returnValue.Remove(length, 1);
                //The above removes that single character.
                return returnValue;
                //Returns the string.
            }

            catch 
            {
                return "Failed";
                //Else, if the try fails, "Failed" is returned and the verification of accounts fails.
            }
        }

        [WebMethod]
        public string VerifyTransferAccounts(string userID) //This webmethod is used to retreive all the accounts and their attributes related to the user ID.
        {
            try
            {
                ConnectDB(); //Here for testing purposes.
                SqlCommand sqlC = new SqlCommand("SELECT accNumber FROM Account WHERE cusIDNumber = '" + userID + "'", sqlConn);
                //The above statement contains a sql select statement that will obtain the values related to the values sent to the webmethod.
                SqlDataReader rC = sqlC.ExecuteReader(); //Executes the above command.
                string accNumbers = ""; //This will be used later on to hold the string that will be returned.

                while (rC.Read()) //While data is read from the above statement, execute the below statement.
                {
                    accNumbers += rC[0].ToString() + "|";
                    //The above will put every account into one string.
                }

                int length = accNumbers.Length - 1;
                accNumbers = accNumbers.Remove(length, 1);
                //The above removes that single character.
                return accNumbers;
                //Returns the string.
            }

            catch (Exception ex)
            {
                return "Failed";
                //Else, if the try fails, "Failed" is returned and the verification of accounts fails.
            }
        }

        [WebMethod]
        public string CheckTransAmount(string accID) //This webmethod is used to make sure the user transfers a valid amount.
        {
            try
            {
                ConnectDB(); //Here for testing purposes.
                SqlCommand sqlC = new SqlCommand("SELECT accBalance FROM Account WHERE accNumber = '" + accID + "'", sqlConn);
                //The above statement contains a sql select statement that will obtain the values related to the values sent to the webmethod.
                SqlDataReader rC = sqlC.ExecuteReader(); //Executes the above command.
                string balance = ""; //This will be used later on to hold the string that will be returned.
                
                while (rC.Read()) //While data is read from the above statement, execute the below statement.
                {
                    balance = rC[0].ToString();
                    //The above will put the balance into one string.
                }
                return balance;
                //Returns the string.
            }

            catch
            {
                return "Failed";
                //Else, if the try fails, "Failed" is returned and the checking of transfer amounts fails.
            }
        }

        [WebMethod]
        public bool TransferMoney(string sourceAccID, string destinationAccID, string transferAmount) //This webmethod transfers money between accounts.
        {
            try  
            {
                ConnectDB(); //Here for testing purposes.
                SqlCommand sqlC = new SqlCommand("INSERT INTO TransactionInfo (sourceAcc, destinationAcc, transferAmount, accNumber) VALUES ('" + sourceAccID + "', '" + destinationAccID + "', '" + transferAmount + "', '" + sourceAccID + "')", sqlConn);
                //The above statement contains a sql insert statement that will insert the values sent to the webmethod into the customer table.
                sqlC.ExecuteNonQuery(); //Executes the above command.

                SqlCommand upSourceVal = new SqlCommand(@"UPDATE Account SET accBalance = accBalance - '" + Int32.Parse(transferAmount) + "' WHERE accNumber = '" + sourceAccID + "'", sqlConn);
                //The above statement contains a sql update statement that will change the values related to the values sent to the webmethod.
                upSourceVal.ExecuteNonQuery(); //Executes the above command.

                SqlCommand upDestinationVal = new SqlCommand(@"UPDATE Account SET accBalance = accBalance + '" + Int32.Parse(transferAmount) + "' WHERE accNumber = '" + destinationAccID + "'", sqlConn);
                //The above statement contains a sql update statement that will change the values related to the values sent to the webmethod.
                upDestinationVal.ExecuteNonQuery(); //Executes the above command.

                return true;
                //The money will be transfered if the above executes successfully.
            }

            catch
            {
                return false;
                //Else, if the try fails, false is returned and the transfer of money fails.
            }
        }

        [WebMethod]
        public string VerifyTransaction(string accID) //This webmethod is used to retreive all the transactions related to an account.
        {
            try
            {
                ConnectDB(); //Here for testing purposes.
                SqlCommand cmdShow = new SqlCommand("SELECT transID, sourceAcc, destinationAcc, transferAmount FROM TransactionInfo WHERE accNumber = '" + accID + "'", sqlConn);
                //The above statement contains a sql select statement that will obtain the values related to the values sent to the webmethod.
                SqlDataReader drShow = cmdShow.ExecuteReader(); //Executes the above command.
                string returnValue = ""; //This will be used later on to hold the string that will be returned.
                int length; //This will be used later on to remove on character from the string so that we don't end up with an empty column.

                while (drShow.Read()) //While data is read from the above statement, execute the below statement.
                {
                    returnValue += drShow[0].ToString() + "#" + drShow[1].ToString() + "#" + drShow[2].ToString() + "#" + drShow[3] + "|";
                    //The above will put every transaction and all of their attributes into one string.
                }

                length = returnValue.Length - 1;
                returnValue = returnValue.Remove(length, 1);
                //The above removes that single character.

                return returnValue;
                //Returns the string.
            }

            catch
            {
                return "Failed";
                //Else, if the try fails, "Failed" is returned and the verification of the transactions fails.
            }
        }
    }
}
