using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErenDenemeProje1
{
    public partial class SehirEkle : Form
    {
        public SehirEkle()
        {
            InitializeComponent();
        }

        public bool YenidenYukle { get; set; }

        private void SehirEkle_Load(object sender, EventArgs e)
        {
            YenidenYukle = false;

            List<string> bolgeler = SehirlerVT.CografiBolgeleriGetir();

            cmbCografiBolge.Items.Clear();
            cmbCografiBolge.Items.Add("Seçiniz");
            foreach (string item in bolgeler)
            {
                cmbCografiBolge.Items.Add(item);
            }

            cmbCografiBolge.SelectedIndex = 0;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Sehirler sehir = new Sehirler 
            {
                SehirId = Convert.ToInt32(nudSehirId.Value),
                SehirAdi = txtSehirAdi.Text.ToUpper(),
                CografiBolge = cmbCografiBolge.SelectedItem.ToString()
            };
            bool islemYapildi = SehirlerVT.SehirEkle(sehir);
            if (islemYapildi)
            {
                YenidenYukle = true;
                this.Close();
            }
        }
    }
}
