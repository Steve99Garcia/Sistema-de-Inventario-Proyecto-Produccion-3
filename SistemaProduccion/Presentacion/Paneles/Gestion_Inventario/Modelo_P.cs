using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProduccion.Presentacion.Paneles.Gestion_Inventario
{
    public partial class Modelo_P : UserControl
    {
        public Modelo_P()
        {
            InitializeComponent();
            this.DeshabilitarTexto();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double demanda, dias, probabilidad, pEntrega, sigma, inventario, pRevision, demandadiaria = 0, x, resultado, z;

            try
            {

                demanda = double.Parse(txtDemanda.Text);
                dias = double.Parse(txtDiasLaborales.Text);
                probabilidad = double.Parse(txtProbabilidad.Text);
                pEntrega = double.Parse(txtPlazo_de_entrega.Text);
                sigma = double.Parse(txtDesviacion.Text);
                inventario = double.Parse(txtInventarioExistente.Text);
                pRevision = double.Parse(txtPeriodoRevision.Text);

                probabilidad = probabilidad / 100;


                switch (comboPeriodo.SelectedIndex)
                {
                    case 0:
                        demandadiaria = demanda;
                        break;

                    case 1:
                        demandadiaria = demanda / dias;
                        break;

                    case 2:
                        demandadiaria = demanda / dias;
                        break;

                    default:
                        break;
                }

                x = Math.Sqrt((Math.Pow(sigma, 2)) * (pRevision + pEntrega));

                z = MathNet.Numerics.Distributions.Normal.InvCDF(0.0, 1.0, probabilidad);

                resultado = (demandadiaria * (pRevision + pEntrega)) + ((z * x) - inventario);

                labelQoptimo.Text = resultado.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DeshabilitarTexto();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.HabilitarTexto();
        }

        private void HabilitarTexto()
        {
            this.txtDemanda.Enabled = true;
            this.txtProbabilidad.Enabled = true;
            this.txtPeriodoRevision.Enabled = true;
            this.txtPlazo_de_entrega.Enabled = true;
            this.txtDesviacion.Enabled = true;
            this.txtInventarioExistente.Enabled = true;
            this.txtDiasLaborales.Enabled = true;
            this.comboPeriodo.Enabled = true;
            this.btnCalcular.Enabled = true;
            this.btnLimpiarCampos.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnAgregar.Enabled = false;
        }

        private void DeshabilitarTexto()
        {
            this.txtDemanda.Enabled = false;
            this.txtProbabilidad.Enabled = false;
            this.txtPeriodoRevision.Enabled = false;
            this.txtPlazo_de_entrega.Enabled = false;
            this.txtDesviacion.Enabled = false;
            this.txtInventarioExistente.Enabled = false;
            this.txtDiasLaborales.Enabled = false;
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
            this.txtProbabilidad.Text = string.Empty;
            this.txtPeriodoRevision.Text = string.Empty;
            this.txtPlazo_de_entrega.Text = string.Empty;
            this.txtDesviacion.Text = string.Empty;
            this.txtInventarioExistente.Text = string.Empty;
            this.txtDiasLaborales.Text = string.Empty;
            this.txtPlazo_de_entrega.Text = string.Empty;
            this.comboPeriodo.SelectedIndex = 0;
            this.labelQoptimo.Text = "0,00";
            this.labelResultadoROP.Text = "0,00";
          
        }

    }
}
