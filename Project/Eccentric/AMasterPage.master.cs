using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection cn = new SqlConnection(@"Data Source=RJT-LAPPY; Database=eccentric; Integrated Security=true");
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da,da1;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        labusername.Text = "Welcome " + Session["username"].ToString()+"|";
        lbltime.Text = Session["authority"].ToString()+"|"+DateTime.Now.ToString("D", System.Globalization.DateTimeFormatInfo.CurrentInfo);
        if(Page.IsPostBack)
        {
            DropDownList1.DataTextField = " ";
            DropDownList2.DataTextField = " ";
        }

        showteamleader();
        showclients();
        
        
                                        
    }
    private void showteamleader()
    {
        try
        {
            cn.Open();
            da = new SqlDataAdapter("select username from usersdetails where authority='project leader'", cn);
            da.Fill(ds, "usersdetails");
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "username";
            DropDownList1.DataBind();


        }
        catch (Exception ex)
        {
           // laberror.Text = ex.Message;
        }
        finally
        {
            cn.Close();
        }
    }
    private void showclients()
    {
        try
        {
            cn.Open();
            da1 = new SqlDataAdapter("select username from usersdetails where authority='client'", cn);
            da1.Fill(ds1, "usersdetails");
            DropDownList2.DataSource = ds1.Tables[0];
            DropDownList2.DataTextField = "username";
            DropDownList2.DataBind();


        }
        catch (Exception ex)
        {
           //laberror.Text = ex.Message;
        }
        finally
        {
            cn.Close();
        }
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/composemails.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/inboxofadmin.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/adminsentitems.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login1/homelogin.aspx");
    }
}

