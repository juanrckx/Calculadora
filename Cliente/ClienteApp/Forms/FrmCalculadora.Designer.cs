namespace ClienteApp.Forms
{
    partial class FrmCalculadora
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
            this.txtExpresion = new System.Windows.Forms.TextBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnEvaluar = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnNum0 = new System.Windows.Forms.Button();
            this.btnNum1 = new System.Windows.Forms.Button();
            this.btnNum2 = new System.Windows.Forms.Button();
            this.btnNum3 = new System.Windows.Forms.Button();
            this.btnNum4 = new System.Windows.Forms.Button();
            this.btnNum5 = new System.Windows.Forms.Button();
            this.btnNum6 = new System.Windows.Forms.Button();
            this.btnNum7 = new System.Windows.Forms.Button();
            this.btnNum8 = new System.Windows.Forms.Button();
            this.btnNum9 = new System.Windows.Forms.Button();
            this.btnSuma = new System.Windows.Forms.Button();
            this.btnResta = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnPotencia = new System.Windows.Forms.Button();
            this.btnAnd = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnXor = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnParentesisIzq = new System.Windows.Forms.Button();
            this.btnParentesisDer = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnPunto = new System.Windows.Forms.Button();
            this.btnNegativo = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblExpresion = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panelEntrada = new System.Windows.Forms.Panel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.panelSuperior.SuspendLayout();
            this.panelEntrada.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExpresion
            // 
            this.txtExpresion.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtExpresion.Location = new System.Drawing.Point(100, 10);
            this.txtExpresion.Name = "txtExpresion";
            this.txtExpresion.Size = new System.Drawing.Size(500, 26);
            this.txtExpresion.TabIndex = 0;
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtResultado.Location = new System.Drawing.Point(100, 50);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(300, 26);
            this.txtResultado.TabIndex = 1;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(250, 45);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(150, 30);
            this.btnConectar.TabIndex = 2;
            this.btnConectar.Text = "Conectar al Servidor";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnEvaluar
            // 
            this.btnEvaluar.Enabled = false;
            this.btnEvaluar.Location = new System.Drawing.Point(420, 50);
            this.btnEvaluar.Name = "btnEvaluar";
            this.btnEvaluar.Size = new System.Drawing.Size(80, 25);
            this.btnEvaluar.TabIndex = 3;
            this.btnEvaluar.Text = "Evaluar";
            this.btnEvaluar.UseVisualStyleBackColor = true;
            this.btnEvaluar.Click += new System.EventHandler(this.btnEvaluar_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Enabled = false;
            this.btnHistorial.Location = new System.Drawing.Point(510, 50);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(90, 25);
            this.btnHistorial.TabIndex = 4;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEstado.ForeColor = System.Drawing.Color.Red;
            this.lblEstado.Location = new System.Drawing.Point(20, 50);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(200, 20);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Desconectado";
            // 
            // btnNum0
            // 
            this.btnNum0.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum0.Location = new System.Drawing.Point(50, 140);
            this.btnNum0.Name = "btnNum0";
            this.btnNum0.Size = new System.Drawing.Size(50, 40);
            this.btnNum0.TabIndex = 6;
            this.btnNum0.Text = "0";
            this.btnNum0.UseVisualStyleBackColor = true;
            // 
            // btnNum1
            // 
            this.btnNum1.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum1.Location = new System.Drawing.Point(50, 100);
            this.btnNum1.Name = "btnNum1";
            this.btnNum1.Size = new System.Drawing.Size(50, 40);
            this.btnNum1.TabIndex = 7;
            this.btnNum1.Text = "1";
            this.btnNum1.UseVisualStyleBackColor = true;
            // 
            // btnNum2
            // 
            this.btnNum2.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum2.Location = new System.Drawing.Point(110, 100);
            this.btnNum2.Name = "btnNum2";
            this.btnNum2.Size = new System.Drawing.Size(50, 40);
            this.btnNum2.TabIndex = 8;
            this.btnNum2.Text = "2";
            this.btnNum2.UseVisualStyleBackColor = true;
            // 
            // btnNum3
            // 
            this.btnNum3.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum3.Location = new System.Drawing.Point(170, 100);
            this.btnNum3.Name = "btnNum3";
            this.btnNum3.Size = new System.Drawing.Size(50, 40);
            this.btnNum3.TabIndex = 9;
            this.btnNum3.Text = "3";
            this.btnNum3.UseVisualStyleBackColor = true;
            // 
            // btnNum4
            // 
            this.btnNum4.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum4.Location = new System.Drawing.Point(50, 60);
            this.btnNum4.Name = "btnNum4";
            this.btnNum4.Size = new System.Drawing.Size(50, 40);
            this.btnNum4.TabIndex = 10;
            this.btnNum4.Text = "4";
            this.btnNum4.UseVisualStyleBackColor = true;
            // 
            // btnNum5
            // 
            this.btnNum5.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum5.Location = new System.Drawing.Point(110, 60);
            this.btnNum5.Name = "btnNum5";
            this.btnNum5.Size = new System.Drawing.Size(50, 40);
            this.btnNum5.TabIndex = 11;
            this.btnNum5.Text = "5";
            this.btnNum5.UseVisualStyleBackColor = true;
            // 
            // btnNum6
            // 
            this.btnNum6.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum6.Location = new System.Drawing.Point(170, 60);
            this.btnNum6.Name = "btnNum6";
            this.btnNum6.Size = new System.Drawing.Size(50, 40);
            this.btnNum6.TabIndex = 12;
            this.btnNum6.Text = "6";
            this.btnNum6.UseVisualStyleBackColor = true;
            // 
            // btnNum7
            // 
            this.btnNum7.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum7.Location = new System.Drawing.Point(50, 20);
            this.btnNum7.Name = "btnNum7";
            this.btnNum7.Size = new System.Drawing.Size(50, 40);
            this.btnNum7.TabIndex = 13;
            this.btnNum7.Text = "7";
            this.btnNum7.UseVisualStyleBackColor = true;
            // 
            // btnNum8
            // 
            this.btnNum8.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum8.Location = new System.Drawing.Point(110, 20);
            this.btnNum8.Name = "btnNum8";
            this.btnNum8.Size = new System.Drawing.Size(50, 40);
            this.btnNum8.TabIndex = 14;
            this.btnNum8.Text = "8";
            this.btnNum8.UseVisualStyleBackColor = true;
            // 
            // btnNum9
            // 
            this.btnNum9.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNum9.Location = new System.Drawing.Point(170, 20);
            this.btnNum9.Name = "btnNum9";
            this.btnNum9.Size = new System.Drawing.Size(50, 40);
            this.btnNum9.TabIndex = 15;
            this.btnNum9.Text = "9";
            this.btnNum9.UseVisualStyleBackColor = true;
            // 
            // btnSuma
            // 
            this.btnSuma.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSuma.Location = new System.Drawing.Point(230, 20);
            this.btnSuma.Name = "btnSuma";
            this.btnSuma.Size = new System.Drawing.Size(50, 40);
            this.btnSuma.TabIndex = 16;
            this.btnSuma.Text = "+";
            this.btnSuma.UseVisualStyleBackColor = true;
            // 
            // btnResta
            // 
            this.btnResta.Font = new System.Drawing.Font("Arial", 10F);
            this.btnResta.Location = new System.Drawing.Point(290, 20);
            this.btnResta.Name = "btnResta";
            this.btnResta.Size = new System.Drawing.Size(50, 40);
            this.btnResta.TabIndex = 17;
            this.btnResta.Text = "-";
            this.btnResta.UseVisualStyleBackColor = true;
            // 
            // btnMulti
            // 
            this.btnMulti.Font = new System.Drawing.Font("Arial", 10F);
            this.btnMulti.Location = new System.Drawing.Point(230, 60);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(50, 40);
            this.btnMulti.TabIndex = 18;
            this.btnMulti.Text = "*";
            this.btnMulti.UseVisualStyleBackColor = true;
            // 
            // btnDiv
            // 
            this.btnDiv.Font = new System.Drawing.Font("Arial", 10F);
            this.btnDiv.Location = new System.Drawing.Point(290, 60);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(50, 40);
            this.btnDiv.TabIndex = 19;
            this.btnDiv.Text = "/";
            this.btnDiv.UseVisualStyleBackColor = true;
            // 
            // btnMod
            // 
            this.btnMod.Font = new System.Drawing.Font("Arial", 10F);
            this.btnMod.Location = new System.Drawing.Point(230, 100);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(50, 40);
            this.btnMod.TabIndex = 20;
            this.btnMod.Text = "%";
            this.btnMod.UseVisualStyleBackColor = true;
            // 
            // btnPotencia
            // 
            this.btnPotencia.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPotencia.Location = new System.Drawing.Point(290, 100);
            this.btnPotencia.Name = "btnPotencia";
            this.btnPotencia.Size = new System.Drawing.Size(50, 40);
            this.btnPotencia.TabIndex = 21;
            this.btnPotencia.Text = "**";
            this.btnPotencia.UseVisualStyleBackColor = true;
            // 
            // btnAnd
            // 
            this.btnAnd.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAnd.Location = new System.Drawing.Point(50, 190);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(50, 40);
            this.btnAnd.TabIndex = 22;
            this.btnAnd.Text = "&&";
            this.btnAnd.UseVisualStyleBackColor = true;
            // 
            // btnOr
            // 
            this.btnOr.Font = new System.Drawing.Font("Arial", 10F);
            this.btnOr.Location = new System.Drawing.Point(110, 190);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(50, 40);
            this.btnOr.TabIndex = 23;
            this.btnOr.Text = "|";
            this.btnOr.UseVisualStyleBackColor = true;
            // 
            // btnXor
            // 
            this.btnXor.Font = new System.Drawing.Font("Arial", 10F);
            this.btnXor.Location = new System.Drawing.Point(170, 190);
            this.btnXor.Name = "btnXor";
            this.btnXor.Size = new System.Drawing.Size(50, 40);
            this.btnXor.TabIndex = 24;
            this.btnXor.Text = "^";
            this.btnXor.UseVisualStyleBackColor = true;
            // 
            // btnNot
            // 
            this.btnNot.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNot.Location = new System.Drawing.Point(230, 190);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(50, 40);
            this.btnNot.TabIndex = 25;
            this.btnNot.Text = "~";
            this.btnNot.UseVisualStyleBackColor = true;
            // 
            // btnParentesisIzq
            // 
            this.btnParentesisIzq.Font = new System.Drawing.Font("Arial", 10F);
            this.btnParentesisIzq.Location = new System.Drawing.Point(110, 140);
            this.btnParentesisIzq.Name = "btnParentesisIzq";
            this.btnParentesisIzq.Size = new System.Drawing.Size(50, 40);
            this.btnParentesisIzq.TabIndex = 26;
            this.btnParentesisIzq.Text = "(";
            this.btnParentesisIzq.UseVisualStyleBackColor = true;
            // 
            // btnParentesisDer
            // 
            this.btnParentesisDer.Font = new System.Drawing.Font("Arial", 10F);
            this.btnParentesisDer.Location = new System.Drawing.Point(170, 140);
            this.btnParentesisDer.Name = "btnParentesisDer";
            this.btnParentesisDer.Size = new System.Drawing.Size(50, 40);
            this.btnParentesisDer.TabIndex = 27;
            this.btnParentesisDer.Text = ")";
            this.btnParentesisDer.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnLimpiar.Location = new System.Drawing.Point(290, 190);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(50, 40);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "C";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.LightBlue;
            this.btnBorrar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBorrar.Location = new System.Drawing.Point(350, 20);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(50, 40);
            this.btnBorrar.TabIndex = 29;
            this.btnBorrar.Text = "←";
            this.btnBorrar.UseVisualStyleBackColor = false;
            // 
            // btnPunto
            // 
            this.btnPunto.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPunto.Location = new System.Drawing.Point(230, 140);
            this.btnPunto.Name = "btnPunto";
            this.btnPunto.Size = new System.Drawing.Size(50, 40);
            this.btnPunto.TabIndex = 30;
            this.btnPunto.Text = ".";
            this.btnPunto.UseVisualStyleBackColor = true;
            //
            // btnNegativo
            // 
            this.btnNegativo.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNegativo.Location = new System.Drawing.Point(290, 140);
            this.btnNegativo.Name = "btnNegativo";
            this.btnNegativo.Size = new System.Drawing.Size(50, 40);
            this.btnNegativo.TabIndex = 30;
            this.btnNegativo.Text = "u";
            this.btnNegativo.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 31;
            this.lblTitulo.Text = "Calculadora Distribuida";
            // 
            // lblExpresion
            // 
            this.lblExpresion.Location = new System.Drawing.Point(20, 13);
            this.lblExpresion.Name = "lblExpresion";
            this.lblExpresion.Size = new System.Drawing.Size(70, 25);
            this.lblExpresion.TabIndex = 32;
            this.lblExpresion.Text = "Expresión:";
            // 
            // lblResultado
            // 
            this.lblResultado.Location = new System.Drawing.Point(20, 53);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(70, 25);
            this.lblResultado.TabIndex = 33;
            this.lblResultado.Text = "Resultado:";
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.LightGray;
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Controls.Add(this.lblEstado);
            this.panelSuperior.Controls.Add(this.btnConectar);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(800, 100);
            this.panelSuperior.TabIndex = 34;
            // 
            // panelEntrada
            // 
            this.panelEntrada.Controls.Add(this.lblExpresion);
            this.panelEntrada.Controls.Add(this.txtExpresion);
            this.panelEntrada.Controls.Add(this.lblResultado);
            this.panelEntrada.Controls.Add(this.txtResultado);
            this.panelEntrada.Controls.Add(this.btnEvaluar);
            this.panelEntrada.Controls.Add(this.btnHistorial);
            this.panelEntrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntrada.Location = new System.Drawing.Point(0, 100);
            this.panelEntrada.Name = "panelEntrada";
            this.panelEntrada.Size = new System.Drawing.Size(800, 100);
            this.panelEntrada.TabIndex = 35;
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnNum7);
            this.panelBotones.Controls.Add(this.btnNum8);
            this.panelBotones.Controls.Add(this.btnNum9);
            this.panelBotones.Controls.Add(this.btnSuma);
            this.panelBotones.Controls.Add(this.btnResta);
            this.panelBotones.Controls.Add(this.btnNum4);
            this.panelBotones.Controls.Add(this.btnNum5);
            this.panelBotones.Controls.Add(this.btnNum6);
            this.panelBotones.Controls.Add(this.btnMulti);
            this.panelBotones.Controls.Add(this.btnDiv);
            this.panelBotones.Controls.Add(this.btnNum1);
            this.panelBotones.Controls.Add(this.btnNum2);
            this.panelBotones.Controls.Add(this.btnNum3);
            this.panelBotones.Controls.Add(this.btnMod);
            this.panelBotones.Controls.Add(this.btnPotencia);
            this.panelBotones.Controls.Add(this.btnNum0);
            this.panelBotones.Controls.Add(this.btnPunto);
            this.panelBotones.Controls.Add(this.btnNegativo);
            this.panelBotones.Controls.Add(this.btnParentesisIzq);
            this.panelBotones.Controls.Add(this.btnParentesisDer);
            this.panelBotones.Controls.Add(this.btnLimpiar);
            this.panelBotones.Controls.Add(this.btnAnd);
            this.panelBotones.Controls.Add(this.btnOr);
            this.panelBotones.Controls.Add(this.btnXor);
            this.panelBotones.Controls.Add(this.btnNot);
            this.panelBotones.Controls.Add(this.btnBorrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBotones.Location = new System.Drawing.Point(0, 200);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(800, 400);
            this.panelBotones.TabIndex = 36;
            // 
            // FrmCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelEntrada);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora Distribuida";
            this.panelSuperior.ResumeLayout(false);
            this.panelEntrada.ResumeLayout(false);
            this.panelEntrada.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtExpresion;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnEvaluar;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnNum0;
        private System.Windows.Forms.Button btnNum1;
        private System.Windows.Forms.Button btnNum2;
        private System.Windows.Forms.Button btnNum3;
        private System.Windows.Forms.Button btnNum4;
        private System.Windows.Forms.Button btnNum5;
        private System.Windows.Forms.Button btnNum6;
        private System.Windows.Forms.Button btnNum7;
        private System.Windows.Forms.Button btnNum8;
        private System.Windows.Forms.Button btnNum9;
        private System.Windows.Forms.Button btnSuma;
        private System.Windows.Forms.Button btnResta;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnPotencia;
        private System.Windows.Forms.Button btnAnd;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Button btnXor;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnParentesisIzq;
        private System.Windows.Forms.Button btnParentesisDer;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnPunto;
        private System.Windows.Forms.Button btnNegativo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblExpresion;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelEntrada;
        private System.Windows.Forms.Panel panelBotones;
    }
}