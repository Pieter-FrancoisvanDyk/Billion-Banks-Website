/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is the form the user will use to log in to his account. */
////////////////////////////////////////////////////////////////////
using Billion_Bank___Project.DbWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billion_Bank___Project
{
    public partial class Log_In_Page : System.Web.UI.Page
    {
        DbWebServiceSoapClient logService; //Giving our webservice a name.
        protected void Page_Load(object sender, EventArgs e)
        {
            logService = new DbWebServiceSoapClient();
            logService.ConnectDB(); //Here we are calling a webmethod to connect us to the database.
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            string loginResults = logService.VerifyLogIn(txtEmailLog.Text, txtPasswordLog.Text); //This webmethod is used to verify if the log in details are correct.

            if (loginResults == "") //If the return type is blank, the following error will be displayed.
            {
                lblLogError.Text = "Please fill in valid log in information."; //The error that will be displayed.
            }

            else //If anything else is returned, a cookie is created and the user is redirected to a new form.
            {
                Session["loggedUser"] = loginResults; //The cookie
                Response.Redirect("~/Home.aspx"); //The form they are sent to.
            }
        }
    }
}