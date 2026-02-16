/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is where the user will make new accounts for himself. */
////////////////////////////////////////////////////////////////////
using Billion_Bank___Project.DbWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billion_Bank___Project
{
    public partial class Create_Account : System.Web.UI.Page
    {
        DbWebServiceSoapClient service;
        string useValue = ""; //This will be used later on as the cookie of this session.
        DateTime curdate = DateTime.Now.Date; //Gets the current date only.
        int curBalance; //This will be used later on to specify how much cash an account has.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] == null) //If the user is not logged in, redirect him to the log in page.
            {
                Response.Redirect("~/Log In Page.aspx"); //The form they are sent to.
            }

            service = new DbWebServiceSoapClient();
            
            service.ConnectDB(); //Here we are calling a webmethod to connect us to the database.
        }

        protected void btnAccept_Click(object sender, EventArgs e) //If this button is clicked, the following will happen.
        {
            useValue = Session["loggedUser"].ToString(); //The cookie of this session.
            if (service.AccExists(useValue) == true) //If the user already has an account, this account will receive no cash.
            {
                curBalance = 0; //This account's balance.
            }

            else if (service.AccExists(useValue) == false) //If this is the first account created by a user, this account will receive R100.
            {
                curBalance = 100; //This account's balance.
            }

            if (service.CreateAccount(txtAccountNumber.Text, curdate, curBalance, useValue) == true) //This webmethod will be used to create an account. If it's successful, the following will happen.
            {
                Response.Redirect("~/Accounts.aspx"); //The page you are redirected to.
            }

            else //If the creation of the account is unsuccessful, the following will happen.
            {
                lblFailure.Visible = true; //The error that will be displayed.
            }
        }
    }
}