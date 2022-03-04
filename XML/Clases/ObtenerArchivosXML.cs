using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace XML.Clases
{
    public class ObtenerArchivosXML
    {
        List<string> lista = new List<string>();
        public string[] obtenerListaArchivos(string rutaDescomprimido)
        {
            DirectoryInfo di = new DirectoryInfo(rutaDescomprimido);
            foreach(DirectoryInfo subdi in di.GetDirectories())
            {
                var subdirectory = subdi.FullName;
                DirectoryInfo di2 = new DirectoryInfo(subdirectory);
                foreach(FileInfo fi in di2.GetFiles())
                {
                    string ruta = fi.DirectoryName + @"\" + fi.Name;
                    lista.Add(ruta);
                }
            }

            foreach (FileInfo fi in di.GetFiles())
            {
                string ruta = fi.DirectoryName + @"\" + fi.Name;
                lista.Add(ruta);
            }
            return lista.ToArray();
        }
    }
}
