/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is the form the user will use to identify what it is he wants to do. */
////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billion_Bank___Project
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] == null) //If the user is not logged in, redirect him to the log in page.
            {
                Response.Redirect("~/Log In Page.aspx"); //The form they are sent to.
            }
        }

        protected void btnUpdateInfo_Click(object sender, EventArgs e) //This button will redirect you to a page where you can update your information.
        {
            Response.Redirect("~/Update Info.aspx"); //The form they are sent to.
        }

        protected void btnLogOff_Click(object sender, EventArgs e) //This button will end the session and log you out.
        {
            Session.Clear(); //Clears the cookie for this session.
            Response.Redirect("~/First Page.aspx"); //The form you are sent to.
        }

        protected void btnViewAccounts_Click(object sender, EventArgs e) //This button will redirect you to a page where you can view your accounts.
        {
            Response.Redirect("~/Accounts.aspx"); //The form you are sent to.
        }
    }
}