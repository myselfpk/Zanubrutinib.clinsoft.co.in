using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DateTime.Today.ToString("dd-MMM-yyyy") = DateTime.Now.ToString();
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

        DateTime StartDate;

        DateTime EndDate;

        TimeSpan Difference;

        StartDate = Convert.ToDateTime(DateTime.Today.ToString("dd-MMM-yyyy").ToString());

        EndDate = Convert.ToDateTime(TextBox1.Text.ToString());
        Difference = EndDate.Subtract(StartDate);



        lblDifference.Text = Convert.ToString(Difference.Days);


        if ((lblDifference.Text == "1") || (lblDifference.Text == "2") || (lblDifference.Text == "3"))
        {
            Button1.Visible = true;
        }

        else
        {
            Button1.Visible = false;

        }
    }
}