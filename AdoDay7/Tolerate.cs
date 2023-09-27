using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDay7
{
    public static class Tolerate
    {

        public static int ID { get; set; } = 1;
        private static string Name { get; set; }
        public static int num = 0;
        public static void InsertData()
        {
            ID = GetBiggestID();
            ID++;
            num = 0;
            string name = "";
            int mobile = 0;
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Mobile: ");
            mobile = int.Parse(Console.ReadLine());
            Console.WriteLine($"You Entered >>> Name: {name} , Mobile :{mobile} , ID: {ID}");

            num++;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand command2 = new SqlCommand("INSERT INTO student (Name, ID, Mobile) VALUES (@Name, @ID, @Mobile)", con);

                command2.Parameters.AddWithValue("@Name", $"{name}");
                command2.Parameters.AddWithValue("@ID", ID);
                command2.Parameters.AddWithValue("@Mobile", mobile);

                command2.ExecuteNonQuery();

                //SqlDataReader reader = command2.ExecuteReader();
                //while (reader.Read())
                //{
                //    Console.WriteLine($"Name: {reader["Name"]} , ID: {reader["ID"]} , Mobile Number: {reader["Mobile"]} ");
                //}
                //reader.Close();
                con.Close();
            }

        }
        public static int GetBiggestID()
        {
            int biggestID = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlCommand command = new SqlCommand("SELECT MAX(ID) AS BiggestID FROM student", con);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    biggestID = int.Parse(reader["BiggestID"].ToString());
                }

                reader.Close();
                con.Close();
            }

            return biggestID;
        }
        public static void DeleteFromDatabase()
        {
            int nd;
            Console.Write("Enter Id number to delete it's data: ");
            nd = int.Parse(Console.ReadLine());
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlCommand command = new SqlCommand("DELETE FROM student WHERE ID = @ID", con);

                command.Parameters.AddWithValue("@ID", nd);

                command.ExecuteNonQuery();

                con.Close();
            }
            Console.WriteLine("Deleted Successfully");

        }

        public static void UpdateRow()
        {
            Console.Write("Enter the ID of the row that you want to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the new name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the new mobile number: ");
            int mobile = int.Parse(Console.ReadLine());
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlCommand command = new SqlCommand("UPDATE student SET Name = @Name, Mobile = @Mobile WHERE ID = @ID", con);

                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Mobile", mobile);

                command.ExecuteNonQuery();

                con.Close();
            }
            Console.WriteLine("Updated Succesfully !");
        }
        
    }
}
