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
        public List<OrdenDetallada> ViewOrders()
        {
            List<OrdenDetallada> resultado = new List<OrdenDetallada>();
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {

                    var datos = db.MOSTRAR_ORDENES().ToList();

                    foreach (var item in datos)
                    {
                        resultado.Add(new OrdenDetallada
                        {
                            Id = item.Id,
                            UserId = item.Order_User_Id,
                            NombreCompleto = item.NOMBRE_COMPLETO,
                            Producto = item.Product,
                            Order_date = item.Order_date,
                            Order_total = item.Order_total

                        });
                    }
                    return resultado;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public OrdenDetallada ViewOrderById(int Id)
        {
            OrdenDetallada order = new OrdenDetallada();
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var datos = db.MOSTRAR_ORDEN_PORID(Id).FirstOrDefault();

                    if (datos != null)
                    {
                        order.Id = datos.Id;
                        order.UserId = datos.Order_User_Id;
                        order.NombreCompleto = datos.NOMBRE_COMPLETO;
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

        public List<OrdenDetallada> ViewCustomersOrders(Guid Id)
        {
            List<OrdenDetallada> orders = new List<OrdenDetallada>();
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var datos = db.MOSTRAR_ORDENES_CLIENTE(Id).ToList();

                    foreach (var item in datos)
                    {
                        orders.Add(new OrdenDetallada
                        {
                            Id = item.Id,
                            UserId = item.Order_User_Id,
                            NombreCompleto = item.NOMBRE_COMPLETO,
                            Producto = item.Product,
                            Order_date = item.Order_date,
                            Order_total = item.Order_total

                        });
                    }
                    return orders;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public string InsertOrder(Orders Order)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {

                    db.REGISTRAR_ORDEN(Order.Order_User_Id, Order.Order_total);
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

        public bool DeleteOrder(int Id)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var TOrder = db.Orders.Find(Id);

                    if (TOrder != null)
                    {
                        db.Orders.Remove(TOrder);
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
    }
}