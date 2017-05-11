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
    public partial class Confirmation : System.Web.UI.Page
    {

        string clearCart = "DELETE FROM shoppingcart";
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbServer = "cis425.wpcarey.asu.edu";
            string username = "dgquinta";
            string password = "deadTHUS50";
            string dbName = "group17";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", dbServer, username, password, dbName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
            conn.Open();

            string query = "SELECT Title, Author, Quantity, Price FROM shoppingcart";

            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            GridView3.DataSource = dataTable;
            GridView3.DataBind();

            conn.Close();

            string total = "SELECT SUM(Price) FROM shoppingcart;";

            ExecuteQuery(total);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ExecuteQuery(clearCart);
            lblConfirm.Text = "Your shopping cart has been cleared. Thank you!";
            lblConfirm.Visible = true;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            ExecuteQuery(clearCart);
            lblConfirm.Text = "<i><b>Congratulations!</b></i><br> Your order has been placed.<br> Thank you for shopping with us.";
            lblConfirm.Visible = true;
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
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var subTotal = reader["SUM(Price)"];
                var shipping = Convert.ToDouble(subTotal) * 0.01;
                var tax = (Convert.ToDouble(subTotal) + shipping) * 0.0675;
                var total = Convert.ToDouble(subTotal) + shipping + tax;
                lblSubtotal.Text = String.Format("{0,2:C}", subTotal);
                lblShipping.Text = String.Format("{0,2:C}", shipping);
                lblTax.Text = String.Format("{0,2:C}", tax);
                lblTotal.Text = String.Format("{0,2:C}", total);
            }
            //while (reader.Read())
            //{
            //    var titleValue = reader["Title"];
            //    var isbnValue = reader["isbn"];
            //    var authorValue = reader["Author"];
            //    var priceValue = reader["Price"];
            //    var quantity = reader["Quantity"];

            //    lblTitleTxt.Text = titleValue.ToString();
            //    lblAuthorTxt.Text = authorValue.ToString();
            //    lblISBNTxt.Text = isbnValue.ToString();
            //    lblQtyTxt.Text = quantity.ToString();
            //    lblPriceTxt.Text = priceValue.ToString();
            //}

            reader.Close();
            conn.Close();
        }
    }
}