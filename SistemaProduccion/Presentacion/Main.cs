using SistemaProduccion.Presentacion.Paneles;
using SistemaProduccion.Presentacion.Paneles.Analisis_Inventario;
using SistemaProduccion.Presentacion.Paneles.Planeacion_agregada;
using SistemaProduccion.Presentacion.Paneles.TmpPanelAlex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProduccion.Presentacion
{
    public partial class Main : Form
    {
        private pnl_gestion_inventario pgi;
        private pnl_analisis_de_inventario pai;
        private Pnl_planeacion_agregada ppa;
        private pnlGestionOperaciones pnlOperaciones;
        public Main()
        {
            InitializeComponent();
            pnlOperaciones = new pnlGestionOperaciones();
            pgi = new pnl_gestion_inventario();
            pgi.Visible = true;
            panelContenedor.Controls.Add(pgi);

            /*int height = Screen.PrimaryScreen.WorkingArea.Height;
            int width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Size = new Size(width, height);
            this.Location = new Point(0, 0);*/
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrar_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnCerrar.BackColor = Color.FromArgb(76, 109, 139);
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            this.btnCerrar.BackColor = Color.Transparent;
        }

        private void btnGestionInventario_Click(object sender, EventArgs e)
        {
            if (panelContenedor.Controls.Count != 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }
            pgi = new pnl_gestion_inventario();
            pgi.Visible = true;
            panelContenedor.Controls.Add(pgi);
            this.labelInfoMain.Text = "Sistema de producción - Gestión de inventario";
         

            this.btnGestionInventario.Normalcolor =  Color.FromArgb(61, 91, 119);
            this.btnGEstionOperaciones.Normalcolor = Color.Transparent;
            this.btnAnalisisInventario.Normalcolor = Color.Transparent;
            this.btnPlaneacionAgregada.Normalcolor = Color.Transparent;
        }

        private void btnGEstionOperaciones_Click(object sender, EventArgs e)
        {
            pnlOperaciones.Size = this.panelContenedor.Size;
            if (panelContenedor.Controls.Count != 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }
            panelContenedor.Controls.Add(pnlOperaciones);

            this.btnGestionInventario.Normalcolor = Color.Transparent;
            this.btnGEstionOperaciones.Normalcolor = Color.FromArgb(61, 91, 119);
            this.btnAnalisisInventario.Normalcolor = Color.Transparent;
            this.btnPlaneacionAgregada.Normalcolor = Color.Transparent;
        }

        private void btnAnalisisInventario_Click(object sender, EventArgs e)
        {
            if (panelContenedor.Controls.Count != 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }
            pai = new pnl_analisis_de_inventario();
            pai.Visible = true;
            panelContenedor.Controls.Add(pai);
            this.labelInfoMain.Text = "Sistema de producción - Análisis de inventario";
           
            this.btnGestionInventario.Normalcolor = Color.Transparent;
            this.btnGEstionOperaciones.Normalcolor = Color.Transparent;
            this.btnAnalisisInventario.Normalcolor = Color.FromArgb(61, 91, 119);
            this.btnPlaneacionAgregada.Normalcolor = Color.Transparent;
        }

        private void btnPlaneacionAgregada_Click(object sender, EventArgs e)
        {
            if (panelContenedor.Controls.Count != 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }
            ppa = new Pnl_planeacion_agregada();
            ppa.Visible = true;
            panelContenedor.Controls.Add(ppa);
            this.labelInfoMain.Text = "Sistema de producción - Planeación agregada";
            this.btnGestionInventario.Normalcolor = Color.Transparent;
            this.btnGEstionOperaciones.Normalcolor = Color.Transparent;
            this.btnAnalisisInventario.Normalcolor = Color.Transparent;
            this.btnPlaneacionAgregada.Normalcolor = Color.FromArgb(61, 91, 119);
        }
    }
}
