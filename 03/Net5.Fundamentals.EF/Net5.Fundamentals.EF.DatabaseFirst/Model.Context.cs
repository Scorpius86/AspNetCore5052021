//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Net5.Fundamentals.EF.DatabaseFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    
        public virtual ObjectResult<uspListPost_Result> uspListPost()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspListPost_Result>("uspListPost");
        }
    }
}
