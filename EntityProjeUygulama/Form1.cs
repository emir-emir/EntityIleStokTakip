using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        void Listele()
        {
            // LINQ ile listeleme
            var kategori = (from x in db.TBL_Kategori
                            select new
                            {
                                x.ID,
                                x.AD
                            }).ToList();
            dataGridView1.DataSource = kategori;
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            // lİSTELEMENİN BİRİNCİ YOLU
            //var kategori=      db.TBL_Kategori.ToList();
            //dataGridView1.DataSource = kategori;

            // lİSTELEMENİN İKİNCİ  YOLU

            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
             TBL_Kategori K = new TBL_Kategori();
            K.AD=TxtAdı.Text;
            db.TBL_Kategori.Add(K);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi","EKLEME",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();

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
                var ktgr = db.TBL_Kategori.Find(x);
                db.TBL_Kategori.Remove(ktgr);
                db.SaveChanges();
                MessageBox.Show("Kategori Silindi", "SİLME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Listele();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var ktgr = db.TBL_Kategori.Find(x);
            ktgr.AD = TxtAdı.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi", "GÜNCELLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAdı.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
         
        }
    }
}
