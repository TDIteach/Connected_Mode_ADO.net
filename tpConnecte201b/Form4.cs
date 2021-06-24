using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tpConnecte201b
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        DataTable tblNavigationEmploye = new DataTable();
        int position;
        private void Navigation()
        {
            if (position>=0 && position<tblNavigationEmploye.Rows.Count)
            {
                int act = (int.Parse(tblNavigationEmploye.Rows[position][5].ToString()));
                txtNom.Text = tblNavigationEmploye.Rows[position][1].ToString();
                txtPren.Text = tblNavigationEmploye.Rows[position][2].ToString();
                txtTel.Text = tblNavigationEmploye.Rows[position][4].ToString();
                txtEmail.Text = tblNavigationEmploye.Rows[position][3].ToString();
                checkBox1.Checked = act == 1 ? true : false;
                cbxMagasin.SelectedValue = tblNavigationEmploye.Rows[position][6];
                cbxManager.SelectedValue = tblNavigationEmploye.Rows[position][7];
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            cbxMagasin.DataSource = Program.getData(new SqlCommand("select store_id,store_name from sales.stores"));
            cbxMagasin.DisplayMember = "store_name";
            cbxMagasin.ValueMember = "store_id";
            cbxManager.DataSource = Program.getData(new SqlCommand("select staff_id,first_name+' '+last_name as NomComplet from sales.staffs"));
            cbxManager.DisplayMember = "NomComplet";
            cbxManager.ValueMember = "staff_id";
            tblNavigationEmploye = Program.getData(new SqlCommand("select * from sales.staffs"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Rechercher avec procedure stockee
            SqlCommand cmd = new SqlCommand("getEmpParId");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtid.Text);
            SqlParameter p = new SqlParameter("@nbr", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);
            DataTable dt=  Program.getData(cmd);
            if (dt.Rows.Count > 0)
            {
                int act = (int.Parse(dt.Rows[0][5].ToString()));
                txtNom.Text = dt.Rows[0][1].ToString();
                txtPren.Text = dt.Rows[0][2].ToString();
                txtTel.Text = dt.Rows[0][4].ToString();
                txtEmail.Text = dt.Rows[0][3].ToString();
                checkBox1.Checked = act == 1 ? true : false;
                cbxMagasin.SelectedValue = dt.Rows[0][6];
                cbxManager.SelectedValue = dt.Rows[0][7];
            }
            else
                MessageBox.Show("Introuvable");
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            //Premier
            position=0;
            Navigation();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Dernier
            position = tblNavigationEmploye.Rows.Count-1;
            Navigation();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //precedent
            position--;
            Navigation();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //suivant
            position++;
            Navigation();

        }
    }
}
