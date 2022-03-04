namespace XML.Clases.JsonSO
{
    public class OrderDetail
    {
        public Branch Branch { get; set; } //XML: "LugarExpedicion" en "<cfdi:Comprobante"
        public InventoryID InventoryID { get; set; } //XML: "NoIdentificacion" en "<cfdi:Concepto"
        public Quantity Quantity { get; set; } //XML: "Cantidad" en "<cfdi:Concepto"
        public UnitPrice UnitPrice { get; set; } //XML: "ValorUnitario" en "<cfdi:Concepto"
        public Warehouse Warehouse { get; set; } //XML: "ClaveUnidad" en "<cfdi:Concepto"


        public OrderDetail()
        {
            Branch = new Branch();
            InventoryID = new InventoryID();
            Quantity = new Quantity();
            UnitPrice = new UnitPrice();
            Warehouse = new Warehouse();
        }
    }
}