using Controller;
using ProyectoNET1.model;
using System;

namespace View
{
    class view
    {
        static void Main(string[] args)
        {
            Controller<Consumable> controller = new Controller<Consumable>();
            string opcion;
            do
            {
                Console.WriteLine("Bienvenido a la maquina dispensadora");               

                Console.WriteLine("ES cliente o proveedor?");

                List<Consumable> Products = controller.GetProducts();

                //input del usuario que indica si es cliente o proveedor
                string input_client_type = Console.ReadLine().ToLower();

                if (input_client_type == "cliente")
                {
                    Console.WriteLine("Por favor, seleccione el producto que desea comprar:");
                    foreach (var products in controller.GetProducts())
                    {
                        Console.WriteLine(products);
                    }

                    Console.Write("Ingrese el nombre del producto que desea comprar: ");
                    string seleccion = Console.ReadLine().ToLower();

                    Consumable productoSeleccionado = Products.FirstOrDefault(p => p.Name == seleccion);

                    if (productoSeleccionado == null)
                    {
                        Console.WriteLine("El producto seleccionado no está en la lista.");
                    }
                    else
                    {
                        while (true)
                        {

                            Console.WriteLine($"Ha seleccionado el siguiente producto: {productoSeleccionado.Name} (${productoSeleccionado.Price})");
                            if (productoSeleccionado.Quantity_in_stock == 0)
                            {
                                Console.WriteLine($"Lo siento, {productoSeleccionado.Name} ya no está disponible.");
                                break;
                            }
                            else
                            {
                                productoSeleccionado.Consume();
                            }

                            Console.WriteLine("Ingrese con cuanto desea cancelar (solo billetes)");
                            int paymentAmount;
                            do
                            {
                                int.TryParse(Console.ReadLine(), out paymentAmount);

                                if (paymentAmount < productoSeleccionado.Price)
                                {
                                    Console.WriteLine($"El precio de {productoSeleccionado.Name} es ${productoSeleccionado.Price}. La cantidad ingresada es insuficiente.");
                                }
                                else
                                {
                                    int changeAmount = paymentAmount - productoSeleccionado.Price;
                                    int count500 = changeAmount / 500;
                                    int count200 = (changeAmount % 500) / 200;
                                    int count100 = ((changeAmount % 500) % 200) / 100;
                                    int count50 = (((changeAmount % 500) % 200) % 100) / 50;
                                    Console.WriteLine($"El cambio es ${changeAmount}.");
                                    Console.WriteLine($"{count500} monedas de 500,{count200} monedas de 200, {count100} monedas de 100 y {count50} monedas de 50");
                                }
                            } while (paymentAmount < productoSeleccionado.Price);
                            break;
                        }
                    }

                }
                else if (input_client_type == "proveedor")
                {
                    Console.WriteLine("seleccione una opcion (numero)");

                    Console.WriteLine("1. Hacer re-stock. \n2. Agregar nuevo producto.");

                    int opcion_proveedor = Convert.ToInt32(Console.ReadLine());

                    if (opcion_proveedor == 1)
                    {
                        foreach (var products in controller.GetProducts())
                        {
                            Console.WriteLine(products);
                        }

                        Console.Write("Ingrese el nombre del producto al que desea hacer re-stock: ");
                        string seleccion = Console.ReadLine().ToLower();

                        Consumable productoSeleccionado = Products.FirstOrDefault(p => p.Name == seleccion);

                        Console.WriteLine($"Ha seleccionado el siguiente producto: {productoSeleccionado.Name}, cantidad en stock {productoSeleccionado.Quantity_in_stock}");

                        Console.WriteLine("Cuanto desea surtir?");
                        while (true)
                        {
                            try
                            {
                                int candidad_restock = Convert.ToInt32(Console.ReadLine());
                                productoSeleccionado.Re_stock(candidad_restock);

                                Console.WriteLine($"La nueva cantidad en stock del producto es: {productoSeleccionado.Quantity_in_stock} ");

                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Por favor ingrese un valor valido");
                            }
                        
                        }
                        

                        
                    }
                    else if (opcion_proveedor == 2)
                    { 

                        while (true)
                        {
                            Console.WriteLine("Agregue un producto en el siguiente formato: nombre,precio,cantidad");



                            string input_product = Console.ReadLine().ToLower();

                            string[] product_values = input_product.Split(',');

                            try
                            {
                                Consumable product = new Consumable(
                                    product_values[0],
                                    Convert.ToInt32(product_values[1]),
                                    Convert.ToInt32(product_values[2])
                                );

                                Products.Add(product);
                                Console.WriteLine("Producto agregado correctamente");
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("por favor ingrese los productos con el formato requerido");
                            }

                        }
                    }
                }

                Console.WriteLine("¿Desea realizar otra acción? (s/n)");
                opcion = Console.ReadLine().ToLower();

            } while (opcion == "s");

        }
    }
}