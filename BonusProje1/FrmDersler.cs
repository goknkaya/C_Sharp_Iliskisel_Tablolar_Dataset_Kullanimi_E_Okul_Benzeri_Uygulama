using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            // Dataset ile listeleme kullanımı
            
            dataGridView1.DataSource = ds.DersListesi();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ds.DersEkleme(txtLessonName.Text);
            MessageBox.Show("Ders ekleme işlemi başarılı");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtLessonID.Text));
            MessageBox.Show("Ders silme işlemi başarılı");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtLessonName.Text, byte.Parse(txtLessonID.Text));
            MessageBox.Show("Ders güncelleme işlemi başarılı");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLessonID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtLessonName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
