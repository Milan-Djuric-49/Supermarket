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

namespace Supermarket
{
    public partial class Racun : Form
    {
        public Racun()
        {
            InitializeComponent();
        }

        proizvod[] proizvodi = new proizvod[100];

        private void Racun_Load(object sender, EventArgs e)
        {
            label1.Text = Program.user_ime + " " + Program.user_prezime;

            SqlConnection veza = Konekcija.Povezi();
            SqlCommand komanda = new SqlCommand("SELECT * FROM proizvod", veza);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                proizvodi[i] = new proizvod((int)tabela.Rows[i]["ID"], tabela.Rows[i]["Naziv"].ToString(),(int)tabela.Rows[i]["Cena"]);
                comboBox1.Items.Add(proizvodi[i].naziv);
            }
            
        }

        int[] proizvod_id = new int [100];
        int br = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox1.SelectedItem.ToString());
            listBox2.Items.Add(textBox1.Text);
            listBox3.Items.Add((Convert.ToInt32(textBox1.Text) * proizvodi[comboBox1.SelectedIndex].cena).ToString());

            proizvod_id[br] = proizvodi[comboBox1.SelectedIndex].id;
            br++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.Povezi();
            veza.Open();
            SqlCommand komanda = new SqlCommand("INSERT INTO racun VALUES (" + Program.user_id + ", GETDATE())", veza);
            komanda.ExecuteNonQuery();
            veza.Close();

            komanda = new SqlCommand("SELECT ID FROM racun", veza);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda); 
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            veza.Open();

            int id = (int)tabela.Rows[tabela.Rows.Count - 1]["ID"];

            for (int i = 0; i < br; i++)
            {
                listBox2.SetSelected(i, true);

                Console.WriteLine(proizvod_id[i]);
                Console.WriteLine(id);
                Console.WriteLine(listBox2.SelectedItem);

                komanda = new SqlCommand("INSERT INTO proizvod_racun (ID_proizvod,ID_racun,Kolicina_proizvoda) VALUES (" + proizvod_id[i] + ", " + id + ", " + listBox2.SelectedItem +")", veza);
                komanda.ExecuteNonQuery();
            }
            veza.Close();

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            br = 0;
        }
    }
}
