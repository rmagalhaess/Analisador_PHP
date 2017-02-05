using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSharp_01
{
    public partial class frm_Aplicativo : Form
    {
        // ========================================================================
        public Control Encontra( string p_Nome="" )
        {
            // Variáveis:
                Control Encontra = null;
                Control[] Lst_Controles;

            // Programa
                Lst_Controles = this.Controls.Find(p_Nome, true);
                if (Lst_Controles != null)
                {
                    if (Lst_Controles.Length > 0)
                    {
                        Encontra = Lst_Controles[0];
                    }
                }

            // Fim:
                return Encontra;
        }

        // ========================================================================
        public frm_Aplicativo()
        {
            InitializeComponent();
        }

        // ========================================================================
        private void frm_Aplicativo_Load(object sender, EventArgs e)
        {
            // ok
        }

        // ========================================================================
        private void bto_Alerta_Click(object sender, EventArgs e)
        {
            // ok
            MessageBox.Show( "The calculations are complete", 
                             "My Application",
                             MessageBoxButtons.OKCancel, 
                             MessageBoxIcon.Asterisk);
        }

        private void bto_Arq_Abrir_Click(object sender, EventArgs e)
        {
            // Variáveis:
                Analisador analisador = new Analisador();
                int Quant_Funcoes = 0;
                string arq_caminho = "";
                string arq_conteudo = "";

            // Programa:
                if (dlg_Arq_Abrir.ShowDialog() == DialogResult.OK)
                {
                    arq_caminho = dlg_Arq_Abrir.FileName.ToString();

                    // Utilizando StreamReader:
                    //using (StreamReader Arquivo = new StreamReader(arq_caminho))
                    //{
                    //    Codigo_Fonte.Text = Arquivo.ReadToEnd();
                    //}

                    // Acessando o arquivo:
                    arq_conteudo = File.ReadAllText(arq_caminho, Encoding.UTF8);
                    Quant_Funcoes = analisador.Decompor(arq_conteudo, this);

                    /*
                    int indice = -1;
                    int referencia = 0;
                    string palavra = "";
                    rtf_Codigo_Fonte.Text = arq_conteudo;
                    palavra = "true";
                    while ((indice = rtf_Codigo_Fonte.Text.IndexOf(palavra, referencia)) != -1)
                    {
                        rtf_Codigo_Fonte.Select(indice, palavra.Length);
                        rtf_Codigo_Fonte.SelectionColor = Color.Green;
                        rtf_Codigo_Fonte.SelectionFont  = new Font("Comic Sans MS", 12, FontStyle.Bold);

                        referencia = indice + palavra.Length;
                    }
                    */

                // Fim:

            }

        }
    }
}
