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
        public Person Person { get; set; }
        public List<Person> Persons { get; set; }
        public UserPerson UserPerson { get; set; }
        public List<UserPerson> UsersPersons { get; set; }


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

        public Respuesta ArmarRespuestaPerson(int Id, string Message, bool Transaction, Person person, List<Person> persons)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.Person = person;
            respuesta.Persons = persons;
            return respuesta;
        }

        public Respuesta ArmarRespuestaUserPerson(int Id, string Message, bool Transaction, UserPerson UserPerson, List<UserPerson> UsersPersons)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Id = Id;
            respuesta.Message = Message;
            respuesta.Transaction = Transaction;
            respuesta.UserPerson = UserPerson;
            respuesta.UsersPersons = UsersPersons;
            return respuesta;
        }
    }
}