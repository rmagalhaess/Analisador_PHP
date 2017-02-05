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

        // ========================================================================
        public int Encontra( string p_Texto  = "", 
                             int    p_Inicio = 0, 
                             string p_Letras = "")
        {
            // Variáveis:
                int  Encontra     = -1;
                int  Texto_Tam    = 0;
                int  Texto_Pos    = 0;
                int  Letras_Quant = 0;
                int  Letras_Cont  = 0;
                bool encontrou    = false;

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
                            Encontra = Texto_Pos;
                            encontrou = true;       
                        
                            // Sai do FOR                     
                            Letras_Cont = Letras_Quant + 1;
                        }
                    }

                    if( encontrou )
                    {
                        // Sai do WHILE
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

        // ========================================================================
        public int Ativar( RichTextBox p_Codigo       = null,
                           string      p_Palavra      = "",
                           int         p_Palavra_Tam  = 0,
                           string      p_Fonte_Nome   = "",
                           Color     ? p_Fonte_Cor    = null,                           
                           FontStyle ? p_Fonte_Estilo = null,
                           int         p_Fonte_Altura = 10 )
        {
            // Variáveis:
                int       Ativar       = 0;
                int       indice       = -1;
                int       referencia   = 0;
                Color     Fonte_Cor    = Color.Black;
                FontStyle Fonte_Estilo = FontStyle.Regular;

            // Programa:
                // Truque para fazer um parâmetro do tipo Color/FontStyle ter valor padrão na declaração da função
                if (p_Fonte_Cor != null) { Fonte_Cor = (Color)p_Fonte_Cor; }
                if (p_Fonte_Estilo != null) { Fonte_Estilo = (FontStyle)p_Fonte_Estilo; }

                // Ativando as palavras no texto:
                while ((indice = p_Codigo.Text.IndexOf(p_Palavra, referencia)) != -1)
                {
                    p_Codigo.Select(indice, p_Palavra_Tam);
                    p_Codigo.SelectionColor = Fonte_Cor;
                    p_Codigo.SelectionFont = new Font( p_Fonte_Nome, p_Fonte_Altura, Fonte_Estilo );

                    referencia = indice + p_Palavra_Tam;
                    Ativar += 1;
                }
            // Fim:
                return Ativar;
        }

        // ========================================================================
        public int Variaveis( RichTextBox p_Codigo    = null, 
                              RichTextBox p_Variaveis = null )
        {
            // Variáveis:
                int          Variaveis      = 0;
                List<string> Lst_Variaveis  = new List<string>();

                string    codigo_fonte      = "";
                int       codigo_tam        = 0;
                string    palavra           = "";
                int       palavra_Tam       = 0;
                string    fonte_Nome        = "";
                Color     fonte_Cor         = Color.Blue;
                FontStyle fonte_Estilo      = FontStyle.Bold;
                int       fonte_Altura      = 0;
                string    cifrao            = "$";
                int       cifrao_quant      = 0;
                int       indice_cifrao     = -1;
                int       indice_terminal   = -1;
                int       referencia_cifrao = 0;
                string    letra_terminal    = " .,;=(){}[]+-\t\n"; // espaço, ponto, virgula, ..., TAB, ENTER, NULO

            // Programa:
                codigo_fonte = p_Codigo.Text;
                codigo_tam   = codigo_fonte.Length;
                fonte_Nome   = p_Codigo.Font.ToString();
                fonte_Cor    = Color.Green;
                fonte_Estilo = FontStyle.Regular;
                fonte_Altura = 10;

                // Selecionando cada variável:
                // Primeiro procura o símbolo "$" (cifrão)
                while (( cifrao_quant < 9999 ) &&
                       ( indice_cifrao < codigo_tam ) && 
                      (( indice_cifrao = this.Encontra(codigo_fonte, referencia_cifrao, cifrao)) != -1) ) 
                {
                    cifrao_quant += 1;
                    // E procura o símbolo " " (espaço em branco) depois do "$" (cifrão)
                    indice_terminal = this.Encontra( codigo_fonte, 
                                                     indice_cifrao, 
                                                     letra_terminal ); 
                    if( indice_terminal > -1 )
                    {
                        palavra_Tam  = indice_terminal-indice_cifrao;
                        palavra = codigo_fonte.Substring( indice_cifrao, palavra_Tam );
                        
                        // Se a variável não foi destacada:
                        if ( Lst_Variaveis.IndexOf(palavra) == -1 )
                        {
                            Lst_Variaveis.Add(palavra);
                            p_Variaveis.Text += palavra + "\n";
                            Variaveis += this.Ativar( p_Codigo, 
                                                      palavra, 
                                                      palavra_Tam, 
                                                      fonte_Nome, 
                                                      fonte_Cor, 
                                                      fonte_Estilo, 
                                                      fonte_Altura );
                        }

                        referencia_cifrao = indice_terminal;
                    }
                    else
                    {
                        referencia_cifrao = indice_cifrao+1;
                    }
                }

                if( cifrao_quant == 9999 )
                {
                    MessageBox.Show( "if( cifrao_quant == 9999 )", 
                                     "Destacar::Variavel",
                                     MessageBoxButtons.OKCancel, 
                                     MessageBoxIcon.Asterisk);
                }

            // Fim:
            return Variaveis;
        }

        // ========================================================================
        public int Funcoes( RichTextBox p_Codigo = null )
        {
            // Variáveis:
                int          Funcoes = 0;
                List<string> Lst_Funcoes = new List<string>(new string[] { "die", "include", "include_once",
                                                                           "is_null", "isempty" });
                int       Lst_Funcoes_Quant = 0;
                int       Lst_Funcoes_Cont  = 0;
                string    palavra           = "";
                int       palavra_Tam       = 0;
                string    fonte_Nome        = "";
                Color     fonte_Cor         = Color.Blue;
                FontStyle fonte_Estilo      = FontStyle.Bold;
                int       fonte_Altura      = 0;

            // Programa:
                fonte_Nome   = p_Codigo.Font.ToString();
                fonte_Cor    = Color.Red;
                fonte_Estilo = FontStyle.Regular;
                fonte_Altura = 10;

                Lst_Funcoes_Quant = Lst_Funcoes.Count;
                for ( Lst_Funcoes_Cont = 0; Lst_Funcoes_Cont < Lst_Funcoes_Quant; Lst_Funcoes_Cont++ )
                {
                    palavra      = Lst_Funcoes[ Lst_Funcoes_Cont ];
                    palavra_Tam  = palavra.Length;
                    Funcoes += this.Ativar( p_Codigo, 
                                            palavra, 
                                            palavra_Tam, 
                                            fonte_Nome, 
                                            fonte_Cor, 
                                            fonte_Estilo, 
                                            fonte_Altura );
                }
                
            // Fim:
                return Funcoes;
        }

        // ========================================================================
        public int Comandos( RichTextBox p_Codigo = null )
        {
            // Variáveis:
                int          Comandos = 0;
                List<string> Lst_Comandos = new List<string>(new string[] { "function", "return",
                                                                            "echo", "print_r",
                                                                            "if", "else", "elseif", "switch", "case", "default", "break",
                                                                            "for", "while", "do" });
                int       Lst_Comandos_Quant = 0;
                int       Lst_Comandos_Cont  = 0;
                string    palavra            = "";
                int       palavra_Tam        = 0;
                string    fonte_Nome         = "";
                Color     fonte_Cor          = Color.Blue;
                FontStyle fonte_Estilo       = FontStyle.Bold;
                int       fonte_Altura       = 0;

            // Programa:
                fonte_Nome   = p_Codigo.Font.ToString();
                fonte_Cor    = Color.Blue;
                fonte_Estilo = FontStyle.Regular;
                fonte_Altura = 10;

                Lst_Comandos_Quant = Lst_Comandos.Count;
                for( Lst_Comandos_Cont = 0; Lst_Comandos_Cont < Lst_Comandos_Quant; Lst_Comandos_Cont++ )
                {
                    palavra      = Lst_Comandos[ Lst_Comandos_Cont ];
                    palavra_Tam  = palavra.Length;
                    Comandos += this.Ativar( p_Codigo, 
                                             palavra, 
                                             palavra_Tam, 
                                             fonte_Nome, 
                                             fonte_Cor, 
                                             fonte_Estilo, 
                                             fonte_Altura );
                }
                
            // Fim:
                return Comandos;
        }
        
        // ========================================================================
        public int Valores( RichTextBox p_Codigo = null )
        {
            // Variáveis:
                int          Valores = 0;
                List<string> Lst_Valores = new List<string>(new string[] { "null", "true", "false",
                                                                           "__FILE__", "__FUNCTION__", "__LINE__" });
                int       Lst_Valores_Quant = 0;
                int       Lst_Valores_Cont  = 0;
                string    palavra           = "";
                int       palavra_Tam       = 0;
                string    fonte_Nome        = "";
                Color     fonte_Cor         = Color.Blue;
                FontStyle fonte_Estilo      = FontStyle.Bold;
                int       fonte_Altura      = 0;

            // Programa:
                fonte_Nome   = p_Codigo.Font.ToString();
                fonte_Cor    = Color.DarkOrange;
                fonte_Estilo = FontStyle.Regular;
                fonte_Altura = 10;

                Lst_Valores_Quant = Lst_Valores.Count;
                for( Lst_Valores_Cont = 0; Lst_Valores_Cont < Lst_Valores_Quant; Lst_Valores_Cont++ )
                {
                    palavra      = Lst_Valores[ Lst_Valores_Cont ];
                    palavra_Tam  = palavra.Length;
                    Valores += this.Ativar( p_Codigo, 
                                            palavra, 
                                            palavra_Tam, 
                                            fonte_Nome, 
                                            fonte_Cor, 
                                            fonte_Estilo, 
                                            fonte_Altura );
                }
                
            // Fim:
                return Valores;
        }

        // ========================================================================
        public int String_Simples( RichTextBox p_Codigo = null )
        {
            // Variáveis:
                int       String_Simples         = 0;

                string    codigo_fonte           = "";
                int       codigo_tam             = 0;
                string    palavra                = "";
                int       palavra_Tam            = 0;
                string    fonte_Nome             = "";
                Color     fonte_Cor              = Color.Blue;
                FontStyle fonte_Estilo           = FontStyle.Bold;
                int       fonte_Altura           = 0;
                string    aspas_simples          = "'";
                string    letra_anterior         = "";
                int       aspas_abre_quant       = 0;
                int       indice_aspas_abre      = -1;
                int       referencia_aspas_abre  = 0;
                int       aspas_fecha_quant      = 0;
                int       indice_aspas_fecha     = -1;
                int       referencia_aspas_fecha = 0;
                bool      encontrou              = false;
                bool      terminou               = false;

            // Programa:
                codigo_fonte = p_Codigo.Text;
                codigo_tam   = codigo_fonte.Length;
                fonte_Nome   = p_Codigo.Font.ToString();
                fonte_Cor    = Color.Purple;
                fonte_Estilo = FontStyle.Regular;
                fonte_Altura = 10;

                // Selecionando cada variável:
                // Primeiro procura o símbolo "$" (cifrão)
                while (( aspas_abre_quant < 9999 ) &&
                       ( indice_aspas_abre < codigo_tam ) && 
                      (( indice_aspas_abre = this.Encontra(codigo_fonte, referencia_aspas_abre, aspas_simples)) != -1) ) 
                {
                    aspas_abre_quant += 1;
                    // E procura próximo símbolo "'" (aspas simples), desconsiderando "\'" (quando fizer parte da string):
                    encontrou = false;
                    terminou = false;
                    referencia_aspas_fecha = indice_aspas_abre+1;
                    aspas_fecha_quant = 0;
                    while ( ( aspas_fecha_quant < 9999 ) &&
                            ( referencia_aspas_fecha < codigo_tam ) &&
                            ( ! encontrou ) &&
                            ( ! terminou ))
                    {
                        aspas_fecha_quant += 1;
                        indice_aspas_fecha = this.Encontra( codigo_fonte, 
                                                            referencia_aspas_fecha, 
                                                            aspas_simples );
                        if( indice_aspas_fecha > -1 )
                        {
                            letra_anterior = codigo_fonte[(indice_aspas_fecha-1)].ToString();
                            if ( letra_anterior == "\\" ) //letra_anterior.CompareTo("\\") != 0 )
                            {
                                referencia_aspas_fecha = indice_aspas_fecha+1;
                            } 
                            else
                            {
                                encontrou = true;
                            }
                        }
                        else
                        {
                            terminou = true;
                        }

                    }

                    if ( indice_aspas_fecha > -1 )
                    {
                        palavra_Tam  = (indice_aspas_fecha-indice_aspas_abre)+1; // +1 pra incluir a aspas fechando
                        palavra = codigo_fonte.Substring( indice_aspas_abre, palavra_Tam );
                        
                        String_Simples += this.Ativar( p_Codigo, 
                                                       palavra, 
                                                       palavra_Tam, 
                                                       fonte_Nome, 
                                                       fonte_Cor, 
                                                       fonte_Estilo, 
                                                       fonte_Altura );

                        referencia_aspas_abre = indice_aspas_fecha+1; // +1 pra pular a aspas fechando
                    }
                    else
                    {
                        referencia_aspas_abre = indice_aspas_abre+1;
                    }
                }

                if( aspas_abre_quant == 9999 )
                {
                    MessageBox.Show( "if( aspas_abre_quant == 9999 )", 
                                     "Destacar::String_Simples",
                                     MessageBoxButtons.OKCancel, 
                                     MessageBoxIcon.Asterisk);
                }

            // Fim:
            return String_Simples;
        }
        
        // ========================================================================
        public int String_Dupla( RichTextBox p_Codigo = null )
        {
            // Variáveis:
                int       String_Dupla           = 0;

                string    codigo_fonte           = "";
                int       codigo_tam             = 0;
                string    palavra                = "";
                int       palavra_Tam            = 0;
                string    fonte_Nome             = "";
                Color     fonte_Cor              = Color.Blue;
                FontStyle fonte_Estilo           = FontStyle.Bold;
                int       fonte_Altura           = 0;
                string    aspas_dupla            = "\"";
                string    letra_anterior         = "";
                int       aspas_abre_quant       = 0;
                int       indice_aspas_abre      = -1;
                int       referencia_aspas_abre  = 0;
                int       aspas_fecha_quant      = 0;
                int       indice_aspas_fecha     = -1;
                int       referencia_aspas_fecha = 0;
                bool      encontrou              = false;
                bool      terminou               = false;

            // Programa:
                codigo_fonte = p_Codigo.Text;
                codigo_tam   = codigo_fonte.Length;
                fonte_Nome   = p_Codigo.Font.ToString();
                fonte_Cor    = Color.Salmon;
                fonte_Estilo = FontStyle.Regular;
                fonte_Altura = 10;

                // Selecionando cada variável:
                // Primeiro procura o símbolo "$" (cifrão)
                while (( aspas_abre_quant < 9999 ) &&
                       ( indice_aspas_abre < codigo_tam ) && 
                      (( indice_aspas_abre = this.Encontra(codigo_fonte, referencia_aspas_abre, aspas_dupla)) != -1) ) 
                {
                    aspas_abre_quant += 1;
                    // E procura próximo símbolo '"' (aspas duplas), desconsiderando '\"' (quando fizer parte da string):
                    encontrou = false;
                    terminou = false;
                    referencia_aspas_fecha = indice_aspas_abre+1;
                    aspas_fecha_quant = 0;
                    while ( ( aspas_fecha_quant < 9999 ) &&
                            ( referencia_aspas_fecha < codigo_tam ) &&
                            ( ! encontrou ) &&
                            ( ! terminou ))
                    {
                        aspas_fecha_quant += 1;
                        indice_aspas_fecha = this.Encontra( codigo_fonte, 
                                                            referencia_aspas_fecha, 
                                                            aspas_dupla );
                        if( indice_aspas_fecha > -1 )
                        {
                            letra_anterior = codigo_fonte[(indice_aspas_fecha-1)].ToString();
                            if ( letra_anterior == "\\" ) //letra_anterior.CompareTo("\\") != 0 )
                            {
                                referencia_aspas_fecha = indice_aspas_fecha+1;
                            } 
                            else
                            {
                                encontrou = true;
                            }
                        }
                        else
                        {
                            terminou = true;
                        }

                    }

                    if ( indice_aspas_fecha > -1 )
                    {
                        palavra_Tam  = (indice_aspas_fecha-indice_aspas_abre)+1; // +1 pra incluir a aspas fechando
                        palavra = codigo_fonte.Substring( indice_aspas_abre, palavra_Tam );
                        
                        String_Dupla += this.Ativar( p_Codigo, 
                                                       palavra, 
                                                       palavra_Tam, 
                                                       fonte_Nome, 
                                                       fonte_Cor, 
                                                       fonte_Estilo, 
                                                       fonte_Altura );

                        referencia_aspas_abre = indice_aspas_fecha+1; // +1 pra pular a aspas fechando
                    }
                    else
                    {
                        referencia_aspas_abre = indice_aspas_abre+1;
                    }
                }

                if( aspas_abre_quant == 9999 )
                {
                    MessageBox.Show( "if( aspas_abre_quant == 9999 )", 
                                     "Destacar::String_Dupla",
                                     MessageBoxButtons.OKCancel, 
                                     MessageBoxIcon.Asterisk);
                }

            // Fim:
            return String_Dupla;
        }

    }
}
