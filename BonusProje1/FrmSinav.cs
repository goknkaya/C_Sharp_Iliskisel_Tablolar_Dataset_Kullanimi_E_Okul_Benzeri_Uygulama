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
    public partial class FrmSinav : Form
    {
        public FrmSinav()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotGetir(int.Parse(txtStudentID.Text));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-INL76RD3\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void FrmSinav_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From TBLDERSLER", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbLesson.DisplayMember = "DERSAD";
            cmbLesson.ValueMember = "DERSID";
            cmbLesson.DataSource = dt;
            connection.Close();
        }

        int noteID;

        int exam1, exam2, exam3, project;
        double avg;

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            noteID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtStudentID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtExam3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtProject.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtAverage.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtState.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtExam1.Clear();
            txtExam2.Clear();
            txtExam3.Clear();
            txtProject.Clear();
            txtAverage.Clear();
            txtState.Clear();
        }

        string state;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            exam1 = Convert.ToInt16(txtExam1.Text);
            exam2 = Convert.ToInt16(txtExam2.Text);
            exam3 = Convert.ToInt16(txtExam3.Text);
            project = Convert.ToInt16(txtProject.Text);

            avg = (exam1 + exam2 + exam3 + project) / 4;

            txtAverage.Text = avg.ToString();

            if (avg >= 50)
            {
                txtState.Text = "True";
            }
            else
            {
                txtState.Text = "False";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbLesson.SelectedValue.ToString()), int.Parse(txtStudentID.Text), byte.Parse(txtExam1.Text), byte.Parse(txtExam2.Text), byte.Parse(txtExam3.Text), byte.Parse(txtProject.Text), decimal.Parse(txtAverage.Text), bool.Parse(txtState.Text), noteID);
            dataGridView1.DataSource = ds.NotGetir(int.Parse(txtStudentID.Text));
        }
    }
}
