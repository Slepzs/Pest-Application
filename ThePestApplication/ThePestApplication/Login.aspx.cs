using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace ThePestApplication
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
           // SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select id, email, password from Customer WHERE email = @email AND password=@password";
 
            try
            {
                // conn.Open(); SqlDataAdapters open connection by itself.
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);
                da.SelectCommand.Parameters.AddWithValue("@email", TextBoxEmail.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@password", TextBoxPassword.Text.Trim());

                ds = new DataSet();
                da.Fill(ds, "Customers");

                int userid = (int)ds.Tables[0].Rows[0]["id"];

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["email"] = TextBoxEmail.Text;
                    Session["id"] = userid;
                    LabelMessage.Text = "User has been found";
                    if((string)Session["email"] == "ex@gmail.com")
                    {
                        Response.Redirect("Requests.aspx");
                    }
                    Response.Redirect("Default.aspx");
                } else
                {
                    LabelMessage.Text = "User has not been found";
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors. 
            }
        }
    }
}