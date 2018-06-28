using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPages_Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//lma l pagr trun
        {
            Fill_FashionType(ddl_FashionType);
            Fill_Color(ddl_Color);
            Fill_Rating(ddl_Rating);

            FillFashionGridView();
        }
    }

    private void Fill_Rating(DropDownList ddl_Rating)
    {

        ddl_Rating.Items.Clear();
        ddl_Rating.Items.Add(new ListItem("Select", "0"));


        ddl_Rating.Items.Add(new ListItem("1", "1"));
        ddl_Rating.Items.Add(new ListItem("2", "2"));
        ddl_Rating.Items.Add(new ListItem("3", "3"));
        ddl_Rating.Items.Add(new ListItem("4", "4"));
        ddl_Rating.Items.Add(new ListItem("5", "5"));


    }

    public static void Fill_FashionType(DropDownList ddlFashType)
    {
        WomenFashionEntities entity = new WomenFashionEntities();

        var fashiontype = (from obj in entity.Fashion_Type select obj).ToList(); //obj de hatrg3le kolo

        ddlFashType.Items.Clear();
        ddlFashType.Items.Add(new ListItem("Select", "0"));

        foreach (var item in fashiontype)
        {
            ddlFashType.Items.Add(new ListItem(item.Fashion_Type_Name.ToString(), item.Fashion_Type_Id.ToString()));
        }


    }

    private void FillFashionGridView()
    {
        //h3ml fill lel grid view be asamy columns mo3yna ana 3yzaha mn l table el esmo "Fashion_Item" 
        //select new :: lma ba3oz a3mla selection le hagat mo3yna mn table msh el columns kolha y3ny
        WomenFashionEntities entity = new WomenFashionEntities();
        var AllObj = (from obj in entity.Fashion_Item select new { obj.Fashion_item_Id, obj.Fashion_Type.Fashion_Type_Name, obj.Price, obj.Brand.BrandName }).ToList();
        GridView_FashionItems.DataSource = AllObj;
        GridView_FashionItems.DataBind();
    }

    public static void Fill_Color(DropDownList ddlcolor)
    {
        WomenFashionEntities entity = new WomenFashionEntities();

        var colors = (from obj in entity.Color select obj).ToList(); //obj de hatrg3le kolo

        ddlcolor.Items.Clear();
        ddlcolor.Items.Add(new ListItem("Select", "0"));

        foreach (var item in colors)
        {
            ddlcolor.Items.Add(new ListItem(item.ColorName.ToString(), item.ColorID.ToString()));
        }


    }
    //GridView_FashionItems_SelectedIndexChanged --> lma adool 3la select fl grid y7sal eh ??
    //l mfrood yroo7 ygble l data kolha bt3t l row l ana 3mlto selection da
    protected void GridView_FashionItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel_StatusError.Visible = false;
        Panel_StatusSuccess.Visible = false;
        lblStatusError.Text = "";

        lblStatusSuccess.Text = "";
        WomenFashionEntities entity = new WomenFashionEntities();

        //gbt l id bta3 l selected item l ana a5trto 3shan howa da l haga l unique el a2dar ageeb beha l data ely m3ah
        int SelectedItemID = int.Parse(GridView_FashionItems.SelectedValue.ToString());

        //b3ml selection lel row kamel mn l database depends 3la l fashionID el ana a5trto mn el grid
        //SelectedFashionItem --> da hyrg3 be row kamel mn l db hygble y3ny shayel l columns
        var SelectedFashionItem = (from tab in entity.Fashion_Item where (tab.Fashion_item_Id == SelectedItemID) select tab).FirstOrDefault();

        //hbad2 b2a a7ot fl controls bt3ty el values el mwgooda mn SelectedFashionItem 3shan a2dar b3d kda a3ml edit 3aleha
 
        ddl_FashionType.SelectedValue = SelectedFashionItem.Fashion_Type_Id.Value.ToString();
        txtbox_Description.Text = SelectedFashionItem.Item_Description.ToString();
        ImgShow.ImageUrl = SelectedFashionItem.ImageURL.ToString();
        ddl_Color.SelectedValue = SelectedFashionItem.ColorId.ToString();
        ddl_Rating.SelectedValue = SelectedFashionItem.categoryid.ToString();
        txtbox_Price.Text = SelectedFashionItem.Price.ToString();

        //3shan l brands asln depends 3la fashionType ID el howa 1 aw 2 aw 3 el hya clothes wla make up wla accessories
        // fa l awl haroo7 a select l brands w a7otha fl ddl bt3t l brands
        var brands = (from obj in entity.Brand where (obj.Fashion_Type_Id == SelectedFashionItem.Fashion_Type_Id.Value) select obj).ToList();

        ddl_Brand.Items.Clear();
        ddl_Brand.Items.Add(new ListItem("Select", "0"));

        foreach (var item in brands)
        {
            ddl_Brand.Items.Add(new ListItem(item.BrandName.ToString(), item.BrandID.ToString()));
        }

        ddl_Brand.SelectedValue = SelectedFashionItem.BrandID.ToString();

        Panel_FashionitemData.Visible = true;
      //  ImgShow.Visible = true;

    }
                 

    protected void ddl_FashionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel_StatusError.Visible = false;
        Panel_StatusSuccess.Visible = false;
        lblStatusError.Text = "";
        lblStatusSuccess.Text = "";

        int selectedfashtypeID = int.Parse(ddl_FashionType.SelectedValue.ToString());

        WomenFashionEntities entity = new WomenFashionEntities();
        var brands = (from obj in entity.Brand where (obj.Fashion_Type_Id == selectedfashtypeID) select obj).ToList();

        ddl_Brand.Items.Clear();
        ddl_Brand.Items.Add(new ListItem("Select", "0"));

        foreach (var item in brands)
        {
            ddl_Brand.Items.Add(new ListItem(item.BrandName.ToString(), item.BrandID.ToString()));
        }


        ddl_Brand.Focus();
    }

    protected void btn_Edit_Click(object sender, EventArgs e)
    {

        Panel_StatusError.Visible = false;
        Panel_StatusSuccess.Visible = false;
        lblStatusError.Text = "";
        lblStatusSuccess.Text = "";

        WomenFashionEntities entity = new WomenFashionEntities();

        int SelectedItemID = int.Parse(GridView_FashionItems.SelectedValue.ToString());

        var SelectedFashionItem = (from tab in entity.Fashion_Item where (tab.Fashion_item_Id == SelectedItemID) select tab).FirstOrDefault();
        //ha5od l values l user 3amlha update w a7otha tany fl controls bt3ty 3shan a3ml save b3d kda
        SelectedFashionItem.Fashion_Type_Id = int.Parse(ddl_FashionType.SelectedValue.ToString());
        SelectedFashionItem.BrandID = int.Parse(ddl_Brand.SelectedValue.ToString());
        SelectedFashionItem.ColorId = int.Parse(ddl_Color.SelectedValue.ToString());
        SelectedFashionItem.Item_Description = txtbox_Description.Text.Trim();
        SelectedFashionItem.Price = double.Parse(txtbox_Price.Text);
        SelectedFashionItem.categoryid = int.Parse(ddl_Rating.SelectedValue);

        if (FileUpload_images.HasFile != false)
        {

            string NewPath = "~/WebImages/" + FileUpload_images.FileName;
            string type = NewPath.Substring(NewPath.LastIndexOf(".") + 1).ToLower();

            if (type == "jpeg".ToLower() || type == "png".ToLower() || type == "gif".ToLower() || type == "jpg".ToLower())
            {
                SelectedFashionItem.ImageURL = NewPath;
                FileUpload_images.SaveAs(Server.MapPath(NewPath));
            }
            else
            {
                lblStatusError.Text = "File Extention Not Valid ! ";
                Panel_StatusError.Visible = true;
                return;
            }

        }

        //b3ml save lel values el gdeda
        entity.SaveChanges();
        ImgShow.ImageUrl = SelectedFashionItem.ImageURL;
        ImgShow.Visible = true;
        lblStatusSuccess.Text = "Editing Done SuccessFully";
        Panel_StatusSuccess.Visible = true;
        // w b3den arg3 a3ml filling tany lel grid bl values l gdeda
        FillFashionGridView();
        Panel_FashionitemData.Visible = false;

        Clear();  // reset to The Whole page again ( refill Dropwon Lists , Clear textbox , etc.... )


        
    }

    private void Clear()
    {
        Fill_FashionType(ddl_FashionType);
        Fill_Color(ddl_Color);
        Fill_Rating(ddl_Rating);
        txtbox_Description.Text = "";
        txtbox_Price.Text = "";
        ddl_Brand.ClearSelection();
    }

    protected void btn_Delete_Click(object sender, EventArgs e)
    {

        Panel_StatusError.Visible = false;
        Panel_StatusSuccess.Visible = false;
        lblStatusError.Text = "";
        lblStatusSuccess.Text = "";

        WomenFashionEntities entity = new WomenFashionEntities();
        int SelectedItemID = int.Parse(GridView_FashionItems.SelectedValue.ToString()); // selected value from grid


        Fashion_Item objFashion = new Fashion_Item { Fashion_item_Id = SelectedItemID };
        entity.Fashion_Item.Attach(objFashion);
        entity.Fashion_Item.Remove(objFashion);
        entity.SaveChanges();
        lblStatusSuccess.Text = "Deleting Done SuccessFully";
        Panel_StatusSuccess.Visible = true;
        FillFashionGridView();
        Clear();
        ImgShow.Visible = false;
        Panel_FashionitemData.Visible = false;


    }

}