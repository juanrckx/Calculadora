using System;
using System.Reflection;
using System.Windows.Forms;
using ClienteApp.Services;
using Comun.Models;

namespace ClienteApp.Forms
{
    public partial class FrmCalculadora : Form
    {
        private ClienteTCP _cliente;
        private string _servidorIp = "127.0.0.1";
        private int _puerto = 8080;

        public FrmCalculadora()
        {
            InitializeComponent();
            InicializarCliente();
            ConfigurarBotones();
            ConfigurarEstadoInicial();
        }

        private void InicializarCliente()
        {
            _cliente = new ClienteTCP();
            _cliente.OnConexionEstablecida += ConexionEstablecida;
            _cliente.OnResultadoRecibido += ResultadoRecibido;
            _cliente.OnError += ErrorRecibido;
            _cliente.OnHistorialRecibido += HistorialRecibido;
        }

        private void ConfigurarEstadoInicial()
        {
            lblEstado.Text = "Desconectado";
            btnEvaluar.Enabled = false;
            btnHistorial.Enabled = false;
        }

        private async void btnConectar_Click(object sender, EventArgs e)
        {
            btnConectar.Enabled = false;
            lblEstado.Text = "Conectando...";

            if (await _cliente.Conectar(_servidorIp, _puerto))
            {
                lblEstado.Text = "¡Conectado!";
                btnEvaluar.Enabled = true;
                btnHistorial.Enabled = true;
            }
            else
            {
                lblEstado.Text = "Desconectado";
                btnConectar.Enabled = true;
            }
        }

        private async void btnEvaluar_Click(object sender, EventArgs e)
        {
            string expresion = txtExpresion.Text.Trim();

            if (string.IsNullOrEmpty(expresion))
            {
                MessageBox.Show("Ingrese una expresión", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            txtResultado.Text = "Calculando...";
            await _cliente.EnviarExpresion(expresion);
        }

        private async void btnHistorial_Click(object sender, EventArgs e)
        {
            await _cliente.SolicitarHistorial();
        }

        private void ConexionEstablecida(string mensaje)
        {
            this.Invoke((Action)delegate
            {
                MessageBox.Show(mensaje, "Conexión", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void ResultadoRecibido(string resultado)
        {
            this.Invoke((Action)delegate
            {
                txtResultado.Text = resultado;
            });
        }

        private void ErrorRecibido(string error)
        {
            this.Invoke((Action)delegate
            {
                MessageBox.Show(error, "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtResultado.Text = "Error";
            });
        }

        private void HistorialRecibido(List<HistorialItem> historial)
        {
            this.Invoke((Action)delegate {
                var frmHistorial = new FrmHistorial(historial);
                frmHistorial.ShowDialog();
            });
        }

        private void ConfigurarBotones()
        {
            // Botones numéricos
            btnNum0.Click += (s, e) => txtExpresion.Text += "0";
            btnNum1.Click += (s, e) => txtExpresion.Text += "1";
            btnNum2.Click += (s, e) => txtExpresion.Text += "2";
            btnNum3.Click += (s, e) => txtExpresion.Text += "3";
            btnNum4.Click += (s, e) => txtExpresion.Text += "4";
            btnNum5.Click += (s, e) => txtExpresion.Text += "5";
            btnNum6.Click += (s, e) => txtExpresion.Text += "6";
            btnNum7.Click += (s, e) => txtExpresion.Text += "7";
            btnNum8.Click += (s, e) => txtExpresion.Text += "8";
            btnNum9.Click += (s, e) => txtExpresion.Text += "9";

            
            // Botones de operadores
            btnSuma.Click += (s, e) => txtExpresion.Text += " + ";
            btnResta.Click += (s, e) => txtExpresion.Text += " - ";
            btnMulti.Click += (s, e) => txtExpresion.Text += " * ";
            btnDiv.Click += (s, e) => txtExpresion.Text += " / ";
            btnMod.Click += (s, e) => txtExpresion.Text += " % ";
            btnPotencia.Click += (s, e) => txtExpresion.Text += "**";
            btnAnd.Click += (s, e) => txtExpresion.Text += " && ";
            btnOr.Click += (s, e) => txtExpresion.Text += " | ";
            btnXor.Click += (s, e) => txtExpresion.Text += " ^ ";
            btnNot.Click += (s, e) => txtExpresion.Text += "~";
            
            // Paréntesis
            btnParentesisIzq.Click += (s, e) => txtExpresion.Text += "(";
            btnParentesisDer.Click += (s, e) => txtExpresion.Text += ")";

            // Punto decimal
            btonPunto.Click += (s, e) => txtExpresion.Text += ".";
            
            // Limpiar
            btnLimpiar.Click += (s, e) => txtExpresion.Clear();
            btnBorrar.Click += (s, e) => {
                if (txtExpresion.Text.Length > 0)
                    txtExpresion.Text = txtExpresion.Text.Substring(0, txtExpresion.Text.Length - 1);
            };
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cliente.Desconectar();
            base.OnFormClosing(e);
        }
    }
}