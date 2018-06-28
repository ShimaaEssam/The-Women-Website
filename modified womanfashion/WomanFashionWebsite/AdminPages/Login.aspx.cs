using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPages_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Login_Click(object sender, EventArgs e)
    {
        Lbl_status.Text = "";
        WomenFashionEntities entity = new WomenFashionEntities();

        String UserNm = txt_username.Text.Trim();
        String Pass = txt_password.Text.Trim();
        //7aga shabh el variable (tab ) 3shan n2dar n access el columns el gowa el table
        var CheckIfFoundOrNot = (from tab in entity.Admin where (tab.UserName == UserNm && tab.Password == Pass) select tab).FirstOrDefault();


        if (CheckIfFoundOrNot != null) // If Matched
        {
            Session["UserName"] = UserNm;
            Response.Redirect("../AdminPages/Add.aspx");
        }
        else
        {
            txt_username.Text = "";
            txt_password.Text = "";
          Lbl_status.Text = "InCorrect UserName or Password !";
        }
    }
   
}