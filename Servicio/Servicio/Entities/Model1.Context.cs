﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SHOECORP_BDEntities : DbContext
    {
        public SHOECORP_BDEntities()
            : base("name=SHOECORP_BDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Product_By_Order> Product_By_Order { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Shipments> Shipments { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ERRORES> ERRORES { get; set; }
    
        public virtual int ACTUALIZAR_CONTRASENIA(Nullable<System.Guid> v_ID, string pASSWORD)
        {
            var v_IDParameter = v_ID.HasValue ?
                new ObjectParameter("V_ID", v_ID) :
                new ObjectParameter("V_ID", typeof(System.Guid));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZAR_CONTRASENIA", v_IDParameter, pASSWORDParameter);
        }
    
        public virtual int ACTUALIZAR_USUARIO(Nullable<System.Guid> v_ID, string v_NAME, string v_FLASTNAME, string v_SLASTNAME, Nullable<int> iD_ROL, string tEL, string v_EMAIL, byte[] v_PHOTO, string v_ADRESS)
        {
            var v_IDParameter = v_ID.HasValue ?
                new ObjectParameter("V_ID", v_ID) :
                new ObjectParameter("V_ID", typeof(System.Guid));
    
            var v_NAMEParameter = v_NAME != null ?
                new ObjectParameter("V_NAME", v_NAME) :
                new ObjectParameter("V_NAME", typeof(string));
    
            var v_FLASTNAMEParameter = v_FLASTNAME != null ?
                new ObjectParameter("V_FLASTNAME", v_FLASTNAME) :
                new ObjectParameter("V_FLASTNAME", typeof(string));
    
            var v_SLASTNAMEParameter = v_SLASTNAME != null ?
                new ObjectParameter("V_SLASTNAME", v_SLASTNAME) :
                new ObjectParameter("V_SLASTNAME", typeof(string));
    
            var iD_ROLParameter = iD_ROL.HasValue ?
                new ObjectParameter("ID_ROL", iD_ROL) :
                new ObjectParameter("ID_ROL", typeof(int));
    
            var tELParameter = tEL != null ?
                new ObjectParameter("TEL", tEL) :
                new ObjectParameter("TEL", typeof(string));
    
            var v_EMAILParameter = v_EMAIL != null ?
                new ObjectParameter("V_EMAIL", v_EMAIL) :
                new ObjectParameter("V_EMAIL", typeof(string));
    
            var v_PHOTOParameter = v_PHOTO != null ?
                new ObjectParameter("V_PHOTO", v_PHOTO) :
                new ObjectParameter("V_PHOTO", typeof(byte[]));
    
            var v_ADRESSParameter = v_ADRESS != null ?
                new ObjectParameter("V_ADRESS", v_ADRESS) :
                new ObjectParameter("V_ADRESS", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZAR_USUARIO", v_IDParameter, v_NAMEParameter, v_FLASTNAMEParameter, v_SLASTNAMEParameter, iD_ROLParameter, tELParameter, v_EMAILParameter, v_PHOTOParameter, v_ADRESSParameter);
        }
    
        public virtual ObjectResult<DESENCRIPTAR_CONTRA_Result> DESENCRIPTAR_CONTRA(string v_USER, string pASSWORD)
        {
            var v_USERParameter = v_USER != null ?
                new ObjectParameter("V_USER", v_USER) :
                new ObjectParameter("V_USER", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DESENCRIPTAR_CONTRA_Result>("DESENCRIPTAR_CONTRA", v_USERParameter, pASSWORDParameter);
        }
    
        public virtual int FORGOT_PASS(string eMAIL)
        {
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FORGOT_PASS", eMAILParameter);
        }
    
        public virtual ObjectResult<MOSTRAR_ORDEN_PORID_Result> MOSTRAR_ORDEN_PORID(Nullable<int> v_ID_ORDEN)
        {
            var v_ID_ORDENParameter = v_ID_ORDEN.HasValue ?
                new ObjectParameter("V_ID_ORDEN", v_ID_ORDEN) :
                new ObjectParameter("V_ID_ORDEN", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MOSTRAR_ORDEN_PORID_Result>("MOSTRAR_ORDEN_PORID", v_ID_ORDENParameter);
        }
    
        public virtual ObjectResult<MOSTRAR_ORDENES_Result> MOSTRAR_ORDENES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MOSTRAR_ORDENES_Result>("MOSTRAR_ORDENES");
        }
    
        public virtual int REGISTRAR_ORDEN(Nullable<System.Guid> v_ID_USUARIO, Nullable<decimal> v_MONTO)
        {
            var v_ID_USUARIOParameter = v_ID_USUARIO.HasValue ?
                new ObjectParameter("V_ID_USUARIO", v_ID_USUARIO) :
                new ObjectParameter("V_ID_USUARIO", typeof(System.Guid));
    
            var v_MONTOParameter = v_MONTO.HasValue ?
                new ObjectParameter("V_MONTO", v_MONTO) :
                new ObjectParameter("V_MONTO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("REGISTRAR_ORDEN", v_ID_USUARIOParameter, v_MONTOParameter);
        }
    
        public virtual int REGISTRAR_USUARIO(string v_CED, string v_NAME, string v_FLASTNAME, string v_SLASTNAME, Nullable<int> iD_ROL, string v_USER, string pASSWORD, Nullable<System.DateTime> dOB, string tEL, string v_EMAIL, byte[] v_PHOTO, string v_ADRESS)
        {
            var v_CEDParameter = v_CED != null ?
                new ObjectParameter("V_CED", v_CED) :
                new ObjectParameter("V_CED", typeof(string));
    
            var v_NAMEParameter = v_NAME != null ?
                new ObjectParameter("V_NAME", v_NAME) :
                new ObjectParameter("V_NAME", typeof(string));
    
            var v_FLASTNAMEParameter = v_FLASTNAME != null ?
                new ObjectParameter("V_FLASTNAME", v_FLASTNAME) :
                new ObjectParameter("V_FLASTNAME", typeof(string));
    
            var v_SLASTNAMEParameter = v_SLASTNAME != null ?
                new ObjectParameter("V_SLASTNAME", v_SLASTNAME) :
                new ObjectParameter("V_SLASTNAME", typeof(string));
    
            var iD_ROLParameter = iD_ROL.HasValue ?
                new ObjectParameter("ID_ROL", iD_ROL) :
                new ObjectParameter("ID_ROL", typeof(int));
    
            var v_USERParameter = v_USER != null ?
                new ObjectParameter("V_USER", v_USER) :
                new ObjectParameter("V_USER", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            var dOBParameter = dOB.HasValue ?
                new ObjectParameter("DOB", dOB) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            var tELParameter = tEL != null ?
                new ObjectParameter("TEL", tEL) :
                new ObjectParameter("TEL", typeof(string));
    
            var v_EMAILParameter = v_EMAIL != null ?
                new ObjectParameter("V_EMAIL", v_EMAIL) :
                new ObjectParameter("V_EMAIL", typeof(string));
    
            var v_PHOTOParameter = v_PHOTO != null ?
                new ObjectParameter("V_PHOTO", v_PHOTO) :
                new ObjectParameter("V_PHOTO", typeof(byte[]));
    
            var v_ADRESSParameter = v_ADRESS != null ?
                new ObjectParameter("V_ADRESS", v_ADRESS) :
                new ObjectParameter("V_ADRESS", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("REGISTRAR_USUARIO", v_CEDParameter, v_NAMEParameter, v_FLASTNAMEParameter, v_SLASTNAMEParameter, iD_ROLParameter, v_USERParameter, pASSWORDParameter, dOBParameter, tELParameter, v_EMAILParameter, v_PHOTOParameter, v_ADRESSParameter);
        }
    }
}
