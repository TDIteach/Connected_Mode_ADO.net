using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace tpConnecte201b
{
    static class Program
    {
        public static String chaineCon = ConfigurationManager.ConnectionStrings["ch1"].ToString();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form4());   
        }
        //Methodes d'acces aux donnees
        public static void setData(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Program.chaineCon))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);;
            }
            
        }

        public static DataTable getData(SqlCommand s)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(Program.chaineCon))
                {
                    s.Connection = con;
                    con.Open();

                SqlDataReader dr=  s.ExecuteReader();

                    dt.Load(dr);
                    con.Close();
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message); ;
            }

            return dt;
        }
    }
}
