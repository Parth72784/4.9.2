using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4_9._2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strconn"].ConnectionString);
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Server.MapPath("Image"))) ;
            {
                Directory.CreateDirectory(Server.MapPath("Image"));
            }
            string imgurl = (Server.MapPath("Image")) + "\\" + flImage.FileName;
            string dbpath = "~/Image/" + flImage.FileName;
            flImage.SaveAs(imgurl);
            SqlCommand cmd = new SqlCommand("insert into ProductMaster(ProductImage,ProductName,Price,Description) " +
                "values(@pimg,@pname,@price,@pdec)",conn);
            cmd.Parameters.AddWithValue("@pimg", dbpath);
            cmd.Parameters.AddWithValue("@pname", txtProductName.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@pdec", txtDesc.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}