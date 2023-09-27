using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace AdoDay7
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("You're Adding a new Student's Data ....");

            Tolerate.InsertData();

            Console.WriteLine("You're Deleting a Student's Data From Database ....");
            Tolerate.DeleteFromDatabase();
            Tolerate.UpdateRow();



            #region Commented

            //Console.WriteLine("Hello There!");
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            //{
            //    SqlCommand cmd = con.CreateCommand();
            //    //cmd.CommandType = CommandType.StoredProcedure;
            //    //cmd.CommandText = "sp_count_Students";
            //    if (con.State != ConnectionState.Open)
            //    {
            //        con.Open();
            //    }
            //    //cmd.ExecuteReader().Read();
            //    //SqlCommand command = new SqlCommand("SELECT Name, ID , Mobile FROM student", con);

            //    //SqlCommand command2 = new SqlCommand("INSERT INTO student (Name, ID, Mobile) VALUES (@Name, @ID, @Mobile)", con);

            //    //command2.Parameters.AddWithValue("@Name", "Hassan");
            //    //command2.Parameters.AddWithValue("@ID", 54545);
            //    //command2.Parameters.AddWithValue("@Mobile", 8487870);

            //    //command2.ExecuteNonQuery();
            //     //command2 = new SqlCommand("DELETE FROM student WHERE ID = 2", con);
            //    //cmd.CommandType= CommandType.Text;
            //    //cmd.CommandText = "DELETE FROM student WHERE ID = 2";

            //    int reader = cmd.ExecuteNonQuery();
            //    //while (reader.Read())
            //    //{
            //    //    Console.WriteLine($"Name: {reader["Name"]} , ID: {reader["ID"]} , Mobile Number: {reader["Mobile"]} ");
            //    //}
            //    //reader.Close();
            //    con.Close();




            //}
            //;
            #endregion
        }
    }
}