using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_Home : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

  
    protected void btn_search_Click(object sender, EventArgs e)
    {
        WomenFashionEntities entity = new WomenFashionEntities();

        //ana 3ayza a3ml select lel color mn l database 
        string InputSearch = txt_Search.Value.Trim().ToString();

        var allobj = (from ob in entity.Fashion_Item where (ob.Color.ColorName.ToLower() == InputSearch.ToLower())
                      select new { ob.Item_Description, ob.Color.ColorName, ob.ImageURL, ob.category.categoryhtml, ob.Price }).ToList();

        Session["AllSearchData"] = allobj;
        Response.Redirect("../UserPages/Search.aspx");
        
    }
}
