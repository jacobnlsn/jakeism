using System;
using BusinessLayer.Util;
using System.Web.UI.WebControls;

namespace Jakeism
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        public string FeedbackPostback;

        protected void Page_Load(object sender, EventArgs e)
        {
            FeedbackPostback = "false";
        }

        protected void Search(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchbox.Text.Trim()) || searchbox.Text.Equals("Search for a Jakeism..."))
                return;
            var query = searchbox.Text.Trim();
            Response.Redirect("Search.aspx?query=" + query);
        }

        protected void Submit_Feedback(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(name.Text.Trim()) || String.IsNullOrEmpty(email.Text.Trim()) || String.IsNullOrEmpty(feedbackMsg.Text.Trim()))
            {
                fail.Text = "Please fill in all fields";
                fail.Visible = true;
                FeedbackPostback = "true";
                return;
            }
            if (!Util.IsEmail(email.Text.Trim()))
            {
                fail.Text = "Invalid email address";
                fail.Visible = true;
                FeedbackPostback = "true";
                return;
            }
            var fromEmail = email.Text.Trim();
            var message = "Sent By: " + name.Text.Trim() + " (" + fromEmail + ")\n\n" + feedbackMsg.Text.Trim();
            Util.SendEmail("Jakeism Feedback", message, Constants.FEEDBACK_EMAIL);
            FeedbackPostback = "false";
            fail.Visible = false;
            name.Text = "";
            email.Text = "";
            feedbackMsg.Text = "";
        }
    }
}
