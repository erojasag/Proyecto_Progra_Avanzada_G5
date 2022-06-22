using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class ProductsModel
    {
        public List<Products> ViewProducts()
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tproducts = db.Products.ToList();
                    List<Products> products = new List<Products>();
                    
                    foreach (var product in tproducts)
                    {
                        if (product.Brand_Id != 0)
                        {
                            
                            var tbrand = db.Brand.Find(product.Brand_Id);
                            Brand brand = new Brand();

                            brand.Id = product.Brand_Id;
                            brand.Name = tbrand.Name;
                            brand.Model = tbrand.Model;
                            brand.Color = tbrand.Color;
                            brand.Photo = tbrand.Photo;

                            products.Add(new Products
                            {
                                Id = product.Id,
                                Price = product.Price,
                                Stock = product.Stock,
                                Photo = product.Photo,
                                Brand_Id = product.Brand_Id,
                                Brand = brand
                            });
                        }
                    }
                    if (products.Count == 0)
                    {
                        throw new Exception("No hay productos para mostrar");
                    }
                    else
                    {
                        return products;
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public Products ViewProductById(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tproduct = db.Products.Find(Id);
                    Products product = new Products();
                    
                    if (tproduct != null)
                    {
                        product.Id = tproduct.Id;
                        product.Price = tproduct.Price;
                        product.Stock = tproduct.Stock;
                        product.Photo = tproduct.Photo;
                        product.Brand_Id = tproduct.Brand_Id;
                        Brand brand = new Brand();
                        var getBrand = db.Brand.Find(product.Brand_Id);
                        brand.Id = getBrand.Id;
                        brand.Name = getBrand.Name;
                        brand.Model = getBrand.Model;
                        brand.Color = getBrand.Color;
                        brand.Photo = getBrand.Photo;
                        product.Brand = brand;
                    }
                    else
                    {
                        throw new Exception("El producto Id:" + " " + Id + " " + "que esta buscando no existe");
                    }
                    return product;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool InsertProduct(Products Product)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    Products tproducts = new Products();
                    if (Product != null)
                    {
                        var checkProduct = db.Products.Find(Product.Id);
                        if (checkProduct != null)
                        {
                            throw new Exception("El codigo de producto que desea insertar ya existe");
                        }
                        else
                        {
                            tproducts.Price = Product.Price;
                            tproducts.Stock = Product.Stock;
                            tproducts.Photo = Product.Photo;
                            tproducts.Brand_Id = Product.Brand_Id;
                            tproducts.Registration_date = DateTime.Now;
                            db.Products.Add(tproducts);
                            db.SaveChanges();
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool EditProduct(Products product)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tproduct = db.Products.Find(product.Id);
                    if (tproduct != null)
                    {
                        tproduct.Id = product.Id;

                        if (product.Price != 0)
                        {
                            tproduct.Price = product.Price;
                            tproduct.Modification_date = DateTime.Now;
                        }
                        if (product.Stock != 0)
                        {
                            tproduct.Stock = product.Stock;
                            tproduct.Modification_date = DateTime.Now;
                        }
                        if (product.Photo != null)
                        {
                            tproduct.Photo = product.Photo;
                            tproduct.Modification_date = DateTime.Now;
                        }
                        if (product.Brand_Id != 0)
                        {
                            tproduct.Brand_Id = product.Brand_Id;
                            tproduct.Modification_date = DateTime.Now;
                        }
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Error al editar el producto");
                    }
                }catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool DeleteProduct(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tproduct = db.Products.Find(Id);

                    if (tproduct != null)
                    {
                        db.Products.Remove(tproduct);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El usuario no se pudo eliminar");
                    }

                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }


    }
}