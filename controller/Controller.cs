using ProyectoNET1.model;
using View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Controller<T> where T : Consumable
    {
        public List<T> Products {  get; set; } 

        public Controller()
        {
            this.Products = new List<T>();

            T galleta = (T)Convert.ChangeType(new Consumable("galleta", 1550,20), typeof(T));
            T gaseosa = (T)Convert.ChangeType(new Consumable("gaseosa", 5000,7), typeof(T));
            T frituras = (T)Convert.ChangeType(new Consumable("frituras", 2650,13), typeof(T));
            T agua = (T)Convert.ChangeType(new Consumable("agua", 2000, 6), typeof(T));

            this.Products.Add(galleta);
            this.Products.Add(gaseosa);
            this.Products.Add(frituras);
            this.Products.Add(agua);
        }

        public List<T> GetProducts()
        {
            return this.Products;
        }

        public bool AddProduct(T consumable)
        {
 
            int last_size = this.Products.Count;

            this.Products.Add(consumable);

            if (this.Products.Count > last_size && this.Products.Count -1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }




}