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
        }

        // ========================================================================
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
                RichTextBox rtf_Variaveis_Funcao = null;
                TabControl tab_Funcoes = null;

            // Programa:
                // Apaga todos os dados anteriores:
                tab_Funcoes = (TabControl) this.Encontra("tab_Funcoes");
                if( tab_Funcoes != null )
                {
                    tab_Funcoes.Controls.Clear();
                }

                // Abre um novo arquivo:
                if ( dlg_Arq_Abrir.ShowDialog() == DialogResult.OK )
                {
                    arq_caminho = dlg_Arq_Abrir.FileName.ToString();

                    // Acessando o arquivo:
                        arq_conteudo = File.ReadAllText(arq_caminho, Encoding.UTF8);
                        Decompor = analisador.Decompor(arq_conteudo, this);

                    // Destacando comandos:
                        destacar.Variaveis(this.rtf_Ini_Codigo, this.rtf_Ini_Variaveis);
                        destacar.Comandos(this.rtf_Ini_Codigo);
                        destacar.Funcoes(this.rtf_Ini_Codigo);
                        destacar.Valores(this.rtf_Ini_Codigo);
                        destacar.String_Simples(this.rtf_Ini_Codigo);
                        destacar.String_Dupla(this.rtf_Ini_Codigo);                        

                        Funcoes_Quant = Decompor+1;
                        for (Funcoes_Cont=1; Funcoes_Cont< Funcoes_Quant; Funcoes_Cont++)
                        {
                            rtf_Codigo_Funcao = (RichTextBox)this.Encontra("rtf_Codigo_Funcao_" + Funcoes_Cont);
                            rtf_Variaveis_Funcao = (RichTextBox)this.Encontra("rtf_Variaveis_Funcao_" + Funcoes_Cont);
                            if ( rtf_Codigo_Funcao != null )
                            {
                                destacar.Variaveis(rtf_Codigo_Funcao, rtf_Variaveis_Funcao);
                                destacar.Comandos(rtf_Codigo_Funcao);
                                destacar.Funcoes(rtf_Codigo_Funcao);
                                destacar.Valores(rtf_Codigo_Funcao);                                
                                destacar.String_Simples(rtf_Codigo_Funcao);
                                destacar.String_Dupla(rtf_Codigo_Funcao);
                            }                            
                        }                        
                }

            // Fim:

        }
    }
}
