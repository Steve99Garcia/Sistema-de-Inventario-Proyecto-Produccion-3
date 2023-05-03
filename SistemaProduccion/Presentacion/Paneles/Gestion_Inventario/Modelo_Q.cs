using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProduccion.Presentacion.Paneles.Gestion_Inventario
{
    public partial class Modelo_Q : UserControl
    {
        public double demanda, demandadiaria, Cpedir, CMantener, q, Pentrega, rop;
        public int periodo;
        public Modelo_Q()
        {
            InitializeComponent();
            this.DeshabilitarTexto();
            comboPeriodo.SelectedIndex = 0;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
              graficoQ.Series["Inventario"].Points.Clear();
              graficoQ.Series["rop"].Points.Clear();

            periodo = comboPeriodo.SelectedIndex;
            try
            {
                

                switch (periodo)
                {
                    case 0:
                        demanda = double.Parse(txtDemanda.Text) * 365;
                        demandadiaria = double.Parse(txtDemanda.Text);
                        break;

                    case 1:
                        demanda = double.Parse(txtDemanda.Text)*30;
                        demandadiaria = (double.Parse(txtDemanda.Text)) / 30;
                        break;

                    case 2:
                        demanda = double.Parse(txtDemanda.Text);                      
                        demandadiaria = (double.Parse(txtDemanda.Text)) / 365;
                        break;

                    default:
                        break;
                }

                Cpedir = double.Parse(txtCosto_pedir.Text);
                CMantener = double.Parse(txtCosto_de_mantenimiento.Text);
                Pentrega = double.Parse(txtPlazo_de_entrega.Text);

            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error en los campos", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }

            q = Math.Sqrt((2 * demanda * Cpedir) / (CMantener));
            this.labelQoptimo.Text = Math.Round(q, 4).ToString();

            rop = demandadiaria * Pentrega;
            this.labelResultadoROP.Text = Math.Round(rop, 4).ToString();

            double distancia = q/demanda;

            for (int i = 1; i < 4; i++)
            {
                graficoQ.Series["Inventario"].Points.AddXY(i, q);

                graficoQ.Series["Inventario"].Points.AddXY(i+1, 0);

                graficoQ.Series["rop"].Points.AddXY(i, rop);

                graficoQ.Series["rop"].Points.AddXY(i + 1, rop);
            }

        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.HabilitarTexto();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DeshabilitarTexto();
        }

        private void HabilitarTexto()
        {
            this.txtDemanda.Enabled = true;
            this.txtCosto_pedir.Enabled = true;
            this.txtCosto_de_mantenimiento.Enabled = true;
            this.txtPlazo_de_entrega.Enabled = true;
            this.comboPeriodo.Enabled = true;
            this.btnCalcular.Enabled = true;
            this.btnLimpiarCampos.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnAgregar.Enabled = false;
        }

        private void DeshabilitarTexto()
        {
            this.txtDemanda.Enabled = false;
            this.txtCosto_pedir.Enabled = false;
            this.txtCosto_de_mantenimiento.Enabled = false;
            this.txtPlazo_de_entrega.Enabled = false;
            this.comboPeriodo.Enabled = false;
            this.btnCalcular.Enabled = false;
            this.btnLimpiarCampos.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnAgregar.Enabled = true;
            this.limpiarCampos();
            
        }

        private void limpiarCampos()
        {
            this.txtDemanda.Text = string.Empty;
            this.txtCosto_pedir.Text = string.Empty;
            this.txtCosto_de_mantenimiento.Text = string.Empty;
            this.txtPlazo_de_entrega.Text = string.Empty;
            this.comboPeriodo.SelectedIndex = 0;
            this.labelQoptimo.Text = "0,00";
            this.labelResultadoROP.Text = "0,00";
            this.graficoQ.Series["Inventario"].Points.Clear();
            this.graficoQ.Series["rop"].Points.Clear();
        }

        private void txtDemanda_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
