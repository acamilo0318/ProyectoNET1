
namespace ProyectoNET1.model
{
    //modelos del proyecto
    public class Consumable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity_in_stock { get; set; }

        public Consumable(string name, int price, int Quantity_in_stock)
        {
            Name = name;
            Price = price;
            this.Quantity_in_stock = Quantity_in_stock;
        }

        public override string ToString()
        {
            return $"Nombre: {this.Name}, Precio: {this.Price}, Cantidad: {this.Quantity_in_stock}";
        }

        public int Consume()
        {
            if(this.Quantity_in_stock > 0)
            {
                this.Quantity_in_stock--;
            }
            return this.Quantity_in_stock;

        }
    }
}
