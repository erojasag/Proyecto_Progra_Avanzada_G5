using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class ProductModel
    {

        readonly Respuesta respuesta = new Respuesta();
        public List<Product> ViewProducts()
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var getProducts = connection.Product.ToList();
                    List<Product> tproducts = new List<Product>();
                    foreach (var product in getProducts)
                    {
                        tproducts.Add(new Product
                        {
                            Id = product.Id,
                            Price = product.Price,
                            Stock = product.Stock,
                            Photo = product.Photo,
                            Brand = product.Brand,
                            Model = product.Model,
                            Color = product.Color,
                            Registration_date = product.Registration_date,
                        });
                    }
                    return tproducts;

                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }
        }

        public Product ViewProduct(int Id)
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    Product tproduct = new Product();
                    var getProduct = connection.Product.Find(Id);
                    tproduct.Id = getProduct.Id;
                    tproduct.Price = getProduct.Price;
                    tproduct.Stock = getProduct.Stock;
                    tproduct.Photo = getProduct.Photo;
                    tproduct.Brand = getProduct.Brand;
                    tproduct.Model = getProduct.Model;
                    tproduct.Color = getProduct.Color;
                    tproduct.Registration_date = getProduct.Registration_date;
                    return tproduct;
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }

            }
        }

        public bool InsertProduct(Product product)
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    if (product != null)
                    {
                        Product tproduct = new Product();
                        tproduct.Id = product.Id;
                        tproduct.Price = product.Price;
                        tproduct.Stock = product.Stock;
                        tproduct.Photo = product.Photo;
                        tproduct.Brand = product.Brand;
                        tproduct.Model = product.Model;
                        tproduct.Color = product.Color;
                        tproduct.Registration_date = DateTime.Now;
                        connection.Product.Add(tproduct);
                        connection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var getProduct = connection.Product.Find(product.Id);
                    if(getProduct != null)
                    {
                        getProduct.Price = product.Price;
                        getProduct.Stock = product.Stock;
                        getProduct.Photo = product.Photo;
                        getProduct.Brand = product.Brand;
                        getProduct.Model = product.Model;
                        getProduct.Color = product.Color;
                        getProduct.Modification_date = DateTime.Now;
                        connection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El producto a actualizar no se encontro");
                    }
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }
        }

        public bool DeleteProduct(int Id)
        {
            using(var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var getProduct = connection.Product.Find(Id);
                    if (getProduct != null)
                    {
                        connection.Product.Remove(getProduct);
                        connection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El producto no se encontro");
                    }
                }catch(Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }

            }
        }



        public Respuesta ArmarRespuesta(int Id, string Message, bool transaccion, Product product
            , List<Product> products)
        {

            respuesta.Id = 0;
            respuesta.Message = "OK";
            respuesta.transaccion = transaccion;
            respuesta.products = products;
            respuesta.product = product;

            return respuesta;

        }
    }   
}
