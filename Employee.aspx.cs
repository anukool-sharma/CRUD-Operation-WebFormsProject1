using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//First you need to add namesapces' for your project (system.data,system.data.sqlclient,system.configuration)

namespace CurdOperation_Project1
{
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        //SqlConnection class is used to establish connection between MSSQL server and it occurs in the System.Data.SqlClient namespace.
        protected void Page_Load(object sender, EventArgs e)
        {
            // How to read connection string from web config file.
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        // Save Button code start form here.
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert tbemp values(@Eno,@En,@Eadd,@Es)";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Eno", TextBox1.Text);
            cmd.Parameters.AddWithValue("@En", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Eadd", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Es", TextBox4.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Disp_clear(); // this is used to clear your textboxes
            Disp_Rec(); // this method is from display button that show instant data after saving in the listbox.
        }

        private void Disp_clear()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox1.Focus();
        }

        // For Display button code start from here---------------
        protected void Button4_Click(object sender, EventArgs e)
        {
            Disp_Rec(); // this is method for display button that shows instant saving data in the listbox when user click on save button
        }

        private void Disp_Rec()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tbemp";
            cmd.Connection = conn; // that shows Database connection where query execute in sql engine.
            SqlDataReader dr; //used for data read and fetch.
            dr = cmd.ExecuteReader(); 
            ListBox1.DataTextField = "Ename"; // To show name in your listbox using DataTextField
            ListBox1.DataValueField = "Empno"; // those column you won't display but used in listbox when user click on particular record A SelectedValue is used to fetch data from DataValueField using their Empo
            ListBox1.DataSource = dr; // from where data came
            ListBox1.DataBind(); // to fill data
            dr.Close(); // used to close SqlDataReader due to singelton classes
            cmd.Dispose();
           
        }
        // ListBox button start from Here----------
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tbemp where Empno = @Eno";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Eno", ListBox1.SelectedValue);
            // SelectedValue is used to fetch data from DataValueField that why we used SelectedValue.
            //ListBox1.SelectedItem.Text; if you want Textbox data than SelectedItem.Text property is used.
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) // HasRows check row exist in the table or not
            {
                dr.Read();
                TextBox1.Text = dr["Empno"].ToString();
                TextBox2.Text = dr["Ename"].ToString();
                TextBox3.Text = dr["Eadd"].ToString();
                TextBox4.Text = dr["Esal"].ToString();
            }
           
            dr.Close();
            cmd.Dispose();
        }

        // Update button start from here----------------
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update tbemp set Ename = @En, Eadd=@Eadd, Esal=@Es where Empno = @Eno";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Eno", TextBox1.Text);
            cmd.Parameters.AddWithValue("@En", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Eadd", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Es", TextBox4.Text);
            cmd.ExecuteNonQuery();
            Disp_Rec();
            Disp_clear();
        }

        //delete button start from here ------------
        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from tbemp where Empno = @eno";
            cmd.Parameters.AddWithValue("@eno", TextBox1.Text);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            Disp_Rec();
            Disp_clear();
        }
    }
}