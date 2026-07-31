using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string RangeValSeverity(int val)
    {
        string result="";
        if (val <= 100)
        {
            result = "";
        }
        else
        {
            result = "Severity must be less then 100%";
        }
        return result;
    }
 
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        //Label1.Text = RangeValSeverity(int.Parse(TextBox1.Text));

    }
}