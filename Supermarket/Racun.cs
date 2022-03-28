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

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox1.SelectedItem.ToString());
            listBox2.Items.Add(textBox1.Text);
            listBox3.Items.Add((Convert.ToInt32(textBox1.Text) * proizvodi[comboBox1.SelectedIndex].cena).ToString());
        }
    }
}
