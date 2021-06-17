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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-INL76RD3\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        void List()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLKULUPLER", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            List();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO TBLKULUPLER (KULUPAD) VALUES (@p1)",connection);
            command.Parameters.AddWithValue("@p1",txtClubName.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kulüp listeye eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClubID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtClubName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Yellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from TBLKULUPLER where KULUPID = @p1",connection);
            command.Parameters.AddWithValue("@p1",txtClubID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kulüp silme işlemi gerçekleştirildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            List();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update TBLKULUPLER set KULUPAD = @p1 where KULUPID = @p2",connection);
            command.Parameters.AddWithValue("@p1",txtClubName.Text);
            command.Parameters.AddWithValue("@p2", txtClubID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kulüp güncelleme işlemi gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
        }
    }
}
