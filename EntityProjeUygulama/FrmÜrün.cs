using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class FrmÜrün : Form
    {
        public FrmÜrün()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnGüncelle_Click(object sender, EventArgs e)

        {
            int x = Convert.ToInt32(TxtID.Text);
            var ürün = db.TBL_Urun.Find(x);
            ürün.URUNAD = TxtAd.Text;
            ürün.MARKA = TxtMarka.Text;
            ürün.STOK = short.Parse(TxtStok.Text);
            ürün.FİYAT = decimal.Parse(TxtFiyat.Text);
          

            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi", "GÜNCELLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
       
       /*     var urun = db.TBL_Urun.ToList();
            dataGridView1.DataSource = urun;
       */
            var urun = (from x in db.TBL_Urun
                        select new
                        {
                            x.URUNID,
                            x.URUNAD,
                            x.MARKA,
                            x.STOK,
                            x.FİYAT,
                            x.DURUM,
                            x.TBL_Kategori.AD
                                                              //   x.TBL_Kategori.AD // Kategori adını ekliyoruz
                        }).ToList();
            dataGridView1.DataSource = urun;

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {

            TBL_Urun U = new TBL_Urun();
            U.URUNAD = TxtAd.Text;
            U.MARKA = TxtMarka.Text;
            U.STOK = short.Parse(TxtStok.Text);
            U.FİYAT = decimal.Parse(TxtFiyat.Text);
            U.DURUM = true; // Varsayılan olarak ürün durumu aktif
            U.KATEGORI = int.Parse(CmbKategori.SelectedValue.ToString()); // Kategori ID'si girilmelidir


            db.TBL_Urun.Add(U);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi", "EKLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {

                MessageBox.Show("Lütfen Silinecek Kategori ID Giriniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int x = Convert.ToInt32(TxtID.Text);
                var ürün = db.TBL_Urun.Find(x);
                db.TBL_Urun.Remove(ürün);
                db.SaveChanges();
                MessageBox.Show("ÜRÜN SİLİNDİi", "SİLME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtMarka.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtFiyat.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            CmbKategori.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
         
        }

        private void FrmÜrün_Load(object sender, EventArgs e)
        {
            var kategrori = (from x in db.TBL_Kategori
                             select new
                             { 
                                 x.ID, 
                                 x.AD
                             }).ToList();
            CmbKategori.ValueMember = "ID"; // Kategori ID'si
            CmbKategori.DisplayMember = "AD"; // Kategori Adı
           
            CmbKategori.DataSource = kategrori;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
            TxtMarka.Text = "";
            TxtStok.Text = "";
            TxtFiyat.Text = "";
            TxtID.Text = "";
            TxtDurum.Text = "";
            CmbKategori.Text = "";
         dataGridView1.DataSource = null; // DataGridView içeriğini temizle
        dataGridView1.Rows.Clear(); // DataGridView satırlarını temizle


        }
    }
}
