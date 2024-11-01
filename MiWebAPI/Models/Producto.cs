
public class Producto
{
    public int IdProducto {get; set;}
    public string Descripcion {get; set;}
    public int Precio {get; set;}

    public Producto(int idProd, string descripcion, int precio)
    {
        this.IdProducto = idProd;
        this.Descripcion = descripcion;
        this.Precio = precio;
    }

}
