using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace A2ZBooks
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "SELECT Title, Author, Quantity, Price FROM shoppingcart";

            ExecuteQuery(query);

            string total = "SELECT SUM(Price), SUM(Quantity) FROM shoppingcart;";

            ExecuteStatement(total);

            //int quantity = 0;
            //double subTotal = 0;
            //int indexOfColumn = 2;
            //int indexOfPrice = 3;
            //int y;
            //double x;

            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    int.TryParse(row.Cells[indexOfColumn].ToString(), out y);
            //    quantity += y;
            //    double.TryParse(row.Cells[indexOfPrice].ToString(), out x);
            //    subTotal += x;
            //}


           
            //subtitle_Lbl.Text = "Subtotal (" + quantity + " item(s)): $ " + subTotal;
 
        }

        protected void backToSearch_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchResults.aspx");
        }

        protected void continueShop_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void placeOrder_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmation.aspx");
        }

         public void ExecuteQuery(string query)
        {
            string dbServer = "cis425.wpcarey.asu.edu";
            string username = "dgquinta";
            string password = "deadTHUS50";
            string dbName = "group17";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", dbServer, username, password, dbName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
            conn.Open();

            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            conn.Close();
        }

         public void ExecuteStatement(string query)
         {
             string dbServer = "cis425.wpcarey.asu.edu";
             string username = "dgquinta";
             string password = "deadTHUS50";
             string dbName = "group17";

             string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", dbServer, username, password, dbName);

             var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
             conn.Open();

             var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
             var reader = cmd.ExecuteReader();

             while (reader.Read())
             {
                 var subTotal = reader["SUM(Price)"];
                 var quantity = reader["SUM(Quantity)"];
                 subtitle_Lbl.Text = "Subtotal (" + quantity + " item(s)): $ " + subTotal;
             }



             reader.Close();

             conn.Close();
         }

         protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
         {
             if (e.CommandName == "Remove")
             {
                 int index = Convert.ToInt32(e.CommandArgument);

                 GridViewRow row = GridView1.Rows[index];

                 string title = row.Cells[1].Text;
                 //string author = row.Cells[2].Text;
                 //int quantity = 1;
                 //double price = 0;
                 //double.TryParse(row.Cells[6].Text, out price);

                 string sql = String.Format("DELETE FROM shoppingcart WHERE Title = '{0}';", title);

                 ExecuteStatement(sql);

                 Response.Redirect("Cart.aspx");
             }
         }
    }
}