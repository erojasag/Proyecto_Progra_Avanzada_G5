using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Transaction { get; set; }
        public Users User { get; set; }
        public List<Users> Users { get; set; }
        public Products Product { get; set; }
        public List<Products> Products { get; set; }
        public Brand Brand { get; set; }
        public List<Brand> Brands { get; set; }
        public Persons Person { get; set; }
        public List<Persons> Persons { get; set; }

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

        public Respuesta ArmarRespuestaProducts(int Id, string Message, bool Transaction, Products Product, List<Products> Products)
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

        public Respuesta ArmarRespuestaPersons(int Id, string Message, bool Transaction, Persons person, List<Persons> persons)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.Person = person;
            respuesta.Persons = persons;
            return respuesta;
        }
    }
}
