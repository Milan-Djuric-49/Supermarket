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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_passw.Text == "")
            {
                MessageBox.Show("Molimo unesite sve podatke!");
                return;
            }
            else
            {

                try
                {
                    SqlConnection veza = Konekcija.Povezi();
                    SqlCommand komanda = new SqlCommand("SELECT * FROM kasir where Imejl =@username", veza);
                    komanda.Parameters.AddWithValue("@username", txt_name.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    int brojac = tabela.Rows.Count;
                    if (brojac == 1)
                    {
                        if (string.Compare(tabela.Rows[0]["Sifra"].ToString(), txt_passw.Text) == 0)
                        {
                            MessageBox.Show("Uspesna prijava!");
                            Program.user_ime = tabela.Rows[0]["Ime"].ToString();
                            Program.user_prezime = tabela.Rows[0]["Prezime"].ToString();
                            Program.user_id = (int)tabela.Rows[0]["ID"];
                            this.Hide();
                            Racun frm_racun = new Racun();
                            frm_racun.Show();
                        }
                        else
                        {
                            MessageBox.Show("Los password!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Nepostojeca email adresa!");
                    }

                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message);
                }
            }
        }
    }
}
