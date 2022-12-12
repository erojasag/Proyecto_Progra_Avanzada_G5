using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Entities
{
    public class Respuesta
    {
        
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Transaction { get; set; }
        public Users User { get; set; }
        public List<Users> Users { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public Brand Brand { get; set; }
        public List<Brand> Brands { get; set; }
        public Orders Order { get; set; }
        public List<Orders> Orders { get; set; }
        public Shipments Shipment { get; set; }
        public List<Shipments> Shipments { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }



        public Respuesta ArmarRespuestaUsers(int Id, string Message, bool Transaction, Users User, List<Users> Users)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.User = User;
            respuesta.Users = Users;
            return respuesta;
        }

        public Respuesta ArmarRespuestaProducts(int Id, string Message, bool Transaction, Product Product, List<Product> Products)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.Product = Product;
            respuesta.Products = Products;
            return respuesta;
        }

        public Respuesta ArmarRespuestaBrand(int Id, string Message, bool Transaction, Brand Brand, List<Brand> Brands)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.Brand = Brand;
            respuesta.Brands = Brands;
            return respuesta;
        }

        public Respuesta ArmarRespuestaOrders(int Id, string Message, bool Transaction, Orders Order, List<Orders> Orders)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.Order = Order;
            respuesta.Orders = Orders;
            return respuesta;
        }


        public Respuesta ArmarRespuestaShipment(int Id, string Message, bool Transaction, Shipments Shipment, List<Shipments> Shipments)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.Shipment = Shipment;
            respuesta.Shipments = Shipments;
            return respuesta;
        }

        public Respuesta ArmarRespuestaShoppingCart(int Id, string Message, bool Transaction, ShoppingCart ShoppingCart, List<ShoppingCart> ShoppingCarts)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.ShoppingCart = ShoppingCart;
            respuesta.ShoppingCarts = ShoppingCarts;
            return respuesta;
        }
    }
}