using System;
using System.Xml;
using XML.Clases.JsonSO;

namespace XML.Clases
{
    internal class XMLtoJSON
    {
        public Factura XMLAObjeto(string r)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(r);

            XmlElement elem = doc.DocumentElement; //Obtiene lo relacionado al nodo raíz

            Factura fac = new Factura();

            if (elem.HasAttribute("Folio"))
            {
                fac.CustomerOrderNbr.value = "Jose" + elem.GetAttribute("Folio");
            }

            DateTime date;
            if (elem.HasAttribute("Fecha"))
            { 
                date = DateTime.Parse(elem.GetAttribute("Fecha"));
                fac.Date.value = date.ToString("yyyy-MM-dd");
            }

            XmlNodeList elemList = doc.GetElementsByTagName("cfdi:Conceptos");
            XmlNodeList lista = ((XmlElement)elemList[0]).GetElementsByTagName("cfdi:Concepto");
            foreach (XmlElement nodo in lista)
            {
                fac.Description.value = nodo.GetAttribute("Descripcion");
                fac.ExternalReference.value = nodo.GetAttribute("ClaveProdServ");
            }

            XmlNodeList elemList2 = doc.GetElementsByTagName("cfdi:Complemento");
            XmlNodeList lista2 = ((XmlElement)elemList2[0]).GetElementsByTagName("tfd:TimbreFiscalDigital");
            foreach (XmlElement nodo in lista2)
            {
                date = DateTime.Parse(nodo.GetAttribute("FechaTimbrado"));
                fac.RequestedOn.value = date.ToString("yyyy-MM-dd");
            }

            XmlNodeList elemList3 = doc.GetElementsByTagName("cfdi:Conceptos");
            XmlNodeList lista3 = ((XmlElement)elemList3[0]).GetElementsByTagName("cfdi:Concepto");
            foreach (XmlElement nodo in lista3)
            {
                var orderDetail = new OrderDetail();
                orderDetail.InventoryID.value = nodo.GetAttribute("NoIdentificacion");
                orderDetail.Quantity.value = Double.Parse(nodo.GetAttribute("Cantidad"));
                orderDetail.UnitPrice.value = Double.Parse(nodo.GetAttribute("ValorUnitario"));
                fac.OrderDetail.Add(orderDetail);
            }
            return fac;
        }
    }
}
