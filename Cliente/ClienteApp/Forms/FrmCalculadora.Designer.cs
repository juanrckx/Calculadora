namespace ClienteApp.Forms
{
    partial class FrmCalculadora
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Calculadora Distribuida";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            
            // Crear controles
            CrearControles();
            
            this.ResumeLayout(false);
        }

        private void CrearControles()
        {
            // Panel superior
            var panelSuperior = new System.Windows.Forms.Panel();
            panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            panelSuperior.Height = 100;
            panelSuperior.BackColor = System.Drawing.Color.LightGray;
            
            // Etiqueta título
            var lblTitulo = new System.Windows.Forms.Label();
            lblTitulo.Text = "Calculadora Distribuida";
            lblTitulo.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 10);
            lblTitulo.Size = new System.Drawing.Size(300, 30);
            
            // Estado de conexión
            lblEstado = new System.Windows.Forms.Label();
            lblEstado.Text = "Desconectado";
            lblEstado.Font = new System.Drawing.Font("Arial", 10);
            lblEstado.Location = new System.Drawing.Point(20, 50);
            lblEstado.Size = new System.Drawing.Size(200, 20);
            lblEstado.ForeColor = System.Drawing.Color.Red;
            
            // Botón conectar
            btnConectar = new System.Windows.Forms.Button();
            btnConectar.Text = "Conectar al Servidor";
            btnConectar.Location = new System.Drawing.Point(250, 45);
            btnConectar.Size = new System.Drawing.Size(150, 30);
            btnConectar.Click += new System.EventHandler(btnConectar_Click);
            
            panelSuperior.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitulo, lblEstado, btnConectar });
            
            // Panel de entrada
            var panelEntrada = new System.Windows.Forms.Panel();
            panelEntrada.Dock = System.Windows.Forms.DockStyle.Top;
            panelEntrada.Height = 100;
            panelEntrada.Top = 100;
            
            // Expresión
            var lblExpresion = new System.Windows.Forms.Label();
            lblExpresion.Text = "Expresión:";
            lblExpresion.Location = new System.Drawing.Point(20, 10);
            lblExpresion.Size = new System.Drawing.Size(70, 25);
            
            txtExpresion = new System.Windows.Forms.TextBox();
            txtExpresion.Location = new System.Drawing.Point(100, 10);
            txtExpresion.Size = new System.Drawing.Size(500, 25);
            txtExpresion.Font = new System.Drawing.Font("Consolas", 12);
            
            // Resultado
            var lblResultado = new System.Windows.Forms.Label();
            lblResultado.Text = "Resultado:";
            lblResultado.Location = new System.Drawing.Point(20, 50);
            lblResultado.Size = new System.Drawing.Size(70, 25);
            
            txtResultado = new System.Windows.Forms.TextBox();
            txtResultado.Location = new System.Drawing.Point(100, 50);
            txtResultado.Size = new System.Drawing.Size(300, 25);
            txtResultado.Font = new System.Drawing.Font("Consolas", 12);
            txtResultado.ReadOnly = true;
            
            // Botón evaluar
            btnEvaluar = new System.Windows.Forms.Button();
            btnEvaluar.Text = "Evaluar";
            btnEvaluar.Location = new System.Drawing.Point(420, 50);
            btnEvaluar.Size = new System.Drawing.Size(80, 25);
            btnEvaluar.Enabled = false;
            btnEvaluar.Click += new System.EventHandler(btnEvaluar_Click);
            
            // Botón historial
            btnHistorial = new System.Windows.Forms.Button();
            btnHistorial.Text = "Historial";
            btnHistorial.Location = new System.Drawing.Point(510, 50);
            btnHistorial.Size = new System.Drawing.Size(90, 25);
            btnHistorial.Enabled = false;
            btnHistorial.Click += new System.EventHandler(btnHistorial_Click);
            
            panelEntrada.Controls.AddRange(new System.Windows.Forms.Control[] { 
                lblExpresion, txtExpresion, 
                lblResultado, txtResultado, 
                btnEvaluar, btnHistorial 
            });
            
            // Panel de botones
            var panelBotones = new System.Windows.Forms.Panel();
            panelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBotones.Top = 200;
            
            // Crear botones numéricos
            int startX = 50;
            int startY = 20;
            int buttonSize = 50;
            int spacing = 10;
            
            // Fila 1: 7, 8, 9, +, -
            btnNum7 = CrearBoton("7", startX, startY, buttonSize);
            btnNum8 = CrearBoton("8", startX + buttonSize + spacing, startY, buttonSize);
            btnNum9 = CrearBoton("9", startX + 2*(buttonSize + spacing), startY, buttonSize);
            btnSuma = CrearBoton("+", startX + 3*(buttonSize + spacing), startY, buttonSize);
            btnResta = CrearBoton("-", startX + 4*(buttonSize + spacing), startY, buttonSize);
            
            // Fila 2: 4, 5, 6, *, /
            btnNum4 = CrearBoton("4", startX, startY + buttonSize + spacing, buttonSize);
            btnNum5 = CrearBoton("5", startX + buttonSize + spacing, startY + buttonSize + spacing, buttonSize);
            btnNum6 = CrearBoton("6", startX + 2*(buttonSize + spacing), startY + buttonSize + spacing, buttonSize);
            btnMulti = CrearBoton("*", startX + 3*(buttonSize + spacing), startY + buttonSize + spacing, buttonSize);
            btnDiv = CrearBoton("/", startX + 4*(buttonSize + spacing), startY + buttonSize + spacing, buttonSize);
            
            // Fila 3: 1, 2, 3, %, **
            btnNum1 = CrearBoton("1", startX, startY + 2*(buttonSize + spacing), buttonSize);
            btnNum2 = CrearBoton("2", startX + buttonSize + spacing, startY + 2*(buttonSize + spacing), buttonSize);
            btnNum3 = CrearBoton("3", startX + 2*(buttonSize + spacing), startY + 2*(buttonSize + spacing), buttonSize);
            btnMod = CrearBoton("%", startX + 3*(buttonSize + spacing), startY + 2*(buttonSize + spacing), buttonSize);
            btnPotencia = CrearBoton("**", startX + 4*(buttonSize + spacing), startY + 2*(buttonSize + spacing), buttonSize);
            
            // Fila 4: 0, ., (, ), =
            btnNum0 = CrearBoton("0", startX, startY + 3*(buttonSize + spacing), buttonSize);
            btnPunto = CrearBoton(".", startX + buttonSize + spacing, startY + 3*(buttonSize + spacing), buttonSize);
            btnParentesisIzq = CrearBoton("(", startX + 2*(buttonSize + spacing), startY + 3*(buttonSize + spacing), buttonSize);
            btnParentesisDer = CrearBoton(")", startX + 3*(buttonSize + spacing), startY + 3*(buttonSize + spacing), buttonSize);
            
            // Botón Limpiar (C)
            btnLimpiar = CrearBoton("C", startX + 4*(buttonSize + spacing), startY + 3*(buttonSize + spacing), buttonSize);
            btnLimpiar.BackColor = System.Drawing.Color.LightCoral;
            
            // Fila 5: Operadores lógicos
            int logicalY = startY + 4*(buttonSize + spacing);
            btnAnd = CrearBoton("&", startX, logicalY, buttonSize);
            btnOr = CrearBoton("|", startX + buttonSize + spacing, logicalY, buttonSize);
            btnXor = CrearBoton("^", startX + 2*(buttonSize + spacing), logicalY, buttonSize);
            btnNot = CrearBoton("~", startX + 3*(buttonSize + spacing), logicalY, buttonSize);
            btnBorrar = CrearBoton("←", startX + 4*(buttonSize + spacing), logicalY, buttonSize);
            btnBorrar.BackColor = System.Drawing.Color.LightBlue;
            
            // Agregar controles al panel
            panelBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnNum0, btnNum1, btnNum2, btnNum3, btnNum4, btnNum5, btnNum6, btnNum7, btnNum8, btnNum9,
                btnSuma, btnResta, btnMulti, btnDiv, btnMod, btnPotencia,
                btnAnd, btnOr, btnXor, btnNot,
                btnParentesisIzq, btnParentesisDer, btnPunto,
                btnLimpiar, btnBorrar
            });
            
            this.Controls.Add(panelBotones);
            this.Controls.Add(panelEntrada);
            this.Controls.Add(panelSuperior);
        }

        private System.Windows.Forms.Button CrearBoton(string texto, int x, int y, int size)
        {
            var btn = new System.Windows.Forms.Button();
            btn.Text = texto;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(size, 40);
            btn.Font = new System.Drawing.Font("Arial", 10);
            return btn;
        }
    }
}