using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace tpConnecte201b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
             

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Ajouter
            try
            {
                SqlConnection con = new SqlConnection(Program.chaineCon);
                String req = "insert into sales.stores values(@nom,@tele,@email,@adr,@vil,@prov,@zip)";
                SqlCommand cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@nom", txtNom.Text);
                cmd.Parameters.AddWithValue("@tele", txtTel.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@adr", txtAdr.Text);
                cmd.Parameters.AddWithValue("@vil", txtVil.Text);
                cmd.Parameters.AddWithValue("@prov", txtProv.Text);
                cmd.Parameters.AddWithValue("@zip", txtCodePos.Text);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) MessageBox.Show("Magasin ajoute avec succes");
                con.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Vider
            txtAdr.Text = txtCodePos.Text = txtEmail.Text = txtNom.Text = txtProv.Text = txtTel.Text = txtVil.Text =String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Supprimer
            try
            {
                SqlConnection con = new SqlConnection(Program.chaineCon);
                String req = "delete from sales.stores where store_name='"+txtNom.Text+"'";
                SqlCommand cmd = new SqlCommand(req, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) MessageBox.Show("Magasin supprime avec succes");
                con.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Rechercher
            try
            {
                SqlConnection con = new SqlConnection(Program.chaineCon);
                String req = "select * from sales.stores where store_name='"+txtNom.Text+"'";
                SqlCommand cmd = new SqlCommand(req, con);
                con.Open();
                SqlDataReader dr= cmd.ExecuteReader();
                bool nb= dr.Read();
                if(!nb)
                {
                    MessageBox.Show("Introuvable");
                    return;
                }
                txtNom.Text = dr[1].ToString();
                txtTel.Text = dr[2].ToString();
                txtEmail.Text = dr[3].ToString();
                txtAdr.Text = dr[4].ToString();
                txtVil.Text = dr[5].ToString();
                txtProv.Text = dr[6].ToString();
                txtCodePos.Text = dr[7].ToString();
                
                con.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }
    }
}
