using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class ProductsModel
    {
        public List<Product> ViewProducts()
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tproducts = db.Product.ToList();
                    List<Product> products = new List<Product>();
                    
                    foreach (var product in tproducts)
                    {
                        if (product.Brand_Id != 0)
                        {
                            
                            var tbrand = db.Brand.Find(product.Brand_Id);
                            Brand brand = new Brand();

                            brand.Id = tbrand.Id;
                            brand.Name = tbrand.Name;


                            products.Add(new Product
                            {
                                Id = product.Id,
                                Brand_Id = product.Brand_Id,
                                Price = product.Price,
                                Stock = product.Stock,
                                Model = product.Model,
                                Color = product.Color,
                                Photo = product.Photo,
                                shoeSize = product.shoeSize,
                                Registration_date = product.Registration_date,
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

        public Product ViewProductById(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tproduct = db.Product.Find(Id);
                    Product product = new Product();
                    
                    if (tproduct != null)
                    {
                        product.Id = tproduct.Id;
                        product.Price = tproduct.Price;
                        product.Stock = tproduct.Stock;
                        product.Model = tproduct.Model;
                        product.Color = tproduct.Color;
                        product.shoeSize = tproduct.shoeSize;
                        product.Photo = tproduct.Photo;
                        product.Brand_Id = tproduct.Brand_Id;
                        Brand brand = new Brand();
                        var getBrand = db.Brand.Find(product.Brand_Id);
                        brand.Id = getBrand.Id;
                        brand.Name = getBrand.Name;
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

        public bool InsertProduct(Product Product)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    Product tproducts = new Product();
                    if (Product != null)
                    {
                        var checkProduct = db.Product.ToList();
                        if(checkProduct.Count > 0)
                        {
                            List<Product> products = new List<Product>();
                            foreach (var item in checkProduct)
                            {
                                products.Add(new Product
                                {
                                    Id = item.Id,
                                    Brand_Id = item.Brand_Id,
                                    Price = item.Price,
                                    Stock = item.Stock,
                                    Model = item.Model,
                                    Color = item.Color,
                                    shoeSize = item.shoeSize,
                                    Photo = item.Photo,
                                });
                            }
                            foreach (var item in products)
                            {
                                if (item.Id == Product.Id)
                                {
                                    throw new Exception("El codigo de producto que desea insertar ya existe");
                                }
                                if (item.shoeSize == Product.shoeSize && item.Color == Product.Color)
                                {
                                    throw new Exception("La talla y color ya se encuentran registrados, para anadir un producto hazlo modificando su stock");
                                }
                            };

                            tproducts.Id = Product.Id;
                            tproducts.Brand_Id = Product.Brand_Id;
                            tproducts.Price = Product.Price;
                            tproducts.Stock = Product.Stock;
                            tproducts.Model = Product.Model;
                            tproducts.Color = Product.Color;
                            tproducts.shoeSize = Product.shoeSize;
                            tproducts.Photo = Product.Photo;
                            tproducts.Registration_date = DateTime.Now;
                            db.Product.Add(tproducts);
                            db.SaveChanges();
                        }
                        else
                        {
                            tproducts.Id = Product.Id;
                            tproducts.Brand_Id = Product.Brand_Id;
                            tproducts.Price = Product.Price;
                            tproducts.Stock = Product.Stock;
                            tproducts.Model = Product.Model;
                            tproducts.Color = Product.Color;
                            tproducts.shoeSize = Product.shoeSize;
                            tproducts.Photo = Product.Photo;
                            tproducts.Registration_date = DateTime.Now;
                            db.Product.Add(tproducts);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        throw new Exception("Ingrese los parametros del producto");
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

        public bool EditProduct(Product product)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tproduct = db.Product.Find(product.Id);
                    if (tproduct != null)
                    {
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
                        if (product.Model != null)
                        {
                            tproduct.Model = product.Model;
                            tproduct.Modification_date = DateTime.Now;
                        }
                        if (product.Color != null)
                        {
                            tproduct.Color = product.Color;
                            tproduct.Modification_date = DateTime.Now;   
                        }
                        if (product.shoeSize != null)
                        {
                            var checkProduct = db.Product.ToList();
                            List<Product> products = new List<Product>();
                            if (checkProduct.Count > 0)
                            {
                                foreach (var item in checkProduct)
                                {
                                    products.Add(new Product
                                    {
                                        shoeSize = item.shoeSize,
                                    });
                                }
                                foreach (var item in products)
                                {

                                    if (item.shoeSize == product.shoeSize)
                                    {
                                        throw new Exception("La talla ya se encuentra registrada, para anadir un producto hazlo modificando su stock");
                                    }
                                };
                                tproduct.shoeSize = product.shoeSize;
                                tproduct.Modification_date = DateTime.Now;
                            }
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
                    var tproduct = db.Product.Find(Id);

                    if (tproduct != null)
                    {
                        db.Product.Remove(tproduct);
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