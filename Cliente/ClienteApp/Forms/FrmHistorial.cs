using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Comun.Models;

namespace ClienteApp.Forms
{
    public partial class FrmHistorial : Form
    {
        private List<HistorialItem> _historial;
        
        // Controles
        private DataGridView dgvHistorial;
        private Label lblTotal;
        private Button btnCerrar;
        
        public FrmHistorial(List<HistorialItem> historial)
        {
            InitializeComponent();
            _historial = historial;
            InicializarControles();
            CargarHistorial();
        }
        
        private void InicializarControles()
        {
            this.Text = "Historial de Operaciones";
            this.Size = new System.Drawing.Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            
            // DataGridView
            dgvHistorial = new DataGridView();
            dgvHistorial.Location = new System.Drawing.Point(20, 20);
            dgvHistorial.Size = new System.Drawing.Size(740, 350);
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Columnas
            dgvHistorial.Columns.Add("Fecha", "Fecha y Hora");
            dgvHistorial.Columns.Add("Expresion", "Expresión");
            dgvHistorial.Columns.Add("Resultado", "Resultado");
            
            // Label total
            lblTotal = new Label();
            lblTotal.Location = new System.Drawing.Point(20, 380);
            lblTotal.Size = new System.Drawing.Size(300, 25);
            lblTotal.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            
            // Botón cerrar
            btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new System.Drawing.Point(650, 380);
            btnCerrar.Size = new System.Drawing.Size(110, 30);
            btnCerrar.Click += btnCerrar_Click;
            
            this.Controls.Add(dgvHistorial);
            this.Controls.Add(lblTotal);
            this.Controls.Add(btnCerrar);
        }
        
        private void CargarHistorial()
        {
            dgvHistorial.Rows.Clear();
            
            foreach (var item in _historial)
            {
                dgvHistorial.Rows.Add(item.Fecha, item.Expresion, item.Resultado);
            }
            
            lblTotal.Text = $"Total de operaciones: {_historial.Count}";
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}