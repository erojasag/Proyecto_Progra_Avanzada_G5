using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Servicio.Models
{
    public class BrandModel
    {
        public List<Brand> ViewBrands()
        {
            using (var db = new SHOECORP_BDEntities())
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
            using (var db = new SHOECORP_BDEntities())
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
            using (var contexto = new SHOECORP_BDEntities())
            {
                try
                {
                    Brand TablaBrand = new Brand();
                    TablaBrand.Name = brand.Name;
                    TablaBrand.Photo = brand.Photo;

                    contexto.Brand.Add(TablaBrand);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    contexto.Dispose();
                    throw ex;
                }
            }
        }

        public bool EditBrand(Brand brand)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var TablaBrand = (from x in db.Brand
                                      where x.Id == brand.Id
                                      select x).FirstOrDefault();

                    if (TablaBrand != null)
                    {
                        TablaBrand.Name = brand.Name;
                        TablaBrand.Photo = brand.Photo;
                        db.SaveChanges();
                        return true;
                    }
                    else
                        throw new Exception("This brand does not exist");
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
            using (var db = new SHOECORP_BDEntities())
            {

                try
                {
                    var TablaBrand = (from x in db.Brand
                                      where x.Id == Id
                                      select x).FirstOrDefault();

                    if (TablaBrand != null)
                    {
                        if(TablaBrand.Product.Count == 0)
                        {
                            db.Brand.Remove(TablaBrand);
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("The brand cannot be removed because it has" +
                                "associated products");
                        }
                        
                    }
                    else
                        throw new Exception("The brand does not exist");
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
