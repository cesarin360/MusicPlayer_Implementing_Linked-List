using PlayerV1._0.ListaPuntos;
using PlayerV1._0.objListaOrdenada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerV1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            track_volumen.Value = 100;
            lbl_volume.Text = track_volumen.Value.ToString();
            pic_art.Enabled = false;
            btn_pause.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex > 0)
            {
                track_list.SelectedIndex -= 1;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pic_art.Enabled = false;
            vlcControl1.Stop();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            vlcControl1.Audio.Volume = track_volumen.Value;
            lbl_volume.Text = track_volumen.Value.ToString();
        }

        private void lbl_volume_Click(object sender, EventArgs e)
        {

        }
        public LinkedList addPath = new LinkedList();
        public Nodo lista =  null;
        public int x = 0, n;
        public String n_pl = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Music files (*.mp3, *.m4a) | *.mp3; *.m4a",
                Multiselect = true
            };
           
            openFileDialog1.InitialDirectory = "C:\\Users\\josue\\Music";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                x = n;
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    addPath.Inserta(openFileDialog1.FileNames[i]);  
                    
                }
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    lista = addPath.BuscarPosicion(x);
                    track_list.Items.Add(addPath.BuscarPosicion(x).getDato().Replace("C:\\Users\\josue\\Music\\", ""));
                    x++;
                    int pausa;
                    pausa = 0;

                }
                track_list.SelectedIndex = 0;
                n = x;
                //x = 0;
            }
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            vlcControl1.SetPause(true);
            btn_pause.Hide();
            btn_play.Show();
            pic_art.Enabled = false;
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            if (track_list.Items.Count != 0)
            {
                vlcControl1.Play();
                btn_play.Hide();
                btn_pause.Show();
                pic_art.Enabled = true;
            }
            else
            {
                MessageBox.Show("¡AGREGA CANCIONES A TU LISTA!");
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex < track_list.Items.Count - 1)
            {
                track_list.SelectedIndex += 1;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_trash_Click(object sender, EventArgs e)
        {
            vlcControl1.Stop();
            int x = track_list.SelectedIndex;
            addPath.eliminar(x);
            track_list.Items.Remove(track_list.SelectedItem);
            x--;
            n--;
            if (track_list.Items.Count == 0)
            {
                MessageBox.Show("LA LISTA ESTA VACIA");
                pic_art.Enabled = false;
                x = 0;
            }

        }

        private void track_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (track_list.Items.Count == 0)
            {
                vlcControl1.Stop();
            }
            else
            {
                int selected;
                if (track_list.SelectedItem != null)
                {
                    selected = track_list.SelectedIndex;
                    vlcControl1.SetMedia(new System.IO.FileInfo(addPath.BuscarPosicion(selected).dato));
                    pic_art.Enabled = true;
                   
                }
                else
                {
                    if (track_list.SelectedIndex < track_list.Items.Count - 1)
                    {
                        
                        track_list.SelectedIndex += 1;
                        selected = track_list.SelectedIndex;
                        vlcControl1.SetMedia(new System.IO.FileInfo(addPath.BuscarPosicion(selected).dato));
                        pic_art.Enabled = true;

                    }
                    if (track_list.SelectedIndex > 0)
                    {
                        track_list.SelectedIndex -= 1;
                        selected = track_list.SelectedIndex;
                        vlcControl1.SetMedia(new System.IO.FileInfo(addPath.BuscarPosicion(selected).dato));
                        pic_art.Enabled = true;
                    }
                }
                vlcControl1.Play();
                btn_play.Hide();
                btn_pause.Show();
            }
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (track_list.Items.Count == 0)
            {
                MessageBox.Show("LA LISTA ESTA VACIA");
            }
            else
            {
                string message = "¿Estas seguro que quieres eliminar los elementos de la lista?";
                string caption = "Pregunta";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    track_list.Items.Clear();
                    vlcControl1.Stop();
                    pic_art.Enabled = false;
                    for (int j = 0; j <= n; j++)
                    {
                        addPath.eliminar(j);
                        addPath.primero = null;
                        lista = null;
                        x = 0;
                    }
                    btn_pause.Hide();
                    btn_play.Show();
                }
            }

        }
        private void btn_playlist_Click(object sender, EventArgs e)
        {
            Playlist_Form frm2 = new Playlist_Form();
            frm2.Plyl_name.Text = n_pl;
            for (int j = 0; j < n && lista != null; j++)
            {
                lista = addPath.BuscarPosicion(j);
                frm2.track_list2.Items.Add(lista.getDato());
                
            }
            vlcControl1.Stop();
            frm2.Show();
            this.Hide();
        }
    }
}
