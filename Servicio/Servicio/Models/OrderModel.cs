using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class OrderModel
    {
        public string InsertOrder(Orders Order)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {

                    db.REGISTRAR_ORDEN(Order.Order_User_Id, Order.Order_total, Order.NombreCompleto, Order.Product);
                    return "La orden se ha registrado con éxito";

                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

            public bool EditOrder(Orders order)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var TOrder = db.Orders.Find(order.Id);
                    if (TOrder != null)
                    {
                        if (order.Order_User_Id != null && order.Order_total != 0)
                        {
                            TOrder.Order_User_Id = order.Order_User_Id;
                            TOrder.Order_total = order.Order_total;
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

        public bool CancelOrder(Guid Id)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var TOrder = db.Orders.Find(Id);

                    if (TOrder != null)
                    {
                        TOrder.Status = false;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se pudo eliminar la orden");
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public List<Orders> ViewDetailedOrders()
        {
            
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {

                    var datos = db.MOSTRAR_ORDENES().ToList();


                    List<Orders> resultado = new List<Orders>();
                    if (datos != null  && datos.Count() > 0)
                    {
                        foreach (var item in datos)
                        {
                            resultado.Add(new Orders
                            {
                                Id = item.Id,
                                Order_User_Id = item.Order_User_Id,
                                NombreCompleto = item.NOMBRE_COMPLETO,
                                Product = item.Product,
                                Order_date = item.Order_date,
                                Order_total = item.Order_total

                            });
                        }
                        return resultado;
                    }
                    else
                    {
                        return resultado;
                    }
                    
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        //Lo podemos usar por si un cliente quiere ver una orden especifica
        public Orders ViewDetailedOrderById(Guid Id)
        {
            Orders order = new Orders();
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var datos = db.MOSTRAR_ORDEN_PORID(Id).FirstOrDefault();

                    if (datos != null)
                    {
                        order.Id = datos.Id;
                        order.Order_User_Id = datos.Order_User_Id;
                        order.NombreCompleto = datos.NOMBRE_COMPLETO;
                        order.Product = datos.Product;
                        order.Order_date = datos.Order_date;
                        order.Order_total = datos.Order_total;

                        return order;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        //Para listar las ordenes por cliente para su vista general
        public List<Orders> ViewCustomersDetailedOrders(Guid Id, bool showCanceledOrders)
        {

            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var datos = db.MOSTRAR_ORDENES_CLIENTE(Id).ToList();
                    List<Orders> DetailedOrders = new List<Orders>();

                    

                    if (datos != null && datos.Count() > 0)
                    {
                        if(showCanceledOrders == false)
                        {
                            foreach (var item in datos)
                            {
                                if (item.Status != false)
                                {
                                    DetailedOrders.Add(new Orders
                                    {
                                        Id = item.Id,
                                        Order_User_Id = item.Order_User_Id,
                                        NombreCompleto = item.NOMBRE_COMPLETO,
                                        Product = item.Product,
                                        Status = item.Status,
                                        Order_date = item.Order_date,
                                        Order_total = item.Order_total

                                    });
                                }
                            }
                            return DetailedOrders;
                        }
                        else
                        {
                            foreach (var item in datos)
                            {
                                DetailedOrders.Add(new Orders
                                {
                                    Id = item.Id,
                                    Order_User_Id = item.Order_User_Id,
                                    NombreCompleto = item.NOMBRE_COMPLETO,
                                    Product = item.Product,
                                    Status = item.Status,
                                    Order_date = item.Order_date,
                                    Order_total = item.Order_total

                                });
                            }
                            return DetailedOrders;
                        }

                        
                    }
                    else
                    {
                        return DetailedOrders;
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