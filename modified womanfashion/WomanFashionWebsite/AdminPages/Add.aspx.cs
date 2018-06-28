using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPages_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_FashionType(ddl_FashionType);
            Fill_Color(ddl_Color);
            Fill_Rating(ddl_Rating);

            ddl_Brand.Items.Add(new ListItem("Select", "0"));
        }
    }

    private void Fill_Rating(DropDownList ddl_Rating)
    {

        ddl_Rating.Items.Clear();
        ddl_Rating.Items.Add(new ListItem("Select", "0"));

        
            ddl_Rating.Items.Add(new ListItem("1","1"));
            ddl_Rating.Items.Add(new ListItem("2", "2"));
            ddl_Rating.Items.Add(new ListItem("3", "3"));
            ddl_Rating.Items.Add(new ListItem("4", "4"));
            ddl_Rating.Items.Add(new ListItem("5", "5"));

        
    }

    public static void Fill_FashionType(DropDownList ddlFashType)
    {
        WomenFashionEntities entity = new WomenFashionEntities();

        // 3mlt select all from table el esmo fashion type
        var fashiontype = (from obj in entity.Fashion_Type select obj).ToList(); //obj de hatrg3le kolo

        ddlFashType.Items.Clear();
        ddlFashType.Items.Add(new ListItem("Select", "0"));

        //hroo7 a loop 3alehom w a7othom fl dropdownlist bt3ty 
        // baruh aloop 3ala l cols l f table l fashion_type l fe l database w agbhum w ahutuhum f list b3d kda aloop 3alehum 3ashan ahutuhum f l ddl bt3tee 3ashan yzharulii
        foreach (var item in fashiontype) 
        {
            // listitem de bt5od text w value , l text l 3yzah yzahar wl value bt3to l rakam bt3o ely mapped fl database
            ddlFashType.Items.Add(new ListItem(item.Fashion_Type_Name.ToString(), item.Fashion_Type_Id.ToString()));
        }


    }
    protected void ddl_FashionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //hageeb el selected value fa lw howa e5tar mn l ddl bt3t l fashion msln clothes el hya el value bt3tha btsway 1
        int selectedfashtypeID = int.Parse(ddl_FashionType.SelectedValue.ToString());

        WomenFashionEntities entity = new WomenFashionEntities();
        //fa ana ha5od l 1 da b2a w aroo7 ageeb l brands bt3to mn db el mapped b number 1 de
        var brands = (from obj in entity.Brand where (obj.Fashion_Type_Id == selectedfashtypeID) select obj).ToList();

        ddl_Brand.Items.Clear();
        ddl_Brand.Items.Add(new ListItem("Select", "0"));

        foreach (var item in brands)
        {
            ddl_Brand.Items.Add(new ListItem(item.BrandName.ToString(), item.BrandID.ToString()));
        }

    }

    //public static void Fill_Brand(DropDownList ddlBrand)
    //{
    //    WomenFashionEntities entity = new WomenFashionEntities();

    //    var brands = (from obj in entity.Brand select obj).ToList(); //obj de hatrg3le kolo

    //    ddlBrand.Items.Clear();
    //    ddlBrand.Items.Add(new ListItem("Select", "0"));

    //    foreach (var item in brands)
    //    {
    //        ddlBrand.Items.Add(new ListItem(item.BrandName.ToString(), item.BrandID.ToString()));
    //    }


    //}

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
    //=====================================================
    //{ ddl_FashionType_SelectedIndexChanged } ->> da m3na eny awl ma adoos 3la l ddl bt3t l fashion type y7sl action
    //tab ana 3yzah y7sal eh ? --> 3yza awl ma a5tar noo3 l item el howa ya2ma clothes ya2ma makeup ya2ma accessories
    //yroo7 y3bele l ddl bt3t l brand based  3la l type el ana a5tro mn l ddl bt3t l fashion de
    //=====================================================
    

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Panel_StatusError.Visible = false;
        Panel_StatusSuccess.Visible = false;
        lblStatusError.Text = "";
        lblStatusSuccess.Text = "";

      
        //
        if (FileUpload_images.HasFile == false)
        {
            lblStatusError.Text = "You Must Choose Image !";
            Panel_StatusError.Visible = true;
            return;
        }
       
       

        WomenFashionEntities entity = new WomenFashionEntities();
        
        Fashion_Item fashiontype_tbl = new Fashion_Item(); //object from table bs lessa fady wna h3mlo fill
        //bageb l values l howa da5laha 

        fashiontype_tbl.Fashion_Type_Id = int.Parse(ddl_FashionType.SelectedValue.ToString());

        fashiontype_tbl.BrandID = int.Parse(ddl_Brand.SelectedValue.ToString());
        fashiontype_tbl.ColorId = int.Parse(ddl_Color.SelectedValue.ToString());
        fashiontype_tbl.Item_Description = txtbox_Description.Text.Trim();
        fashiontype_tbl.Price = double.Parse(txtbox_Price.Text);
        fashiontype_tbl.categoryid = int.Parse(ddl_Rating.SelectedValue);



       
        //IMAGE LOAD
 
        if (FileUpload_images.HasFile != false)// DA5LT SOORA
        {

            //lw da5l soora , fa ana ha create new path l hwa l path l mwgood 3ndy fl projec { folder esmo webimages } w ha7ot wrah esm l soora 
            string NewPath = "~/WebImages/" + FileUpload_images.FileName;

            //hageeb l extension bta3 l soora l howa b3d l . w ashoof no3o
            string type = NewPath.Substring(NewPath.LastIndexOf(".") + 1).ToLower();

            if (type == "jpeg".ToLower() || type == "png".ToLower() || type == "gif".ToLower() || type == "jpg".ToLower())
            {
                //lw tmaam yb2a ha7ot el path da fl table
                fashiontype_tbl.ImageURL = NewPath;
                FileUpload_images.SaveAs(Server.MapPath(NewPath));
            }
            else
            {
                lblStatusError.Text = "File Extention Not Valid ! ";
                Panel_StatusError.Visible = true;
                return;
            }

        }

        entity.Fashion_Item.Add(fashiontype_tbl);
        entity.SaveChanges();
        ImgShow.ImageUrl = fashiontype_tbl.ImageURL;
        ImgShow.Visible = true;
        lblStatusSuccess.Text = "Adding Done SuccessFully";
        Panel_StatusSuccess.Visible = true;


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

}