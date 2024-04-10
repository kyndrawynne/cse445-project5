/*
 Code by Alexis Holland
*/
using Project5.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Project5
{
    public partial class StepsToSavings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculateSavings_Click(object sender, EventArgs e)
        {
            int steps;
            decimal gasPrice;


            // Parse user input for number of steps and gas price.
            if (int.TryParse(txtSteps.Text, out steps) && decimal.TryParse(txtGasPrice.Text, out gasPrice))
            {
                // Instantiate the service client.
                var client = new Service1Client();

                try
                {

                    // Call the StepsToSavings method from service and display the result.
                    string savings = client.StepsToSavings(steps, gasPrice);
                    lblSavingsResult.Text = savings;

                }
                catch (Exception ex)
                {
                    // Display error message.
                    lblSavingsResult.Text = "Error: " + ex.Message;
                }

            }

            else
            {
                // Display error if input is invalid.
                lblSavingsResult.Text = "Invalid input for steps or gas price";
            }
        }
    }
}