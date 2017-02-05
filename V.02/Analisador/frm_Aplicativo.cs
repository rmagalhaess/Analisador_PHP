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

namespace Analisador
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
            // por enquanto nada...
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
                Destacar destacar = new Destacar();
                int Decompor = 0;
                int Funcoes_Quant = 0;
                int Funcoes_Cont = 0;
                string arq_caminho = "";
                string arq_conteudo = "";
                RichTextBox rtf_Codigo_Funcao = null;   

            // Programa:
                if (dlg_Arq_Abrir.ShowDialog() == DialogResult.OK)
                {
                    arq_caminho = dlg_Arq_Abrir.FileName.ToString();

                    // Acessando o arquivo:
                        arq_conteudo = File.ReadAllText(arq_caminho, Encoding.UTF8);
                        Decompor = analisador.Decompor(arq_conteudo, this);

                    // Destacando comandos:
                        Funcoes_Quant = Decompor+1;
                        for (Funcoes_Cont=1; Funcoes_Cont< Funcoes_Quant; Funcoes_Cont++)
                        {
                            rtf_Codigo_Funcao = (RichTextBox)this.Encontra("rtf_Codigo_Funcao_" + Funcoes_Cont);
                            if ( rtf_Codigo_Funcao != null )
                            {
                                destacar.Function(rtf_Codigo_Funcao);
                                destacar.Variavel(rtf_Codigo_Funcao);
                            }                            
                        }                        
                }

            // Fim:

        }
    }
}
