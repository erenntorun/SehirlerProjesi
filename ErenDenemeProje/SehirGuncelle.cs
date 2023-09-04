using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ErenDenemeProje1
{
    public partial class SehirGuncelle : Form
    {
        public SehirGuncelle()
        {
            InitializeComponent();
        }
        public int SehirId { get; set; }


        private void ListeyiDoldur1()
        {
            lvVeriler.Items.Clear();
            List<Ilceler> list = SehirlerVT.IlcelerListesiniGetir(Convert.ToInt32(nudSehirId.Value));

            foreach (Ilceler item in list)
            {
                ListViewItem lvitem = new ListViewItem();

                lvitem.Text = item.IlceId.ToString();
                lvitem.SubItems.Add(item.IlceAdi);


                lvVeriler.Items.Add(lvitem);
            }



        }
        private void SehirGuncelle_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;
            //label1.Text = SehirId.ToString();

            List<string> bolgeler = SehirlerVT.CografiBolgeleriGetir();

            cmbCografiBolge.Items.Clear();
            cmbCografiBolge.Items.Add("Seçiniz");
            foreach (string item in bolgeler)
            {
                cmbCografiBolge.Items.Add(item);
            }

            cmbCografiBolge.SelectedIndex = 0;




            Sehirler sehir = SehirlerVT.SehirIdyeGoreGetir(SehirId);

            txtSehirAdi.Text = sehir.SehirAdi;
            cmbCografiBolge.SelectedItem = sehir.CografiBolge;
            nudSehirId.Value = sehir.SehirId;

            ListeyiDoldur1();



        }



           

        public bool YenidenYukle { get; set; }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Sehirler sehir = new Sehirler
            {
                SehirId = Convert.ToInt32(nudSehirId.Value),
                SehirAdi = txtSehirAdi.Text.ToUpper(),
                CografiBolge = cmbCografiBolge.SelectedItem.ToString()
            };
      
            bool islemYapildi = SehirlerVT.SehirGuncelle(sehir);
            if (islemYapildi)
            {
                YenidenYukle = true;
                this.Close();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.Yes)
            {
                bool islemYapildi = SehirlerVT.SehirSil(Convert.ToInt32(nudSehirId.Value));
                if (islemYapildi)
                {
                    YenidenYukle = true;
                    this.Close();
                }
            }

              
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            Ilceler ilce = new Ilceler
            {
                IlceId = 0,
                IlceAdi = textBox2.Text,
                SehirId = SehirId//Convert.ToInt32(nudSehirId.Value)

            };
            bool islemYapildi = SehirlerVT.IlceEkle(ilce);
            if (islemYapildi)
            {
                YenidenYukle = true;
                this.Close();
            }

        }
        int id;
        private void lvVeriler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = false;

            id = int.Parse(lvVeriler.SelectedItems[0].SubItems[0].Text);

            label4.Text = lvVeriler.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = lvVeriler.SelectedItems[0].SubItems[1].Text;
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled= true ;
            Ilceler ilce = new Ilceler
            {
                IlceId = id,
                IlceAdi = textBox2.Text.ToUpper()
              
            };

            bool islemYapildi = SehirlerVT.IlceGuncelle(ilce);
            if (islemYapildi)
            {
                YenidenYukle = true;
                ListeyiDoldur1();
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(sonuc == DialogResult.Yes)
            {
                bool islemYapildi = SehirlerVT.IlceSil(Convert.ToInt32(label4.Text));
                if (islemYapildi)
                {
                    YenidenYukle = true;
                    this.Close();
                }

            }

        }





    }
}
