using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Windows.Forms;
using XML.Models.Petitions;

namespace XML.Clases
{
    public class FacturaServicios
    {
        private string[] paths = null;
        private string path;
        private bool oneFile = true;

        public bool subirFactura(Factura factura)
        {
            Petitions req = new Petitions();
            try
            {
                bool logued = req.loginPostRequest();
                if (logued)
                {
                    bool result = req.newSalePutRequest(factura);
                    if (result)
                    {
                        req.logoutPostRequest();
                        return true;
                    }
                    else
                    {
                        req.logoutPostRequest();
                        return false;
                    }
                }
                else
                {
                    req.logoutPostRequest();
                    return false;
                }
            }
            catch (Exception ex)
            {
                req.logoutPostRequest();
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool subirFacturas(List<Factura> facturas)
        {
            Petitions req = new Petitions();
            try
            {
                bool logued = req.loginPostRequest();
                if (logued)
                {
                    bool result;
                    foreach (Factura factura in facturas)
                    {
                        result = req.newSalePutRequest(factura);
                        if (!result)
                        {
                            MessageBox.Show("Hubo un error en la factura con el folio: " +
                                factura.CustomerOrderNbr, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    req.logoutPostRequest();
                    return true;
                }
                else
                {
                    req.logoutPostRequest();
                    return false;
                }
            }
            catch (Exception ex)
            {
                req.logoutPostRequest();
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public void seleccionarArchivo (Label lblNombreArchivo, ListBox lstBox, Button btnSubirFactura)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(ofd.FileName);
                    lblNombreArchivo.Text = ofd.SafeFileName;
                    path = ofd.FileName;
                    if (Path.GetExtension(ofd.SafeFileName) == ".zip")
                    {
                        lstBox.Items.Clear();
                        DescomprimirCarpetaZip desc = new DescomprimirCarpetaZip();
                        desc.setZipPath(path);
                        string temp = Path.GetTempPath() + @"\factura" + Guid.NewGuid().ToString().Substring(0, 20);
                        desc.setExtractPath(temp);
                        desc.descomprimir(desc.getZipPath(), desc.getExtractPath());
                        ObtenerArchivosXML file = new ObtenerArchivosXML();
                        paths = file.obtenerListaArchivos(temp);
                        foreach (string pathFile in paths)
                        {
                            lstBox.Items.Add(pathFile);
                        }
                        oneFile = false;
                    }
                    else
                    {
                        lstBox.Items.Clear();
                        lstBox.Items.Add(ofd.FileName);
                        oneFile = true;
                    }
                    btnSubirFactura.Enabled = true;
                }
                catch (SecurityException ex)
                {
                    oneFile = true;
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    
        public void subirArchivo(Label lblNombreArchivo, ListBox lstBox, Button btnSubirFactura)
        {
            if (oneFile)
            {
                if (!string.IsNullOrEmpty(path))
                {
                    XMLtoJSON xmltojson = new XMLtoJSON();
                    Factura factura = xmltojson.XMLAObjeto(path);
                    bool result = subirFactura(factura);
                    if (result)
                    {
                        btnSubirFactura.Enabled = false;
                        path = String.Empty;
                        lblNombreArchivo.Text = "Ningún archivo seleccionado";
                        lstBox.Items.Clear();
                    }
                }
            }
            else
            {
                if (paths.Length > 0)
                {
                    XMLtoJSON xmltojson = new XMLtoJSON();
                    List<Factura> facturas = new List<Factura>();
                    foreach (string path in paths)
                    {
                        Factura factura = xmltojson.XMLAObjeto(path);
                        facturas.Add(factura);
                    }
                    bool result = subirFacturas(facturas);
                    if (result)
                    {
                        btnSubirFactura.Enabled = false;
                        oneFile = true;
                        paths = null;
                        lblNombreArchivo.Text = "Ningún archivo seleccionado";
                        lstBox.Items.Clear();
                    }
                }
            }
        }
    }
}
