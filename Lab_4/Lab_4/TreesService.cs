using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Lab_4
{
    class TreesService
    {
        string con = "Data Source=DESKTOP-A9CE58B\\SQLEXPRESS;Initial Catalog=Lab_6;Integrated Security=True";
        SqlConnection myConnection;
        public TreesService()
        {
            myConnection = new SqlConnection(con);
            myConnection.Open();
        }

        public List<Tree> GetTrees()
        {
            List<Tree> trees = new List<Tree>();

            string oString = "Select * from Lab_4";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        trees.Add(new Tree(oReader["District"].ToString(),
                        oReader["Type"].ToString(),
                        int.Parse(oReader["Amount"].ToString())));
                    }
                }
            return trees;
        }
        public void DeletTree(string type, string district)
        {            
            string oString = "delete from Lab_4 where Type = @type AND District = @district";
            SqlCommand oCmd = new SqlCommand(oString, myConnection);
            oCmd.Parameters.AddWithValue("@type", type);
            oCmd.Parameters.AddWithValue("@district", district);
            oCmd.ExecuteNonQuery();
        }

        public void EditTree(string district, string type, int number)
        {            
            string oString = "delete from Lab_4 where Type = @type ";
            SqlCommand oCmd = new SqlCommand(oString, myConnection);
            oCmd.Parameters.AddWithValue("@type", type);
            oCmd.ExecuteNonQuery();
        }
        public void AddTree(Tree tree)
        {
                string oString = "insert into Lab_4 values(@District, @Type, @Amount);";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@District", tree.District);
                oCmd.Parameters.AddWithValue("@Type", tree.Type);
                oCmd.Parameters.AddWithValue("@Amount", tree.Amount);
                oCmd.ExecuteNonQuery();
        }


    }
}
