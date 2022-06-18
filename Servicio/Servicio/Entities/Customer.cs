﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Entities
{
    public class Customer
    {
        public int user_Id { get; set; }
        public string login_name_customer { get; set; }
        public string password_hash_customer { get; set; }
        public string name { get; set; }
        public string first_last_name { get; set; }
        public string second_last_name { get; set; }
        public int Id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public System.DateTime registration_date { get; set; }
        public System.DateTime birth_date { get; set; }
        public string customer_photo { get; set; }
        public string address { get; set; }

    }

    public class Respuesta
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool transaccion { get; set; }
        public Customer customer { get; set; }
        public List<Customer> customers { get; set; }
    }
}