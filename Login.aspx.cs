using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CurdOperation_Project1
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private int checkuser(string u, string p)
        {
            SqlCommand cmd = new SqlCommand("LoginCheck",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@un", u);
            cmd.Parameters.AddWithValue("@up", p);

            // create a new parameter for return value that is integer type
            SqlParameter para = new SqlParameter("@return", SqlDbType.Int);
            para.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            int d = Convert.ToInt32(cmd.Parameters["@return"].Value);
            cmd.Dispose();
            return d;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = checkuser(TextBox1.Text, TextBox2.Text);
            if (i == -1)
            {
                Label1.Text = "wrong username";
            }
            else if (i == -2)
            {
                Label1.Text = "Wrong Password";
            }
            else
            {
                Response.Redirect("Employee.aspx");
            }
        }
    }
}