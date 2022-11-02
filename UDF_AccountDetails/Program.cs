using System.Data.SqlClient;
namespace UDF_AccountDetails

{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ConnectionStr = @"Data Source=INLPF1AVPDL;Initial Catalog=MyDb;trusted_connection=true";
                SqlConnection sqlconn = new SqlConnection(ConnectionStr);
                sqlconn.Open();
                

                Console.WriteLine("Enter The Account Balance");

                long bal = Convert.ToInt64(Console.ReadLine());

                string query = @"select Acc_num,cus_name,acc_balance,account_info.Aadhar_number,acc_open_date,Last_transaction_date from account_info INNER JOIN customer_info ON account_info.Aadhar_number = customer_info.Aadhar_number WHERE account_info.acc_balance>@bal";

                SqlCommand cmd = new SqlCommand(query, sqlconn);

                cmd.Parameters.Add("@bal", System.Data.SqlDbType.BigInt).Value = bal;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.Write(reader[0] + "  ");
                    Console.Write(reader[1] + "  ");
                    Console.Write(reader[2] + "  ");
                    Console.Write(reader[3] + "  ");
                    Console.Write(reader[4] + "  ");
                    Console.Write(reader[5] + "  ");
                    Console.Write(reader[6] + "  ");
                    Console.WriteLine();
                }
                Console.WriteLine("Execution successfully completed!!");
                reader.Close();
                sqlconn.Close();
                Console.ReadKey();



            }
            catch(SqlException sqlE)
            {
                Console.WriteLine(sqlE.Message);
                Console.WriteLine("sql issue");


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("some issues");
            }
            }
    }
}