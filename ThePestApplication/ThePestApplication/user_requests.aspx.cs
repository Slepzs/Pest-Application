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
    public partial class user_requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }

            UpdateGridview();
            

            if (GridViewUser.Rows.Count >= 4)
            {
               // BtnGetHelp.Enabled = false;
            }

            DropDownListDelete.AutoPostBack = true;

            Countdates();

        }


        public void UpdateGridview()
        {
            //SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated");
            SqlConnection conn = new SqlConnection(@"data source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataReader rdr = null;


            try
            {
               conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Help WHERE idcustomer = '" + Session["id"] + "'", conn);
                // SqlCommand cmd = new SqlCommand("Select * from Help WHERE idcustomer = 1", conn);
                rdr = cmd.ExecuteReader();
                                             
                GridViewUser.DataSource = rdr;
                GridViewUser.DataBind();

            }
            catch (Exception ex)
            {

               swag.Text = ex.Message;
            }
            finally
            {
                conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors. 
            }
        }

        public void Countdates()
        {
            //SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated");
            SqlConnection conn = new SqlConnection(@"data source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select * from help";

            try
            {
                // conn.Open(); SqlDataAdapters open connection by itself.
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "mydates");

                dt = ds.Tables["mydates"];

                

                



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

        protected void GridViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownListHours.Text = GridViewUser.SelectedRow.Cells[2].Text;
            string TT = GridViewUser.SelectedRow.Cells[4].Text;
            String NS = TT.Substring(0, (TT.Length - 9));
            TextBoxCalender.Text = NS;

            swag.Text = "You have chosen" + GridViewUser.SelectedRow.Cells[4].Text;
                
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxCalender.Text = Calendar1.SelectedDate.ToString("dd'/'MM'/'yyyy");

            swag.Text = TextBoxCalender.Text + " " + DropDownListHours.Text;

        }

        private int i
        {
            get
            {
                if (Session["i"] == null)
                    return 0;

                return (int)Session["i"];

            }
            set
            {
                Session["i"] = value;
            }
        }

        protected void BtnGetHelp_Click(object sender, EventArgs e)
        {
            
            // SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from Help";
            string sqlins = "insert into Help values (@idcustomer, @idpest, @date)";
            
            if (i >= 3)
            {
                BtnGetHelp.Enabled = false;
            }
            try
            {
         

                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "UserRequest");

                dt = ds.Tables["UserRequest"];

                string chosendate = TextBoxCalender.Text + " " + DropDownListHours.Text;

                DataRow newrow = dt.NewRow();
                newrow["idcustomer"] = Session["id"];
                newrow["idpest"] = DropDownListPests.Text;
                newrow["date"] = chosendate;
                dt.Rows.Add(newrow);

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@idcustomer", SqlDbType.Int, 50, "idcustomer");
                cmd.Parameters.Add("@idpest", SqlDbType.Int, 50, "idpest");
                cmd.Parameters.Add("@date", SqlDbType.DateTime, 50, "date");

                da.InsertCommand = cmd;
                da.Update(ds, "UserRequest");


                i++;

            }
            catch (Exception ex)
            {
                swag.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            UpdateGridview();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from Help";
            string sqlupd = "update Help set idpest = @idpest, date = @date Where pestrequest = @pestrequest";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "UpdatePest");

                dt = ds.Tables["UpdatePest"];
                
                int tableindex = GridViewUser.SelectedIndex;
                dt.Rows[tableindex]["pestrequest"] = GridViewUser.SelectedRow.Cells[1].Text;
                dt.Rows[tableindex]["idpest"] = DropDownListPests.Text;
                dt.Rows[tableindex]["date"] = TextBoxCalender.Text + "  " + DropDownListHours.Text;
               

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@pestrequest", SqlDbType.Int, 50, "pestrequest");
                cmd.Parameters.Add("@idpest", SqlDbType.Int, 50, "idpest");
                cmd.Parameters.Add("@date", SqlDbType.DateTime, 50, "date");

                da.UpdateCommand = cmd;
                da.Update(ds, "UpdatePest");

                swag.Text = "It has been updated " + GridViewUser.SelectedRow.Cells[1].Text;


            }
            catch (Exception ex)
            {
                swag.Text = ex.Message;
            }
            finally
            {
                conn.Close();
               
            }
            UpdateGridview();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = PestUpdated2");
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; integrated security = true; database = pestupdate");
            SqlDataAdapter da = null;
            SqlCommandBuilder cb = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select * from Help";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                cb = new SqlCommandBuilder(da);

                ds = new DataSet();
                da.Fill(ds, "HelpRequests");

                dt = ds.Tables["HelpRequests"];

                foreach (DataRow myrow in dt.Select("pestrequest =" + Convert.ToInt32(DropDownListDelete.SelectedValue)))
                {
                    myrow.Delete();
                }


                da.Update(ds, "HelpRequests");

                swag.Text = "It has been Deleted";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                swag.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            UpdateGridview();
        }

        protected void DropDownListDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListDelete.SelectedIndex != 0)
            {
                LabelMessage.Text = "You Chose";
                btnDelete.Enabled = true;
            }
            else
            {
                LabelMessage.Text = "Nothing is chosen";
                btnDelete.Enabled = false;
            }
        }
    }
}