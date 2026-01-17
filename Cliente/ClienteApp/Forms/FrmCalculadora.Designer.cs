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
            this.SuspendLayout();

            // Configuración del formulario
            this.Text = "Calculadora Distribuida";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Crear controles
            CrearControles();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CrearControles()
        {
            // Panel superior
            var panelSuperior = new Panel();
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Height = 100;
            
            // Etiqueta título
            var lblTitulo = new Label();
            lblTitulo.Text = "Calculadora Distribuida";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Size = new Size(300, 30);
            
            // Estado de conexión
            lblEstado = new Label();
            lblEstado.Text = "Desconectado";
            lblEstado.Font = new Font("Arial", 10);
            lblEstado.Location = new Point(20, 50);
            lblEstado.Size = new Size(200, 20);
            lblEstado.ForeColor = Color.Red;
            
            // Botón conectar
            btnConectar = new Button();
            btnConectar.Text = "Conectar al Servidor";
            btnConectar.Location = new Point(250, 45);
            btnConectar.Size = new Size(150, 30);
            btnConectar.Click += btnConectar_Click;
            
            panelSuperior.Controls.AddRange(new Control[] { lblTitulo, lblEstado, btnConectar });
            
            // Panel de entrada
            var panelEntrada = new Panel();
            panelEntrada.Dock = DockStyle.Top;
            panelEntrada.Height = 80;
            
            // Expresión
            var lblExpresion = new Label();
            lblExpresion.Text = "Expresión:";
            lblExpresion.Location = new Point(20, 10);
            
            txtExpresion = new TextBox();
            txtExpresion.Location = new Point(100, 10);
            txtExpresion.Size = new Size(500, 25);
            txtExpresion.Font = new Font("Consolas", 12);
            
            // Resultado
            var lblResultado = new Label();
            lblResultado.Text = "Resultado:";
            lblResultado.Location = new Point(20, 45);
            
            txtResultado = new TextBox();
            txtResultado.Location = new Point(100, 45);
            txtResultado.Size = new Size(300, 25);
            txtResultado.Font = new Font("Consolas", 12);
            txtResultado.ReadOnly = true;
            
            // Botón evaluar
            btnEvaluar = new Button();
            btnEvaluar.Text = "Evaluar";
            btnEvaluar.Location = new Point(420, 45);
            btnEvaluar.Size = new Size(80, 25);
            btnEvaluar.Enabled = false;
            btnEvaluar.Click += btnEvaluar_Click;
            
            // Botón historial
            btnHistorial = new Button();
            btnHistorial.Text = "Historial";
            btnHistorial.Location = new Point(510, 45);
            btnHistorial.Size = new Size(90, 25);
            btnHistorial.Enabled = false;
            btnHistorial.Click += btnHistorial_Click;
            
            panelEntrada.Controls.AddRange(new Control[] { 
                lblExpresion, txtExpresion, 
                lblResultado, txtResultado, 
                btnEvaluar, btnHistorial 
            });
            
            // Panel de botones numéricos
            var panelBotones = new Panel();
            panelBotones.Dock = DockStyle.Fill;
            
            // Crear botones numéricos (aquí solo algunos como ejemplo)
            btnNum0 = CrearBoton("0", 100, 150);
            btnNum1 = CrearBoton("1", 50, 100);
            btnNum1 = CrearBoton("2", 50, 100);
            btnNum1 = CrearBoton("3", 50, 100);
            btnNum1 = CrearBoton("4", 50, 100);
            btnNum1 = CrearBoton("5", 50, 100);
            btnNum1 = CrearBoton("6", 50, 100);
            btnNum1 = CrearBoton("7", 50, 100);
            btnNum1 = CrearBoton("8", 50, 100);
            btnNum1 = CrearBoton("9", 50, 100);

            
            this.Controls.Add(panelBotones);
            this.Controls.Add(panelEntrada);
            this.Controls.Add(panelSuperior);
        }

        private Button CrearBoton(string texto, int x, int y)
        {
            var btn = new Button();
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(50, 40);
            return btn;
        }
        
    }
}