using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPages_ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Item_Description");
            dt.Columns.Add("Fashion_item_Id");
            dt.Columns.Add("Fashion_Type_Name");
            dt.Columns.Add("BrandName");
            dt.Columns.Add("Price");

            if (Session["ShoppingCart"] != null)
            {
                dt = Session["ShoppingCart"] as DataTable;
                GridView_CartFashionItems.DataSource = dt;
                GridView_CartFashionItems.DataBind();
            }

            Label lbl_CartCount = this.Master.FindControl("lbl_cart") as Label;
            lbl_CartCount.Text = "( " + dt.Rows.Count.ToString() + " )";

        }
    }


    protected void GridView_CartFashionItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedId = int.Parse(GridView_CartFashionItems.SelectedIndex.ToString());

        DataTable dt = new DataTable();
        dt.Columns.Add("Fashion_item_Id");
        dt.Columns.Add("Fashion_Type_Name");
        dt.Columns.Add("BrandName");
        dt.Columns.Add("Price");

        if (Session["ShoppingCart"] != null)
        {
            dt = Session["ShoppingCart"] as DataTable;

            //We Remove the item from datatable
            dt.Rows.RemoveAt(selectedId); 

            // and then we assign the dt to gridview again after remove with the new datatable
            GridView_CartFashionItems.DataSource = dt;
            GridView_CartFashionItems.DataBind();


            // After Remove we assign the ( dt ) to session again 
            Session["ShoppingCart"] = dt;
            Label lbl_CartCount = this.Master.FindControl("lbl_cart") as Label;
            lbl_CartCount.Text = "( " + dt.Rows.Count.ToString() + " )";
        }
    }



}