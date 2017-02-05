namespace Analisador
{
    partial class frm_Aplicativo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Aplicativo));
            this.bto_Alerta = new System.Windows.Forms.Button();
            this.dlg_Arq_Abrir = new System.Windows.Forms.OpenFileDialog();
            this.dlg_Arq_Salvar = new System.Windows.Forms.SaveFileDialog();
            this.Analise = new System.Windows.Forms.TextBox();
            this.bto_Arq_Abrir = new System.Windows.Forms.Button();
            this.Analisador = new System.Windows.Forms.TabControl();
            this.pag_Inicio = new System.Windows.Forms.TabPage();
            this.rtf_Ini_Codigo = new System.Windows.Forms.RichTextBox();
            this.rtf_Ini_Variaveis = new System.Windows.Forms.RichTextBox();
            this.pag_Funcoes = new System.Windows.Forms.TabPage();
            this.tab_Funcoes = new System.Windows.Forms.TabControl();
            this.pag_Outros = new System.Windows.Forms.TabPage();
            this.Analisador.SuspendLayout();
            this.pag_Inicio.SuspendLayout();
            this.pag_Funcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // bto_Alerta
            // 
            this.bto_Alerta.Location = new System.Drawing.Point(310, 12);
            this.bto_Alerta.Name = "bto_Alerta";
            this.bto_Alerta.Size = new System.Drawing.Size(75, 23);
            this.bto_Alerta.TabIndex = 0;
            this.bto_Alerta.Text = "Alerta";
            this.bto_Alerta.UseVisualStyleBackColor = true;
            this.bto_Alerta.Click += new System.EventHandler(this.bto_Alerta_Click);
            // 
            // Analise
            // 
            this.Analise.Location = new System.Drawing.Point(25, 524);
            this.Analise.Multiline = true;
            this.Analise.Name = "Analise";
            this.Analise.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Analise.Size = new System.Drawing.Size(933, 154);
            this.Analise.TabIndex = 2;
            this.Analise.WordWrap = false;
            // 
            // bto_Arq_Abrir
            // 
            this.bto_Arq_Abrir.Image = ((System.Drawing.Image)(resources.GetObject("bto_Arq_Abrir.Image")));
            this.bto_Arq_Abrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bto_Arq_Abrir.Location = new System.Drawing.Point(25, 12);
            this.bto_Arq_Abrir.Name = "bto_Arq_Abrir";
            this.bto_Arq_Abrir.Size = new System.Drawing.Size(75, 23);
            this.bto_Arq_Abrir.TabIndex = 3;
            this.bto_Arq_Abrir.Text = "Abrir";
            this.bto_Arq_Abrir.UseVisualStyleBackColor = true;
            this.bto_Arq_Abrir.Click += new System.EventHandler(this.bto_Arq_Abrir_Click);
            // 
            // Analisador
            // 
            this.Analisador.Controls.Add(this.pag_Inicio);
            this.Analisador.Controls.Add(this.pag_Funcoes);
            this.Analisador.Controls.Add(this.pag_Outros);
            this.Analisador.Location = new System.Drawing.Point(25, 41);
            this.Analisador.Name = "Analisador";
            this.Analisador.SelectedIndex = 0;
            this.Analisador.Size = new System.Drawing.Size(933, 477);
            this.Analisador.TabIndex = 8;
            // 
            // pag_Inicio
            // 
            this.pag_Inicio.Controls.Add(this.rtf_Ini_Codigo);
            this.pag_Inicio.Controls.Add(this.rtf_Ini_Variaveis);
            this.pag_Inicio.Location = new System.Drawing.Point(4, 22);
            this.pag_Inicio.Name = "pag_Inicio";
            this.pag_Inicio.Size = new System.Drawing.Size(925, 451);
            this.pag_Inicio.TabIndex = 2;
            this.pag_Inicio.Text = "Início";
            this.pag_Inicio.UseVisualStyleBackColor = true;
            // 
            // rtf_Ini_Codigo
            // 
            this.rtf_Ini_Codigo.Font = new System.Drawing.Font("monofur", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtf_Ini_Codigo.Location = new System.Drawing.Point(222, 59);
            this.rtf_Ini_Codigo.Name = "rtf_Ini_Codigo";
            this.rtf_Ini_Codigo.Size = new System.Drawing.Size(700, 389);
            this.rtf_Ini_Codigo.TabIndex = 3;
            this.rtf_Ini_Codigo.Text = "";
            this.rtf_Ini_Codigo.WordWrap = false;
            // 
            // rtf_Ini_Variaveis
            // 
            this.rtf_Ini_Variaveis.Font = new System.Drawing.Font("monofur", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtf_Ini_Variaveis.Location = new System.Drawing.Point(3, 59);
            this.rtf_Ini_Variaveis.Name = "rtf_Ini_Variaveis";
            this.rtf_Ini_Variaveis.Size = new System.Drawing.Size(213, 389);
            this.rtf_Ini_Variaveis.TabIndex = 2;
            this.rtf_Ini_Variaveis.Text = "";
            this.rtf_Ini_Variaveis.WordWrap = false;
            // 
            // pag_Funcoes
            // 
            this.pag_Funcoes.Controls.Add(this.tab_Funcoes);
            this.pag_Funcoes.Location = new System.Drawing.Point(4, 22);
            this.pag_Funcoes.Name = "pag_Funcoes";
            this.pag_Funcoes.Padding = new System.Windows.Forms.Padding(3);
            this.pag_Funcoes.Size = new System.Drawing.Size(925, 451);
            this.pag_Funcoes.TabIndex = 0;
            this.pag_Funcoes.Text = "Funções";
            this.pag_Funcoes.UseVisualStyleBackColor = true;
            // 
            // tab_Funcoes
            // 
            this.tab_Funcoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Funcoes.Location = new System.Drawing.Point(3, 3);
            this.tab_Funcoes.Name = "tab_Funcoes";
            this.tab_Funcoes.SelectedIndex = 0;
            this.tab_Funcoes.Size = new System.Drawing.Size(919, 445);
            this.tab_Funcoes.TabIndex = 0;
            // 
            // pag_Outros
            // 
            this.pag_Outros.Location = new System.Drawing.Point(4, 22);
            this.pag_Outros.Name = "pag_Outros";
            this.pag_Outros.Padding = new System.Windows.Forms.Padding(3);
            this.pag_Outros.Size = new System.Drawing.Size(925, 451);
            this.pag_Outros.TabIndex = 1;
            this.pag_Outros.Text = "Outros";
            this.pag_Outros.UseVisualStyleBackColor = true;
            // 
            // frm_Aplicativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 700);
            this.Controls.Add(this.Analisador);
            this.Controls.Add(this.bto_Arq_Abrir);
            this.Controls.Add(this.Analise);
            this.Controls.Add(this.bto_Alerta);
            this.Name = "frm_Aplicativo";
            this.Text = "Aplicativo";
            this.Load += new System.EventHandler(this.frm_Aplicativo_Load);
            this.Analisador.ResumeLayout(false);
            this.pag_Inicio.ResumeLayout(false);
            this.pag_Funcoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bto_Alerta;
        private System.Windows.Forms.OpenFileDialog dlg_Arq_Abrir;
        private System.Windows.Forms.SaveFileDialog dlg_Arq_Salvar;
        private System.Windows.Forms.TextBox Analise;
        private System.Windows.Forms.Button bto_Arq_Abrir;
        private System.Windows.Forms.TabControl Analisador;
        private System.Windows.Forms.TabPage pag_Funcoes;
        private System.Windows.Forms.TabPage pag_Outros;
        private System.Windows.Forms.TabControl tab_Funcoes;
        private System.Windows.Forms.TabPage pag_Inicio;
        private System.Windows.Forms.RichTextBox rtf_Ini_Codigo;
        private System.Windows.Forms.RichTextBox rtf_Ini_Variaveis;
    }
}

