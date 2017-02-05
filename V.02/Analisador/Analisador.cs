using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Analisador
{
    class Analisador
    {
        public int Decompor( string p_Codigo_Fonte = "", frm_Aplicativo p_Formulario = null )
        {
            // Variáveis:
                int Quant_Funcoes = 0;
                int indice = -1;
                int referencia = 0;
                string palavra = "";
                string Inicio = "";
                int I_Ini = 0;
                //int I_Fim = 0;
                int I_Tam = 0;
                //Control[] Lst_Controles;
                RichTextBox rtf_Ini_Variaveis = null;
                RichTextBox rtf_Ini_Codigo = null;
                TabPage pag_Funcao = null;
                int CF_Tam = 0;
                List<int> Funcoes_Indices = new List<int>();
                int FI_Quant = 0;
                int FI_Cont = 0;
                string funcao = "";
                string F_Nome = "";
                int F_Ini = 0;
                int F_Tam = 0;
                RichTextBox rtf_Codigo_Funcao = null;
                RichTextBox rtf_Variaveis_Funcao = null;
                TabControl tab_Funcoes = null;

            // Programa:
                // Contabiliza as funções:
                    palavra = "function";
                    CF_Tam = p_Codigo_Fonte.Length;
                    while ((indice = p_Codigo_Fonte.IndexOf(palavra, referencia)) != -1)
                    {
                        Funcoes_Indices.Add(indice);
                        Quant_Funcoes += 1;
                        referencia = indice + palavra.Length;
                    }
                    FI_Quant = Funcoes_Indices.Count;

                // Exibe o Início do Código Fonte
                    I_Ini = 0;
                    I_Tam = (FI_Quant > 0 ? Funcoes_Indices[0] : CF_Tam);
                    Inicio = p_Codigo_Fonte.Substring(I_Ini, I_Tam);
                    Inicio = Inicio.Replace("\t", "    ");

                    rtf_Ini_Variaveis = (RichTextBox) p_Formulario.Encontra("rtf_Ini_Variaveis");
                    rtf_Ini_Variaveis.Text = "Variáveis ?";

                    rtf_Ini_Codigo = (RichTextBox) p_Formulario.Encontra("rtf_Ini_Codigo");
                    rtf_Ini_Codigo.Text = Inicio;

                // Exibe cada função em uma Aba, na Aba Funções
                    //FI_Quant = Funcoes_Indices.Count - 1;
                    for (FI_Cont = 0; FI_Cont < FI_Quant; FI_Cont++ )
                    {
                        F_Nome = "Funcao_" + (FI_Cont + 1);
                        F_Ini = Funcoes_Indices[FI_Cont];
                        F_Tam = ( (FI_Cont < (FI_Quant-1)) ? Funcoes_Indices[FI_Cont+1] : CF_Tam ) - F_Ini;

                        // Inicia com "4 espaços", e substitui todos os "tab's" por "4 espeços"
                        funcao = "    "+p_Codigo_Fonte.Substring(F_Ini, F_Tam);
                        funcao = funcao.Replace("\t", "    ");
                        
                        rtf_Variaveis_Funcao = new RichTextBox();
                        rtf_Codigo_Funcao = new RichTextBox();
                        pag_Funcao = new TabPage();

                        pag_Funcao.Location = new Point(4, 22);
                        pag_Funcao.Name = F_Nome;
                        pag_Funcao.Padding = new Padding(3);
                        pag_Funcao.Size = new Size(442, 328);
                        pag_Funcao.TabIndex = FI_Cont;
                        pag_Funcao.Text = F_Nome;
                        pag_Funcao.UseVisualStyleBackColor = true;
                        pag_Funcao.Controls.Add(rtf_Variaveis_Funcao);
                        pag_Funcao.Controls.Add(rtf_Codigo_Funcao);

                        //rtf_Variaveis_Funcao.Dock = System.Windows.Forms.DockStyle.Fill;
                        rtf_Variaveis_Funcao.Location = new Point(3, 27);
                        rtf_Variaveis_Funcao.Size = new Size(214, 390);                        
                        rtf_Variaveis_Funcao.Font = new Font("monofur", 10, FontStyle.Regular);
                        rtf_Variaveis_Funcao.Name = "rtf_Variaveis_Funcao_" + (FI_Cont + 1);
                        rtf_Variaveis_Funcao.TabIndex = 0;
                        rtf_Variaveis_Funcao.Text = "Variáveis ?";
                        rtf_Variaveis_Funcao.WordWrap = false;

                        //rtf_Codigo_Funcao.Dock = System.Windows.Forms.DockStyle.Fill;
                        rtf_Codigo_Funcao.Location = new Point(222, 27);
                        rtf_Codigo_Funcao.Size = new Size(686, 390);
                        rtf_Codigo_Funcao.Font = new Font("monofur", 10, FontStyle.Regular);
                        rtf_Codigo_Funcao.Name = "rtf_Codigo_Funcao_"+ (FI_Cont+1);
                        rtf_Codigo_Funcao.TabIndex = 1;
                        rtf_Codigo_Funcao.Text = funcao;
                        rtf_Codigo_Funcao.WordWrap = false;

                        tab_Funcoes = (TabControl) p_Formulario.Encontra("tab_Funcoes");
                        tab_Funcoes.Controls.Add(pag_Funcao);
                    }

            // Fim:
                return Quant_Funcoes;
        }
    }
}
