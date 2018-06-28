using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPages_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["AllSearchData"] != null)
            {
                var allobj = Session["AllSearchData"];
                Repeater_Product.DataSource = allobj;
                Repeater_Product.DataBind();
            }
        }



      
    }

    //protected void Page_LoadComplete(object sender, EventArgs e)
    //{
    //    if (Session["AllSearchData"] != null)
    //    {
    //        var allobj = Session["AllSearchData"];
    //        Repeater_Product.DataSource = allobj;
    //        Repeater_Product.DataBind();
    //    }

    //}

}