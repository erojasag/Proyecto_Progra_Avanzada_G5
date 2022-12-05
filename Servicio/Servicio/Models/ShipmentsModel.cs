using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Servicio.Models
{
    public class ShipmentsModel
    {
        public List<Shipments> ViewShipments()
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var tshipments = db.Shipments.ToList();
                    List<Shipments> shipments = new List<Shipments>();

                    foreach (var shipment in tshipments)
                    {
                        shipments.Add(new Shipments
                        {
                            shipment_id = shipment.shipment_id,
                            shipment_order_id = shipment.shipment_order_id,
                            shipment_date = shipment.shipment_date,
                            shipment_status = shipment.shipment_status,
                            shipment_address = shipment.shipment_address,
                            shipment_city = shipment.shipment_city,
                            shipment_state = shipment.shipment_state,
                            shipment_zip_code = shipment.shipment_zip_code,
                            shipment_country = shipment.shipment_country,
                            shipment_phone = shipment.shipment_phone,
                            shipment_email = shipment.shipment_email,
                            shipment_customer_id = shipment.shipment_customer_id

                        });
                    }

                    if (shipments.Count == 0)
                    {
                        throw new Exception("No shipping found");
                    }
                    else
                    {
                        return shipments;
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public Shipments ViewShipmentsById(int Id)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var tshipments = db.Shipments.Find(Id);
                    Shipments shipment = new Shipments();
                    if (tshipments != null)
                    {
                        shipment.shipment_id = tshipments.shipment_id;
                        shipment.shipment_order_id = tshipments.shipment_order_id;
                        shipment.shipment_date = tshipments.shipment_date;
                        shipment.shipment_status = tshipments.shipment_status;
                        shipment.shipment_address = tshipments.shipment_address;
                        shipment.shipment_city = tshipments.shipment_city;
                        shipment.shipment_state = tshipments.shipment_state;
                        shipment.shipment_zip_code = tshipments.shipment_zip_code;
                        shipment.shipment_country = tshipments.shipment_country;
                        shipment.shipment_phone = tshipments.shipment_phone;
                        shipment.shipment_email = tshipments.shipment_email;
                        shipment.shipment_customer_id = tshipments.shipment_customer_id; 
                
                        return shipment;
                    }
                    else
                    {
                        throw new Exception("No se han encontrado registros con el id" + " " + Id);
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool InsertShipment(Shipments shipment)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    Shipments TablaShipments = new Shipments();
                    TablaShipments.shipment_order_id = shipment.shipment_order_id;
                    TablaShipments.shipment_date = shipment.shipment_date;
                    TablaShipments.shipment_status = shipment.shipment_status;
                    TablaShipments.shipment_address = shipment.shipment_address;
                    TablaShipments.shipment_city = shipment.shipment_city;
                    TablaShipments.shipment_state = shipment.shipment_state;
                    TablaShipments.shipment_zip_code = shipment.shipment_zip_code;
                    TablaShipments.shipment_country = shipment.shipment_country;
                    TablaShipments.shipment_phone = shipment.shipment_phone;
                    TablaShipments.shipment_email = shipment.shipment_email;
                    TablaShipments.shipment_customer_id = shipment.shipment_customer_id;


                    db.Shipments.Add(TablaShipments);
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
        public bool EditShipments(Shipments shipment)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var tshipment = (from x in db.Shipments
                                      where x.shipment_id == shipment.shipment_id
                                     select x).FirstOrDefault();

                    if (tshipment != null)
                    {
                            tshipment.shipment_order_id = shipment.shipment_order_id;
                            tshipment.shipment_date = shipment.shipment_date;
                            tshipment.shipment_status = shipment.shipment_status;
                            tshipment.shipment_address = shipment.shipment_address;
                            tshipment.shipment_city = shipment.shipment_city;
                            tshipment.shipment_state = shipment.shipment_state;
                            tshipment.shipment_zip_code = shipment.shipment_zip_code;
                            tshipment.shipment_country = shipment.shipment_country;
                            tshipment.shipment_phone = shipment.shipment_phone;
                            tshipment.shipment_email = shipment.shipment_email;
                            tshipment.shipment_customer_id = shipment.shipment_customer_id;
                            db.SaveChanges();
                            return true;
                        }
                        else
                            throw new Exception("This does not exist");
                    }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool DeleteShipment(int Id)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var tshipment = (from x in db.Shipments
                                     where x.shipment_id == Id
                                     select x).FirstOrDefault();

                    if (tshipment != null)
                    {
                        db.Shipments.Remove(tshipment);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se pudo eliminar el envío");
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