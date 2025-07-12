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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBL_Kategori.Count().ToString(); // Toplam ürün sayısını gösterir
            label3.Text = db.TBL_Urun.Count().ToString(); // Toplam müşteri sayısını gösterir
            label5.Text = db.TBL_Musteri.Count(x => x.DURUM==true).ToString(); // Aktif müşteri sayısını gösterir
            label7.Text = db.TBL_Musteri.Count(x => x.DURUM == false).ToString(); // Pasif müşteri sayısını gösterir
            label13.Text = db.TBL_Urun.Sum(x => x.STOK).ToString(); // Toplam stok sayısını gösterir
          label21.Text = db.TBL_SATIS.Sum(x => x.FİYAT).ToString()+ "  TL"; // Toplam ürün fiyatını gösterir
            label11.Text = (from x in db.TBL_Urun orderby x.FİYAT descending select x.URUNAD).FirstOrDefault(); // En yüksek ürün fiyatını gösterir
            label9.Text = (from x in db.TBL_Urun orderby x.FİYAT ascending select x.URUNAD).FirstOrDefault(); // En küçük  ürün fiyatını gösterir
            label15.Text=db.TBL_Urun.Count(x => x.KATEGORI == 1 ).ToString(); // Kategori ID'si 1 olan ürün sayısını gösterir
            label17.Text =  db.TBL_Urun.Count(x=>x.URUNAD=="BUZDOLABI").ToString(); // Ürün adı "BUZDOLABI" olan ürün sayısını gösterir
            label23.Text = (from x in db.TBL_Musteri  select x.SEHİR).Distinct().Count().ToString();
            label19.Text = db.MARKAGETİR().FirstOrDefault(); // En çok tercih edilen markayı gösterir


        }
    }
}



