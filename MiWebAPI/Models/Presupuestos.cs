class Presupuestos
{
    public int IdPresupuesto {get; set;}
    public string NombreDestinatario {get; set;}
    public List<PresupuestosDetalle> Detalle {get; set;}
    
    public Presupuestos(string nombreDest, List<PresupuestosDetalle> detalle)
    {
        this.NombreDestinatario = nombreDest;
        this.Detalle = detalle;
    }

    public double MontoPresupuesto()
    {
        int monto = Detalle.Sum(d => d.Cantidad*d.Producto.Precio);
        return monto;
    }

    public double MontoPresupuestoConIVA()
    {
        return MontoPresupuesto()*1.21;
    }

    public int CantidadProductos()
    {
        return Detalle.Sum(d => d.Cantidad);
    }
}