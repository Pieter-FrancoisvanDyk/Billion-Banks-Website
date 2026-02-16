/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This form will allow the user to update his details. */
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
    public partial class Update_Info : System.Web.UI.Page
    {
        DbWebServiceSoapClient service; //Giving our webservice a name.
        string useValue = ""; //Use value will be used later on as a namespace for the cookie.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] == null) //If the user is not logged in, redirect him to the log in page.
            {
                Response.Redirect("~/Log In Page.aspx"); //The form they are sent to.
            }

            service = new DbWebServiceSoapClient(); 
            service.ConnectDB(); //Here we are calling a webmethod to connect us to the database.
        }

        protected void btnUpdateName_Click(object sender, EventArgs e) //This button is used to update the user's name.
        {
            useValue = Session["loggedUser"].ToString(); //Assigning the cookie to the useValue placeholder.

            if (txtNameUpdate.Text == "") //If the textbox is left blank, the following error will appear.
            {
                lblNameFailure.Text = "Please enter data into this field"; //The error that will be displayed.
            }

            else //If anything else is returned, the following will happen.
            {
                if (service.UpdatePersonalName(txtNameUpdate.Text, useValue) == true) //This webmethod will update the user's name to his new desired one.
                {
                    lblNameFailure.Text = "Successfully changed"; //The error label is reused to display message when the update is successful.
                }

                else //If the return value is false, the following error will appear.
                {
                    lblNameFailure.Text = "Please enter data into this field"; //The error that will be displayed.
                }
            }
        }

        protected void btnUpdateEmail_Click(object sender, EventArgs e) //This button is used to update the user's e-mail.
        {
            useValue = Session["loggedUser"].ToString(); //Assigning the cookie to the useValue placeholder.

            if (txtEmailUpdate.Text == "") //If the textbox is left blank, the following error will appear.
            {
                lblEmailFailure.Text = "Please enter data into this field"; //The error that will be displayed.
            }

            else //If anything else is returned, the following will happen.
            {
                if (service.UpdatePersonalEmail(txtEmailUpdate.Text, useValue) == true) //This webmethod will update the user's e-mail to his new desired one.
                {
                    lblEmailFailure.Text = "Successfully changed"; //The error label is reused to display message when the update is successful.
                }

                else //If the return value is false, the following error will appear.
                {
                    lblEmailFailure.Text = "Please enter data into this field"; //The error that will be displayed.
                }
            }
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e) //This button is used to update the user's password.
        {
            useValue = Session["loggedUser"].ToString(); //Assigning the cookie to the useValue placeholder.

            if (txtPasswordUpdate.Text == "") //If the textbox is left blank, the following error will appear.
            {
                lblPasswordFailure.Text = "Please enter data into this field"; //The error that will be displayed.
            }

            else //If anything else is returned, the following will happen.
            {
                if (service.UpdatePersonalPassword(txtPasswordUpdate.Text, useValue) == true) //This webmethod will update the user's password to his new desired one.
                {
                    lblPasswordFailure.Text = "Successfully changed"; //The error label is reused to display message when the update is successful.
                }

                else //If the return value is false, the following error will appear.
                {
                    lblPasswordFailure.Text = "Please enter data into this field"; //The error that will be displayed.
                }
            }
        }
    }
}