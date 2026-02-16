/* Filename: Billion Bank - Project.cs
 * Programmer: Pieter-Francois van Dyk
 * Date: 2023/05/05
 * Description: This is the first form the user will see, which gives them the option to either sign up or log in. */
////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billion_Bank___Project
{
    public partial class First_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFirstLogIn_Click(object sender, EventArgs e) // If the user clicks this button, he will be redirected to the log in page.
        {
            Response.Redirect("~/Log In Page.aspx"); // Redirects you to the log in page.
        }

        protected void btnFirstSignUp_Click(object sender, EventArgs e) // If the user clicks this button, he will be redirected to the sign up page.
        {
            Response.Redirect("~/Sign Up Page.aspx"); // Redirects you to the log in page.
        }
    }
}