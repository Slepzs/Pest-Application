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
    public partial class pestoverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["email"] != "ex@gmail.com")
            {
                Response.Redirect("login.aspx");
            }


            BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;

            if (!Page.IsPostBack)
            {
                UpdateGridview();
            }

            DropDownListDelete.AutoPostBack = true;
        }

        public void UpdateGridview()
        {
            //SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select * from Pests";

            try
            {
                // conn.Open(); SqlDataAdapters open connection by itself.
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "DelPests");

                dt = ds.Tables["DelPests"];

                GridViewpests.DataSource = dt;
                GridViewpests.DataBind();

                DropDownListDelete.DataSource = dt;
                DropDownListDelete.DataTextField = "pestname";
                DropDownListDelete.DataValueField = "idpest";
                DropDownListDelete.DataBind();
                DropDownListDelete.Items.Insert(0, "Select a Pest");

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

        protected void GridViewpests_SelectedIndexChanged1(object sender, EventArgs e)
        {
            TextBoxPestName.Text = GridViewpests.SelectedRow.Cells[3].Text;
            TextBoxPrice.Text = GridViewpests.SelectedRow.Cells[4].Text;
            LabelMessage.Text = "You chose " + GridViewpests.SelectedRow.Cells[3].Text;
            BtnUpdate.Enabled = true;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from Pests";
            string sqlupd = "update Pests set pestname = @pestname, price = @price Where idpest = @idpest";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "Pests");

                dt = ds.Tables["Pests"];

                int tableindex = GridViewpests.SelectedIndex;
                dt.Rows[tableindex]["pestname"] = TextBoxPestName.Text;
                dt.Rows[tableindex]["price"] = TextBoxPrice.Text;

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@pestname", SqlDbType.Text, 50, "pestname");
                cmd.Parameters.Add("@price", SqlDbType.Int, 50, "price");
                SqlParameter param = cmd.Parameters.Add("@idpest", SqlDbType.Int, 4, "idpest");
                param.SourceVersion = DataRowVersion.Original; // good habit if someone change the primary key


                da.UpdateCommand = cmd;
                da.Update(ds, "Pests");

                LabelMessage.Text = "It has been updated" + GridViewpests.SelectedRow.Cells[1].Text;


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

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
      
        }

        protected void BtnCreate_Click1(object sender, EventArgs e)
        {
             // SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from Pests";
            string sqlins = "insert into Pests values (@pestname, @price, @pictureref)";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MyPests");

                dt = ds.Tables["MyPests"];

                DataRow newrow = dt.NewRow();
                newrow["pestname"] = TextBoxPestName.Text;
                newrow["price"] = TextBoxPrice.Text;
                newrow["pictureref"] = null;
                dt.Rows.Add(newrow);

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@pestname", SqlDbType.Text, 50, "pestname");
                cmd.Parameters.Add("@price", SqlDbType.Int, 50, "price");
                cmd.Parameters.Add("@pictureref", SqlDbType.Text, 50, "pictureref");

                da.InsertCommand = cmd;
                da.Update(ds, "MyPests");

                LabelMessage.Text = "It has been Created";


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

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            // SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            SqlCommandBuilder cb = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select * from Pests";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                cb = new SqlCommandBuilder(da);

                ds = new DataSet();
                da.Fill(ds, "MyPestss");

                dt = ds.Tables["MyPestss"];

                foreach (DataRow myrow in dt.Select("idpest =" + Convert.ToInt32(DropDownListDelete.SelectedValue)))
                {
                    myrow.Delete();
                }


                da.Update(ds, "MyPestss");

                LabelMessage.Text = "It has been Deleted";
                BtnDelete.Enabled = false;


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

        protected void DropDownListDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListDelete.SelectedIndex != 0)
            {
                LabelMessage.Text = "You Chose a Pest";
                BtnDelete.Enabled = true;
            }
            else
            {
                LabelMessage.Text = "Nothing is chosen";
                BtnDelete.Enabled = false;
            }
        }
    }
}