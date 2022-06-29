using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class BrandModel
    {
        public List<Brand> ViewBrands()
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tbrand = db.Brand.ToList();
                    List<Brand> brands = new List<Brand>();
                    
                    foreach (var brand in tbrand)
                    {
                        brands.Add(new Brand
                        {
                            Id = brand.Id,
                            Name = brand.Name,
                            Photo = brand.Photo
                        });                           
                    }
                    return brands;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public Brand ViewBrandById(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tbrand = db.Brand.Find(Id);
                    Brand brand = new Brand();
                    if (tbrand != null)
                    {
                        brand.Id = tbrand.Id;
                        brand.Name = tbrand.Name;
                        brand.Photo = tbrand.Photo;
                        return brand;
                    }
                    else
                    {
                        throw new Exception("La marca no se encontro con el id" + " " + Id);
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool InsertBrand(Brand brand)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    if (brand != null)
                    {
                        var checkBrand = db.Brand.ToList();
                        List<Brand> brands = new List<Brand>();

                        if (checkBrand != null)
                        {
                            foreach (var cbrand in checkBrand)
                            {
                                brands.Add(new Brand
                                {
                                    Id = cbrand.Id,
                                    Name = cbrand.Name
                                });
                            };
                        }

                        foreach(var lbrand in brands)
                        {
                            while(brand.Name == lbrand.Name)
                            {
                                throw new Exception("La marca que desea insertar ya existe");
                            }
                        };

                        Brand tbrand = new Brand();
                        tbrand.Name = brand.Name;
                        tbrand.Photo = brand.Photo;
                        db.Brand.Add(tbrand);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No hay marcas registradas");
                    }
    
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool EditBrand(Brand brand)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tbrand = db.Brand.Find(brand.Id);
                    if (tbrand != null)
                    {
                        if (brand.Name != null)
                        {
                            tbrand.Name = brand.Name;
                        }
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool DeleteBrand(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tbrand = db.Brand.Find(Id);

                    if (tbrand != null)
                    {
                        db.Brand.Remove(tbrand);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se pudo eliminar la marca");
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