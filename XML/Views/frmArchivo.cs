using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using XML.Clases;

namespace XML.Views
{
    public partial class frmArchivo : Form
    {
        FacturaServicios factserv = new FacturaServicios();
        public frmArchivo()
        {
            InitializeComponent();
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            factserv.seleccionarArchivo(lblNombreArchivo, lstBox, btnSubirFactura);
        }

        private void btnSubirFactura_Click(object sender, EventArgs e)
        {
            factserv.subirArchivo(lblNombreArchivo, lstBox, btnSubirFactura);
        }
    }
}
