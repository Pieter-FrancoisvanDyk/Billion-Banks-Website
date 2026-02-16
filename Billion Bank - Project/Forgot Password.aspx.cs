/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is the form the user will use when he forgets his password and needs to reset it. */
////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Billion_Bank___Project.DbWebService;

namespace Billion_Bank___Project
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        DbWebServiceSoapClient passService; //Giving our webservice a name.
        protected void Page_Load(object sender, EventArgs e)
        {
            passService = new DbWebServiceSoapClient();
        }

        protected void btnEmailSubmit_Click(object sender, EventArgs e)
        {
            passService.ConnectDB(); //Here we are calling a webmethod to connect us to the database.
            string EmailResults = passService.VerifyEmail(txtEmailForgot.Text); //This webmethod is used to confirm that the email given is valid.
            if (EmailResults == "") //If the return type is blank, the following error will be displayed.
            {
                lblErrorForgot.Text = "Incorrect. Please enter correct data"; //The error that will be displayed.
            }

            else //If anything else is returned, the following happens.
            {
                
                lblEmailForgot.Visible = false;
                txtEmailForgot.Visible = false;
                rfvEmailForgot.Visible = false;
                btnEmailSubmit.Visible = false; //All the controls that aren't needed anymore are removed.

                lblQuestionForgot.Text = EmailResults; // The label becomes the return type.
                txtAnswerForgot.Visible = true;
                rfvAswerForgot.Visible = true;
                btnSubmitAnswer.Visible = true; //All the new controls are added.
            }
        }

        protected void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            passService.ConnectDB(); //Here we are calling a webmethod to connect us to the database.

            if (passService.VerifyAnswer(txtAnswerForgot.Text) == true) //This webmethod is used to confirm that the answer given is valid.
            {
                lblQuestionForgot.Visible = false;
                txtAnswerForgot.Visible = false;
                rfvAswerForgot.Visible = false;
                btnSubmitAnswer.Visible = false; //All the controls that aren't needed anymore are removed.

                lblNewPassword.Visible = true;
                txtNewPassword.Visible = true;
                rfvNewPassword.Visible = true;
                btnSubmitPassword.Visible = true; //All the new controls are added.
            }

            else //If the return type is false, the following error is displayed.
            {
                lblErrorForgot.Text = "Incorrect. Please enter correct data"; //The error that will be displayed.
            }
        }

        protected void btnSubmitPassword_Click(object sender, EventArgs e)
        {
            passService.ConnectDB(); //Here we are calling a webmethod to connect us to the database.

            if (passService.UpdatePassword(txtNewPassword.Text, txtEmailForgot.Text) == true) //This webmethod is used to update the password to the new one.
            {
                Response.Redirect("~/Log In Page.aspx"); //The form they are sent to.
            }

            else //If the return type is false, the following error is displayed.
            {
                lblErrorForgot.Text = "Incorrect. Please enter correct data"; //The error that will be displayed.
            }
        }
    }
}