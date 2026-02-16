/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is the form the user will use to sign up for an account. */
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
    public partial class Sign_Up_Page : System.Web.UI.Page
    {
        DbWebServiceSoapClient service; //Giving our webservice a name.
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new DbWebServiceSoapClient();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (service.ConnectDB() == true) //If connection to the database was successfull, the following will happen.
            {
                bool insertResult = service.InsertData(txtID.Text, txtName.Text, txtEmail.Text, txtPassword.Text, ddlQuetion.SelectedValue.ToString(), txtAnswer.Text);
                //The above webmethod will insert the values entered by the user into the database.
                if (insertResult == true) //If the insert was successful, the following happens.
                {
                    Response.Redirect("~/Log In Page.aspx"); //The form they are sent to.
                }

                else //If the insert was unsuccessful, the following happens.
                {
                    lblError.Text = "Failure to insert! You may have inserted too many characters into the textboxes or inserted incorrect data."; //The error that will be displayed.
                }
            }

            else //If connection to the database was unsuccessfull, the following will happen.
            {
                lblError.Text = "Connection Failed!"; //The error that will be displayed.
            }
        }
    }
}