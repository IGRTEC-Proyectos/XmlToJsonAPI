using System.Collections.Generic;
using XML.Clases.JsonSO;

namespace XML.Clases
{
    public  class Factura
    {
        public Customer Customer { get; set; } //XML: "nombre" en "<cfdi:Receptor"
        public CustomerOrderNbr CustomerOrderNbr { get; set; } //XML: "folio" en "<cfdi:Comprobante"
        public Date Date { get; set; } //XML: "fecha" en "<cfdi:Comprobante"
        public Descripcion Description { get; set; } //XML: "Descripcion" en "<cfdi:Concepto"
        public ExternalReference ExternalReference { get; set; } //XML: "ClaveProdServ" en "<cfdi:Concepto"
        public OrderType OrderType { get; set; } //XML: "CondicionesDePago" en "<cfdi:Comprobante"
        public RequestedOn RequestedOn { get; set; } //XML: "FechaTimbrado" en "<tfd:TimbreFiscalDigital"
        public List<OrderDetail> OrderDetail { get; set; } //XML: "OrderDetail" en "<cfdi:OrderDetail"

        //public Factura(string customerOrderNbr, string date, string description, string externalReference, string orderType, string requestedOn, string branch, string inventoryID, double quantity, double UnitPrice, string warehouse)
        public Factura()
        {
            Customer = new Customer();
            CustomerOrderNbr = new CustomerOrderNbr();
            Date = new Date();
            Description = new Descripcion();
            ExternalReference = new ExternalReference();
            RequestedOn = new RequestedOn();
            OrderType = new OrderType();
            OrderDetail = new List<OrderDetail>();

        }

    }
}