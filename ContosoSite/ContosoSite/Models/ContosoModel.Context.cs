﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContosoSite.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AutoRentDatabaseEntitiesActual : DbContext
    {
        public AutoRentDatabaseEntitiesActual()
            : base("name=AutoRentDatabaseEntitiesActual")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autopark> Autopark { get; set; }
        public virtual DbSet<Fixes> Fixes { get; set; }
        public virtual DbSet<ModelTable> ModelTable { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<Rents> Rents { get; set; }
        public virtual DbSet<TechMessages> TechMessages { get; set; }
        public virtual DbSet<TypeTable> TypeTable { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    
        public virtual ObjectResult<Nullable<int>> Insert_User(string email, Nullable<int> phone, string password, string fIO)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var phoneParameter = phone.HasValue ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(int));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var fIOParameter = fIO != null ?
                new ObjectParameter("FIO", fIO) :
                new ObjectParameter("FIO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Insert_User", emailParameter, phoneParameter, passwordParameter, fIOParameter);
        }
    
        public virtual ObjectResult<LoginByEmailPassword_Result> LoginByEmailPassword(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoginByEmailPassword_Result>("LoginByEmailPassword", emailParameter, passwordParameter);
        }
    }
}
