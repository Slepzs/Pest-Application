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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            ShowAllPests();
        }

        public void ShowAllPests()
        {
            //SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated");
             SqlConnection conn = new SqlConnection(@"data source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

          
            try
            {
                conn.Open();

                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllPests";

                rdr = cmd.ExecuteReader();

                RepeaterTotal.DataSource = rdr;
                RepeaterTotal.DataBind();


            }
            catch (Exception ex)
            {               
                   LabelMessage.Text = ex.Message;              
            }
            finally
            {
                conn.Close();
            }
        }

        protected void RepeaterTotal_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void SqlPests_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}