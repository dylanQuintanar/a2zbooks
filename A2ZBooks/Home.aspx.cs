using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A2ZBooks
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["search"] = txtSearch.Text;
            Session["itemToSearch"] = DropDownList1.SelectedValue;
            Response.Redirect("SearchResults.aspx");
        }

        public void SearchDB()
        {
            switch (DropDownList1.SelectedValue)
            {
                case "author":
                    ExecuteQuery($"SELECT * FROM book WHERE author LIKE '%{txtSearch.Text}%'");
                    break;
                case "isbn":
                    ExecuteQuery($"SELECT * FROM book WHERE ISBN LIKE '%{txtSearch.Text}%'");
                    break;
                case "title":
                    ExecuteQuery($"SELECT * FROM book WHERE title LIKE '%{txtSearch.Text}%'");
                    break;
                case "courseNum":
                    ExecuteQuery($"SELECT * FROM book where ID IN (select BookID from bookcoursebridge where CourseID IN (SELECT ID FROM course where Number = '{txtSearch.Text}'));");
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
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var titleValue = reader["Title"];
                var isbnValue = reader["isbn"];
                var authorValue = reader["Author"];
                var priceValue = reader["Price"];

                //Label1.Text += "Book title: " + titleValue.ToString()
                //+ " ISBN: " + isbnValue.ToString()
                //+ " Author: " + authorValue.ToString()
                //+ " Price: " + priceValue.ToString()
                // + "<br>";
            }
        }


    }
}