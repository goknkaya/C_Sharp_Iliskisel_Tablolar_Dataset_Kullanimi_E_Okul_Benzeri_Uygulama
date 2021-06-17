using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-INL76RD3\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListele();
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From TBLKULUPLER",connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbStudentClub.DisplayMember = "KULUPAD";
            cmbStudentClub.ValueMember = "KULUPID";
            cmbStudentClub.DataSource = dt;
            connection.Close();
        }
        string c = ""; //Cinsiyet

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rdStudentBoy.Checked==true)
            {
                c = "ERKEK";
            }
            if (rdStudentGirl.Checked==true)
            {
                c = "KIZ";
            }
            ds.OgrenciEkle(txtStudentName.Text,txtStudentSurname.Text,byte.Parse(cmbStudentClub.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci ekleme işlemi başarılı");
            dataGridView1.DataSource = ds.OgrenciListele();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListele();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ds.OgrenciSilme(int.Parse(txtStudentID.Text));
            MessageBox.Show("Öğrenci silme işlemi başarılı");
            dataGridView1.DataSource = ds.OgrenciListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudentID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtStudentName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStudentSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbStudentClub.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            label7.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
            if (label7.Text=="Erkek")
            {
                rdStudentBoy.Checked = true;
            }
            if (label7.Text=="Kız")
            {
                rdStudentGirl.Checked = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtStudentName.Text, txtStudentSurname.Text, byte.Parse(cmbStudentClub.SelectedValue.ToString()), c, int.Parse(txtStudentID.Text));
        }

        private void rdStudentGirl_CheckedChanged(object sender, EventArgs e)
        {
            if (rdStudentGirl.Checked==true)
            {
                c = "KIZ";
            }
        }

        private void rdStudentBoy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdStudentBoy.Checked==true)
            {
                c = "ERKEK";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtStudentSearch.Text); // Öğrenci adına göre arama yapıyor.
        }
    }
}
