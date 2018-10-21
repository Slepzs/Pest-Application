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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from Customer";
            string sqlins = "insert into Customer values (@firstname, @lastname, @street, @zip, @email, @password)";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MyCustomers");

                dt = ds.Tables["MyCustomers"];

                DataRow newrow = dt.NewRow();
                newrow["firstname"] = TextBoxFN.Text;
                newrow["lastname"] = TextBoxLN.Text;
                newrow["street"] = TextBoxStreet.Text;
                newrow["zip"] = TextBoxZip.Text;
                newrow["email"] = TextBoxEmail.Text;
                newrow["password"] = TextBoxPassword.Text;
                dt.Rows.Add(newrow);

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@firstname", SqlDbType.Text, 50, "firstname");
                cmd.Parameters.Add("@lastname", SqlDbType.Text, 50, "lastname");
                cmd.Parameters.Add("@street", SqlDbType.Text, 50, "street");
                cmd.Parameters.Add("@zip", SqlDbType.Text, 50, "zip");
                cmd.Parameters.Add("@email", SqlDbType.Text, 50, "email");


                da.InsertCommand = cmd;
                da.Update(ds, "MyCustomers");

                LabelMessage.Text = "Your account has been created";


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
    }
}