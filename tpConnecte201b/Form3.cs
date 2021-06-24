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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ajouter
            String req = "insert into sales.stores values(@nom,@tele,@email,@adr,@vil,@prov,@zip)";
            SqlCommand cmd = new SqlCommand(req);
            cmd.Parameters.AddWithValue("@nom", txtNom.Text);
            cmd.Parameters.AddWithValue("@tele", txtTel.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@adr", txtAdr.Text);
            cmd.Parameters.AddWithValue("@vil", txtVil.Text);
            cmd.Parameters.AddWithValue("@prov", txtProv.Text);
            cmd.Parameters.AddWithValue("@zip", txtCodePos.Text);
            Program.setData(cmd);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //supp
            String req = "delete from sales.stores where store_name=@nom";
            SqlCommand cmd = new SqlCommand(req);
            cmd.Parameters.AddWithValue("@nom", txtNom.Text);
            Program.setData(cmd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Recherche
            String req = "select * from sales.stores where store_name=@nom";
            SqlCommand cmd = new SqlCommand(req);
            cmd.Parameters.AddWithValue("@nom", txtNom.Text);
           DataTable dt= Program.getData(cmd);
            if (dt.Rows.Count > 0)
            {
                txtNom.Text = dt.Rows[0][1].ToString();
                txtTel.Text = dt.Rows[0][2].ToString();
                txtEmail.Text = dt.Rows[0][3].ToString();
                txtAdr.Text = dt.Rows[0][4].ToString();
                txtVil.Text = dt.Rows[0][5].ToString();
                txtProv.Text = dt.Rows[0][6].ToString();
                txtCodePos.Text = dt.Rows[0][7].ToString();
            }else
                MessageBox.Show("Introuvable");

        }
    }
}
