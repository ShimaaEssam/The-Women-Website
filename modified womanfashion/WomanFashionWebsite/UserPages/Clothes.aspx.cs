using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPages_Clothes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
                Label lbl_CartCount = this.Master.FindControl("lbl_cart") as Label;
                lbl_CartCount.Text = "( " + dt.Rows.Count.ToString() + " )";
            }

        if (!IsPostBack)
        {//hna bst5dm repeater 34an el morb3 l betl3ly w akrro 3l ad l rows l 3nde
            WomenFashionEntities entity = new WomenFashionEntities();
            var fitems = (from ob in entity.Fashion_Item
                          where (ob.Fashion_Type_Id == 1)
                          select new { ob.Fashion_item_Id, ob.Item_Description, ob.Color.ColorName, ob.ImageURL, ob.category.categoryhtml, ob.Price }).ToList();
            Repeater_Product.DataSource = fitems;
            Repeater_Product.DataBind();
        }


      
    }
    
    // el functions bt3t el cart

    protected void lnkbtn_AddToCart_Click(object sender, EventArgs e)
    {
        WomenFashionEntities entity = new WomenFashionEntities();

        RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
        int selectedFashionItemID = int.Parse( (item.FindControl("lbl_Fashion_item_Id") as Label).Text);

        var SelectItem = (from tab in entity.Fashion_Item where tab.Fashion_item_Id == selectedFashionItemID select tab).FirstOrDefault();

          
        DataTable dt = new DataTable();
        dt.Columns.Add("Item_Description");
        dt.Columns.Add("Fashion_item_Id");
        dt.Columns.Add("Fashion_Type_Name");
        dt.Columns.Add("BrandName");
        dt.Columns.Add("Price");

        if (Session["ShoppingCart"] != null)
        {
            dt = Session["ShoppingCart"] as DataTable;
        }


        DataRow dr = dt.NewRow();
        dr["Item_Description"] = SelectItem.Item_Description;
        dr["Fashion_item_Id"] = SelectItem.Fashion_item_Id;
        dr["Fashion_Type_Name"] = SelectItem.Brand.BrandName;
        dr["BrandName"] = SelectItem.Fashion_Type.Fashion_Type_Name;
        dr["Price"] = SelectItem.Price.Value;

        dt.Rows.Add(dr);
       Session["ShoppingCart"] = dt;


        Label lbl_CartCount = this.Master.FindControl("lbl_cart") as Label;
        lbl_CartCount.Text = "( " + dt.Rows.Count.ToString() + " )";

    }
}