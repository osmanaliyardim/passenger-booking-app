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

namespace Yolcu_Rezervasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-N9EER84;Initial Catalog=Yolcu_Bilet;Integrated Security=True");

        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select SEFERNO as Sefer_No,KALKIS as Nerden,VARIS as Nereye,TARIH as Tarih, SAAT as Saat, KAPTAN as Sürücü_No,FIYAT as Fiyat from TBLSEFER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource=dt;
        }

        private void btnBiletAl_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLYOLCUBILGI (AD,SOYAD,TC,MAIL,TELEFON,CINSIYET) values (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", mskTc.Text);
            komut.Parameters.AddWithValue("@P4", txtMail.Text);
            komut.Parameters.AddWithValue("@P5", mskTel.Text);
            komut.Parameters.AddWithValue("@P6", cmbCinsiyet.SelectedItem);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu sisteme kaydedildi!");
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTc.Text = "";
            txtMail.Text = "";
            mskTel.Text = "";
            cmbCinsiyet.SelectedItem = null;
        }

        private void btnKaptanEkle_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLKAPTAN (KAPTANNO,ADSOYAD,TELEFON) values (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtKaptanNo.Text);
            komut.Parameters.AddWithValue("@P2", txtKaptanAd.Text);
            komut.Parameters.AddWithValue("@P3", mskKaptanTel.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaptan sisteme kaydedildi!");
            txtKaptanNo.Text = "";
            txtKaptanAd.Text = "";
            mskKaptanTel.Text = "";
        }

        private void btnSeferEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFER (KALKIS,VARIS,TARIH,SAAT,KAPTAN,FIYAT) values (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtKalkis.Text);
            komut.Parameters.AddWithValue("@P2", txtVaris.Text);
            komut.Parameters.AddWithValue("@P3", mskTarih.Text);
            komut.Parameters.AddWithValue("@P4", mskSaat.Text);
            komut.Parameters.AddWithValue("@P5", mskKaptan.Text);
            komut.Parameters.AddWithValue("@P6", txtFiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer sisteme kaydedildi!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seferlistesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen=dataGridView1.SelectedCells[0].RowIndex;

            txtSefer.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtKalkis.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtVaris.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskTarih.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskSaat.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mskKaptan.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtFiyat.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            txtSeferNumara.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "9";
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblseferdetay (seferno,yolcutc,koltuk) values (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtSeferNumara.Text);
            komut.Parameters.AddWithValue("@P2", mskYolcuTC.Text);
            komut.Parameters.AddWithValue("@P3", txtKoltuk.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezervasyon başarılı!");
            txtSeferNumara.Text = "";
            mskYolcuTC.Text = "";
            txtKoltuk.Text = "";
        }

        private void button50_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BU UYGULAMA 'OSMAN ALi YARDIM' TARAFINDAN GELİŞTİRİLMİŞTİR!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
