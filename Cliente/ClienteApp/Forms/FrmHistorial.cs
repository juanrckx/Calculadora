using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Comun.Models;

namespace ClienteApp.Forms
{
    public partial class FrmHistorial : Form
    {
        private List<HistorialItem> _historial;
        
        public FrmHistorial(List<HistorialItem> historial)
        {
            InitializeComponent();
            _historial = historial;
            CargarHistorial();
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