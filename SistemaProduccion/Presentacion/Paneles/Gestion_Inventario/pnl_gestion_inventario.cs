using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaProduccion.Presentacion.Paneles.Gestion_Inventario;

namespace SistemaProduccion.Presentacion.Paneles
{
    public partial class pnl_gestion_inventario : UserControl
    {
        private Modelo_Q modQ;
        private Modelo_P modP;

        public pnl_gestion_inventario()
        {
            InitializeComponent();
            this.cargarPanelModeloQ();
        }

       

        private void btnModeloQ_Click(object sender, EventArgs e)
        {
            this.cargarPanelModeloQ();
        }

        private void btnModelo_P_Click(object sender, EventArgs e)
        {
            this.cargarPanelModeloP();
        }

        public void cargarPanelModeloQ()
        {
            if (this.panelContainer.Controls.Count != 0)
            {
                this.panelContainer.Controls.RemoveAt(0);
            }
            this.modQ = new Modelo_Q();
            this.modQ.Visible = true;
            this.panelContainer.Controls.Add(modQ);
        }

        public void cargarPanelModeloP()
        {
            if (this.panelContainer.Controls.Count != 0)
            {
                this.panelContainer.Controls.RemoveAt(0);
            }
            this.modP = new Modelo_P();
            this.modP.Visible = true;
            this.panelContainer.Controls.Add(modP);
        }
    }
}
