using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Analisador
{
    class Destacar
    {
        public int Ativar( RichTextBox p_Codigo = null,
                           string p_Palavra = "",
                           int p_Palavra_Tam = 0,
                           string p_Fonte_Nome = "",
                           Color ? p_Fonte_Cor = null,                           
                           FontStyle p_Fonte_Estilo = FontStyle.Regular,
                           int p_Fonte_Altura = 10 )
        {
            // Variáveis:
                int Ativar = 0;
                int indice = -1;
                int referencia = 0;
                Color Fonte_Cor = Color.Black;

            // Programa:
                // Truque para fazer um parâmetro do tipo Color ter valor padrão na declaração da função
                if (p_Fonte_Cor != null) { Fonte_Cor = (Color)p_Fonte_Cor; }

                while ((indice = p_Codigo.Text.IndexOf(p_Palavra, referencia)) != -1)
                {
                    p_Codigo.Select(indice, p_Palavra_Tam);
                    p_Codigo.SelectionColor = Fonte_Cor;
                    p_Codigo.SelectionFont = new Font(p_Fonte_Nome, p_Fonte_Altura, p_Fonte_Estilo);

                    referencia = indice + p_Palavra_Tam;
                    Ativar += 1;
                }
            // Fim:
            return Ativar;
        }

        public int Function( RichTextBox p_Codigo = null )
        {
            // Variáveis:
                int       Function = 0;
                string    palavra = "";
                int       palavra_Tam = 0;
                string    fonte_Nome = "";
                Color     fonte_Cor = Color.Blue;
                FontStyle fonte_Estilo = FontStyle.Bold;
                int       fonte_Altura = 0;

            // Programa:
                fonte_Nome   = p_Codigo.Font.ToString();
                fonte_Cor    = Color.Blue;
                fonte_Estilo = FontStyle.Bold;
                fonte_Altura = 10;
                palavra      = "function";
                palavra_Tam  = palavra.Length;

                Function = this.Ativar( p_Codigo, palavra, palavra_Tam, fonte_Nome, fonte_Cor, fonte_Estilo, fonte_Altura );

            // Fim:
                return Function;
        }

        public int Variavel( RichTextBox p_Codigo = null )
        {
            // Variáveis:
                int Variavel = 0;
                List<string> Variaveis = new List<string>();
                string codigo_fonte = "";
                int codigo_tam = 0;
                string palavra = "";
                int palavra_Tam = 0;
                string fonte_Nome = "";
                Color fonte_Cor = Color.Blue;
                FontStyle fonte_Estilo = FontStyle.Bold;
                int fonte_Altura = 0;
                string cifrao = "$";
                int cifrao_quant = 0;
                int indice_cifrao = -1;
                string espaco = " ";
                int espaco_quant = 0;
                int indice_espaco = -1;
                int referencia = 0;
                string letra_terminal = " .,;=(){}[]+-\t\n\0"; // espaço, ponto, virgula, ..., TAB, ENTER, NULO

            // Programa:
                codigo_fonte = p_Codigo.ToString();
                codigo_tam   = codigo_fonte.Length;
                codigo_fonte = codigo_fonte.Substring( 44, (codigo_fonte.Length-44) ); // retirando "System.Windows.Forms.RichTextBox, Text:     ";
                codigo_tam   = codigo_fonte.Length;
                fonte_Nome   = p_Codigo.Font.ToString();
                fonte_Cor    = Color.Green;
                fonte_Estilo = FontStyle.Bold;
                fonte_Altura = 10;

                // Selecionando cada variável:
                // Primeiro procura o símbolo "$" (cifrão)
                while ((indice_cifrao = codigo_fonte.IndexOf(cifrao, referencia)) != -1)
                {
                    cifrao_quant += 1;
                    // E procura o símbolo " " (espaço em branco) depois do "$" (cifrão)
                    indice_espaco = this.Encontra(codigo_fonte, indice_cifrao, letra_terminal); //codigo_fonte.IndexOf(espaco, indice_cifrao);
                    if( indice_espaco > -1 )
                    {
                        espaco_quant += 1;
                        palavra_Tam  = indice_espaco-indice_cifrao;
                        palavra = codigo_fonte.Substring( indice_cifrao, palavra_Tam );
                        
                        // Se a variável não foi destacada:
                        if ( Variaveis.IndexOf(palavra) == -1 )
                        {
                            Variaveis.Add(palavra);
                            Variavel += this.Ativar( p_Codigo, palavra, palavra_Tam, fonte_Nome, fonte_Cor, fonte_Estilo, fonte_Altura );
                        }

                        referencia = indice_espaco;
                    }
                    else
                    {
                        referencia = indice_cifrao+1;
                    }
                }

            // Fim:
            return Variavel;
        }

        public int Encontra( string p_Texto="", int p_Inicio=0, string p_Letras="")
        {
            // Variáveis:
                int Encontra     = -1;
                int Texto_Tam    = 0;
                int Texto_Pos    = 0;
                int Letras_Quant = 0;
                int Letras_Cont  = 0;
                bool encontrou   = false;

            // Programa:
                Texto_Tam = p_Texto.Length;
                Letras_Quant = p_Letras.Length;
                Texto_Pos = p_Inicio;
                while( Texto_Pos < Texto_Tam )
                {
                    for( Letras_Cont = 0; Letras_Cont < Letras_Quant; Letras_Cont++ )
                    {
                        if ( p_Texto[Texto_Pos] == p_Letras[Letras_Cont] )
                        {
                            encontrou = true;
                            Encontra = Texto_Pos;
                            Letras_Cont = Letras_Quant + 1;
                        }
                    }

                    if( encontrou )
                    {
                        Texto_Pos = Texto_Tam + 1;
                    }
                    else
                    {
                        Texto_Pos += 1;
                    }
                }

            // Fim:
                return Encontra;
        }
    }
}
