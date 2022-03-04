using System;
using System.IO;
using System.IO.Compression;

namespace XML.Clases
{
    public class DescomprimirCarpetaZip
    {
        private String zipPath; //@"C:\Users\Erick\Desktop\PRUEBAS\Prueba.zip"
        private String extractPath; //@"C:\Users\Erick\Desktop\PRUEBAS"

        //Métodos de lectura y escritura de atributos
        public String getZipPath()
        {
            return this.zipPath;
        }
        public void setZipPath(String zip)
        {
            this.zipPath = zip;
        }
        public String getExtractPath()
        {
            return this.extractPath;
        }
        public void setExtractPath(String extract)
        {
            this.extractPath = extract;
        }

        public void descomprimir(String zipPath, String extractPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
