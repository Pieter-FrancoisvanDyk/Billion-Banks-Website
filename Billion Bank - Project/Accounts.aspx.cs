/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is the form the user will use to view all of his accounts. */
////////////////////////////////////////////////////////////////////
using Billion_Bank___Project.DbWebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billion_Bank___Project
{
    public partial class Accounts : System.Web.UI.Page
    {
        DbWebServiceSoapClient service; //Giving our webservice a name.

        protected void LoadUserAccounts() //The purpose of this method is indicate the design of the gridview.
        {
            DataTable accTables = new DataTable("Account"); //Creation of a datatable.
            DataColumn dtColumn; //The name of our columns.
            DataRow dtRow; //The name of our rows.

            service = new DbWebServiceSoapClient(); 
            string userAccounts = service.VerifyUserAccounts(Convert.ToString(Session["loggedUser"])); //This webmethod is used to retreive all the values that need to be inserted into the gridview.

            dtColumn = accTables.Columns.Add("Account ID", typeof(string)); //Creation of our first column
            dtColumn.AllowDBNull = false; //This column may not be null.
            dtColumn.Unique = true; //This column must be unique.

            accTables.Columns.Add("Creation Date", typeof(string)); //Creation of our second column.
            accTables.Columns.Add("Balance", typeof(string)); //Creation our third column.

            if (userAccounts == "Failed") //If the return value is false, display this error.
            {
                lblAccNotFound.Visible = true; //The error that will be displayed.
            }

            else //If anything else is returned, the following happens.
            {
                lblAccNotFound.Visible = false; //The error is no longer displayed.

                string[] accounts = userAccounts.Split('|'); //An array is created that will split the string that was returned and declare each value as its own account.
                string[] accountDetails; //A second array is created that will be used to split the different attributes of an account.

                foreach (string account in accounts) //This will loop through each account.
                {
                    if (account != string.Empty) //If there is a value stored in account, the following happens.
                    {
                        accountDetails = (account.Split('#')); //The account string is now split to store the attributes of an account.
                        dtRow = accTables.NewRow(); //Creates new row.
                        dtRow["Account ID"] = Convert.ToString(accountDetails[0]); //Store the first value of the array in the Account ID column.
                        dtRow["Creation Date"] = accountDetails[1]; //Store the second value of the array in the Creation Date column.
                        dtRow["Balance"] = "R" + accountDetails[2]; //Store the third value of the array in the Balance column.
                        accTables.Rows.Add(dtRow); //Adds this row to the table.
                    }
                }
            }
            gvAccounts.DataSource = accTables; //Implements the datatable into the gridview.
            gvAccounts.DataBind(); //Binds the data.
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] == null) //If the user is not logged in, redirect him to the log in page.
            {
                Response.Redirect("~/Log In Page.aspx"); //The form they are sent to.
            }

            LoadUserAccounts(); //Loads the method.
        }

        protected void btnTransfer_Click(object sender, EventArgs e) //This button will switch from viewing accounts to transfering money.
        {
            gvAccounts.Visible = false;
            hCreateAccount.Visible = false;
            btnTransfer.Visible = false;
            lblSuccessTransfer.Visible = false; //All the controls that aren't needed anymore are removed.
            lblTransferAcc.Visible = true;
            lblDestinationAcc.Visible = true;
            ddlTransferAcc.Visible = true;
            ddlDestinationAcc.Visible = true;
            lblAmount.Visible = true;
            txtTransferAmount.Visible = true;
            btnTransfer2.Visible = true;  //All the new controls are added.

            service = new DbWebServiceSoapClient();

            string numbers = service.VerifyTransferAccounts(Convert.ToString(Session["loggedUser"])); //This webmethod retreives all the accounts that the user owns.

            if (numbers == "Failed") // If the return value is equals to this, an error will be displayed.
            {
                lblAccNotFound.Visible = true; //The error that will be displayed.
            }

            else //If anything else is returned, the following will happen.
            {
                lblAccNotFound.Visible = false; //The error is no longer displayed.

                string[] accNumbers = numbers.Split('|'); //An array is created that will split the string that was returned and declare each value as its own account.

                foreach (string accNumber in accNumbers) //This will loop through each account.
                {
                    ddlTransferAcc.Items.Add(Convert.ToString(accNumber)); 
                    ddlDestinationAcc.Items.Add(Convert.ToString(accNumber)); //Adds each account to the dropdownlists.
                }
            }
        }

        protected void btnTransfer2_Click(object sender, EventArgs e) //This button will transfer the money and switch from transfering money to viewing accounts.
        {
            service = new DbWebServiceSoapClient();

            string num = service.CheckTransAmount(ddlTransferAcc.SelectedItem.ToString()); //This method makes sure that the user doesn't try to transfer more money than the account has. 
            int number = Convert.ToInt32(num); //Converts that number to an int.

            bool transferValue = service.TransferMoney(ddlTransferAcc.SelectedItem.ToString(), ddlDestinationAcc.SelectedItem.ToString(), txtTransferAmount.Text); //This method is used to make sure that the tranfer is saved and that money is transfered from one account to another.

            

            if (ddlTransferAcc.SelectedItem.ToString() == ddlDestinationAcc.SelectedItem.ToString()) //If the user is trying to send cash to the same account as the source account, an error will appear.
            {
                lblTransferError.Visible = true; //The error that will appear.
            }

            else if (txtTransferAmount.Text == null) //If the user doesn't specify the amount of cash that should be transfered, an error will appear.
            {
                lblTransferError.Visible = true; //The error that will appear.
            }

            else if (num == "Failed") //If the return value is equal to this, an error will appear.
            {
                lblTransferError.Visible = true; //The error that will appear.
            }

            else if (Int32.Parse(txtTransferAmount.Text) > number) //If the amount of cash the user wants to transfer is greater than the amount of cash in the user's source account, an error will appear.
            {
                lblTransferError.Visible = true; //The error that will appear.
            }

            else if (transferValue == false) //If the transaction fails for whatever reason, this error is displayed.
            {
                lblTransferError.Visible = true; //The error that will appear.
            }
            else if (transferValue == true) //If the transaction is successful this will happen.
            {
                gvAccounts.Visible = true;
                hCreateAccount.Visible = true;
                btnTransfer.Visible = true;
                lblSuccessTransfer.Visible = true; //All the new controls are added.
                lblTransferAcc.Visible = false;
                lblDestinationAcc.Visible = false;
                ddlTransferAcc.Visible = false;
                ddlDestinationAcc.Visible = false;
                lblAmount.Visible = false;
                txtTransferAmount.Visible = false;
                btnTransfer2.Visible = false; //All the controls that aren't needed anymore are removed.

                Response.Redirect(Request.RawUrl); //Makes sure that the page reloads properly.
            }
        }
    }
}