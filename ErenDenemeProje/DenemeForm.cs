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
    public partial class DenemeForm : Form
    {
        public DenemeForm()
        {
            InitializeComponent();
        }

        private void ListeyiDoldur() 
        {
            lvVeriler.Items.Clear();

            List<Sehirler> list = SehirlerVT.SehirlerListesiniGetir(comboBox1.SelectedItem.ToString(), textBox1.Text);

            foreach (Sehirler item in list)
            {
                ListViewItem lvitem = new ListViewItem();

                lvitem.Text = item.SehirId.ToString();
                lvitem.SubItems.Add(item.CografiBolge);
                lvitem.SubItems.Add(item.SehirAdi);
                lvitem.SubItems.Add(item.ilcesayisi.ToString());

                lvVeriler.Items.Add(lvitem);
            }


            /*
            for (int i = 0; i < list.Count; i++)
            {
                Sehirler item = list[i];
            }
            */
        }

       

        private void DenemeForm_Load(object sender, EventArgs e)
        {
            List<string> bolgeler = SehirlerVT.CografiBolgeleriGetir();

            comboBox1.Items.Clear();
            comboBox1.Items.Add("TÜMÜ");
            foreach (string item in bolgeler)
            {
                comboBox1.Items.Add(item);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListeyiDoldur();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SehirEkle yeni = new SehirEkle();

            yeni.ShowDialog();

            if (yeni.YenidenYukle)
            {
                ListeyiDoldur();
            }
        }

        private void lvVeriler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            SehirGuncelle yeni = new SehirGuncelle();
            yeni.SehirId = Convert.ToInt32(lvVeriler.SelectedItems[0].SubItems[0].Text);
            yeni.ShowDialog();
            if(yeni.YenidenYukle == true)
            {
                ListeyiDoldur();
            }
            
        }
    }
}
