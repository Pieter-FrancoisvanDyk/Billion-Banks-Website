/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is the form the user will use to view all of his recent transactions. */
////////////////////////////////////////////////////////////////////
using Billion_Bank___Project.DbWebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billion_Bank___Project
{
    public partial class Recent_Transactions : System.Web.UI.Page
    {
        DbWebServiceSoapClient service; //Giving our webservice a name.

        protected void LoadUserAccounts() //The purpose of this method is indicate the design of the gridview.
        {
            DataTable transTables = new DataTable("TransactionInfo"); //Creation of a datatable.
            DataColumn dtColumn; //The name of our columns.
            DataRow dtRow; //The name of our rows.

            service = new DbWebServiceSoapClient();
            string accountTransactions = service.VerifyTransaction(ddlAccounts.SelectedItem.Text); //This webmethod is used to retreive all the values that need to be inserted into the gridview.

            dtColumn = transTables.Columns.Add("Transaction ID", typeof(string)); //Creation of our first column
            dtColumn.AllowDBNull = false; //This column may not be null.
            dtColumn.Unique = true; //This column must be unique.

            transTables.Columns.Add("Source Account", typeof(string)); //Creation of our second column.
            transTables.Columns.Add("Destination Account", typeof(string)); //Creation our third column.
            transTables.Columns.Add("Transfer Ammount", typeof(string)); //Creation our fourth column.

            if (accountTransactions == "Failed") //If the return value is false, display this error.
            {
                lblError.Visible = true; //The error that will be displayed.
            }

            else //If anything else is returned, the following happens.
            {
                lblError.Visible = false; //The error is no longer displayed.

                string[] transactions = accountTransactions.Split('|'); //An array is created that will split the string that was returned and declare each value as its own transaction.
                string[] transactionsDetails; //A second array is created that will be used to split the different attributes of a transaction.

                foreach (string transaction in transactions) //This will loop through each transaction.
                {
                    if (transaction != string.Empty) //If there is a value stored in transaction, the following happens.
                    {
                        transactionsDetails = (transaction.Split('#')); //The transaction string is now split to store the attributes of a transaction.
                        if (ddlAccounts.SelectedItem.Text == transactionsDetails[1]) //If the account id is eqaul to the source id, the following can happen.
                        {
                            dtRow = transTables.NewRow(); //Creates new row.
                            dtRow["Transaction ID"] = Convert.ToString(transactionsDetails[0]); //Store the first value of the array in the Transaction ID column.
                            dtRow["Source Account"] = transactionsDetails[1]; //Store the second value of the array in the Source Account column.
                            dtRow["Destination Account"] = transactionsDetails[2]; //Store the third value of the array in the Destination Account column.
                            dtRow["Transfer Ammount"] = "R" + transactionsDetails[3]; //Store the fourth value of the array in the Transfer Amount column.
                            transTables.Rows.Add(dtRow); //Adds this row to the table.
                        }

                        else //If the comparison fails, the following happens.
                        {
                            gvTransactions.Visible = false; //The gridview's visibility is removed.
                            lblError.Visible = true; //The error that is displayed.
                        }
                    }
                }
            }
            gvTransactions.DataSource = transTables; //Implements the datatable into the gridview.
            gvTransactions.DataBind(); //Binds the data.
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] == null) //If the user is not logged in, redirect him to the log in page.
            {
                Response.Redirect("~/Log In Page.aspx"); //The form they are sent to.
            }

            service = new DbWebServiceSoapClient();

            string numbers = service.VerifyTransferAccounts(Convert.ToString(Session["loggedUser"])); //This webmethod retreives all the transactions on the account that the user owns.

            if (numbers == "Failed") // If the return value is equals to this, an error will be displayed.
            {
                lblError.Visible = true; //The error that will be displayed.
            }

            else //If anything else is returned, the following will happen.
            {
                lblError.Visible = false; //The error is no longer displayed.

                string[] accNumbers = numbers.Split('|'); //An array is created that will split the string that was returned and declare each value as its own transaction.

                foreach (string accNumber in accNumbers) //This will loop through each account.
                {
                    ddlAccounts.Items.Add(Convert.ToString(accNumber)); //Adds each account to the dropdownlists.
                }
                
            }
            LoadUserAccounts(); //Loads the method.
        }
    }
}