using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpConnecte201b
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            cbxMagasin.DataSource = Program.getData(new SqlCommand("select store_id,store_name from sales.stores"));
            cbxMagasin.DisplayMember = "store_name";
            cbxMagasin.ValueMember = "store_id";
        }

        private void cbxMagasin_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idmagasin =int.Parse( cbxMagasin.SelectedValue.ToString());
            SqlCommand cmd = new SqlCommand("select * from sales.staffs where store_id=@id");
            cmd.Parameters.AddWithValue("@id", idmagasin);
            dataGridView1.DataSource = Program.getData(cmd);
            
        }
    }
}
