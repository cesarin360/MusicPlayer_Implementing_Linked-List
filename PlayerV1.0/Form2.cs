using PlayerV1._0.ListaPuntos;
using PlayerV1._0.objListaOrdenada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerV1._0
{
    public partial class Playlist_Form : Form
    {
        public Playlist_Form()
        {
            InitializeComponent();
        }
        public Nodo lista;
        private Form1 frm = new Form1();
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (track_list2.Items.Count == 0)
            {
                MessageBox.Show("LA LISTA ESTA VACIA.");
            }
            else
            {
                if (Plyl_name.Text == "")
                {
                    MessageBox.Show("POR FAVOR INGRESA UN NOMBRE");
                }
                else
                {
                    StreamWriter sw = new StreamWriter(@"C:\Users\josue\Desktop\" + Plyl_name.Text + ".txt");
                    foreach (object lista in track_list2.Items)
                    {
                        sw.WriteLine(lista.ToString());
                    }
                    sw.Close();
                    MessageBox.Show("EL PLAYLIST SE HA GUARDADO CORRECTAMENTE");
                    Plyl_name.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm.Show();
            this.Close();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.InitialDirectory = "C:\\Users\\josue\\Desktop";
            openFileDialog2.Filter = "( *.txt) |  *.txt";
            openFileDialog2.Multiselect = false;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(Convert.ToString(@"" + openFileDialog2.FileName));
                track_list2.Items.Clear();
                while (sr.Peek() >= 0)
                {
                    track_list2.Items.Add(Convert.ToString(sr.ReadLine()));
                   
                }
                sr.Close();
                int contador = 0;
                foreach (String dato in track_list2.Items)
                {
                    frm.x = 0;
                    frm.addPath.Inserta(dato);
                    contador += 1;
                    frm.x++;
                }
                for(int i = 0; i<contador; i++)
                {
                    lista = frm.addPath.BuscarPosicion(i);
                    frm.track_list.Items.Add(frm.addPath.BuscarPosicion(i).getDato().Replace("C:\\Users\\josue\\Music\\", ""));
                }
                //frm.n_pl = openFileDialog2.SafeFileName;
                this.Close();
                frm.Refresh();
                frm.Show();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Playlist_Form_Load(object sender, EventArgs e)
        {
        }
    }
}
