using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpConnecte201b
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.chaineCon);
                String req = "select store_id,store_name from sales.stores";
                SqlCommand cmd = new SqlCommand(req, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "store_name";
                comboBox1.ValueMember = "store_id";


                con.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int code =(int) comboBox1.SelectedValue;
            MessageBox.Show("Magasin num " + code);
        }
    }
}
