//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio.Entities
{
    using System;
    
    public partial class MOSTRAR_ORDENES_Result
    {
        public int Id { get; set; }
        public System.Guid Order_User_Id { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public System.DateTime Order_date { get; set; }
        public decimal Order_total { get; set; }
    }
}