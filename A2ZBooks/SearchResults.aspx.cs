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
    public partial class Search : System.Web.UI.Page
    {

        string searchTextBoxValue;
        string searchDropDownValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["search"] != null) searchTextBoxValue = Session["search"].ToString();
            if (Session["itemToSearch"] != null) searchDropDownValue = Session["itemToSearch"].ToString();
            SearchDB();
        }

        public void SearchDB()
        {
            switch (searchDropDownValue)
            {
                case "author":
                    ExecuteQuery($"SELECT Title, Author, SubTitle, Edition, ISBN, Price FROM book WHERE author LIKE '%{searchTextBoxValue}%'");
                    break;
                case "isbn":
                    ExecuteQuery($"SELECT Title, Author, SubTitle, Edition, ISBN, Price FROM book WHERE ISBN LIKE '%{searchTextBoxValue}%'");
                    break;
                case "title":
                    ExecuteQuery($"SELECT Title, Author, SubTitle, Edition, ISBN, Price FROM book WHERE title LIKE '%{searchTextBoxValue}%'");
                    break;
                case "courseNum":
                    ExecuteQuery($"SELECT Title, Author, SubTitle, Edition, ISBN, Price FROM book where ID IN (select BookID from bookcoursebridge where CourseID IN (SELECT ID FROM course where Number = '{searchTextBoxValue}'));");
                    break;
            }
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


            GridView2.DataSource = dataTable;
            GridView2.DataBind();
            conn.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
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

             reader.Close();

             conn.Close();
         }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "AddToCart")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView2.Rows[index];

                string title = row.Cells[1].Text;
                string author = row.Cells[2].Text;
                int quantity = 1;
                double price = 0;
                double.TryParse(row.Cells[6].Text, out price);

                string sql = String.Format("INSERT INTO shoppingcart(Title, Author, Quantity, Price) VALUES ('{0}', '{1}', {2}, {3});", title, author, quantity, price);

                ExecuteStatement(sql);

                //((Button) ((GridView2) sender).Rows(e.CommandArgument).FindControl("Add To Cart").Enabled = false;

                //row.Cells[0].Enabled = false;
                //button.Enabled = false;
            }
        }
    }
}