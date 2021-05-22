using Microsoft.EntityFrameworkCore;
using Net5.Fundamentals.EF.CodeFirst.Data.Contexts;
using Net5.Fundamentals.EF.CodeFirst.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.EF.CodeFirst.Data.Repositories.Base
{
    public class GenericRepository
    {
        internal Net5FundamentalsEFDatabaseContext _context;
        internal DbSet<Usuario> _usuarios;

        public GenericRepository(Net5FundamentalsEFDatabaseContext context)
        {
            _context = context;
            _usuarios = _context.Set<Usuario>();
        }

        public virtual List<Usuario> GertAll(
            Expression<Func<Usuario, bool>> filter = null,
            Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orderBy = null,
            string includeProperties = ""
        )
        {
            IQueryable<Usuario> query = _usuarios;

            if(filter != null)
            {

                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))                
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null){
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual Usuario GetById(object id)
        {
            return _usuarios.Find(id);
        }

        public virtual void Insert(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public virtual void Delete(object id)
        {            
            Usuario usuario  = _usuarios.Find(id);

        }
        public virtual void Delete(Usuario usuarioToDelete)
        {
            if (_context.Entry(usuarioToDelete).State == EntityState.Detached)
            {
                _usuarios.Attach(usuarioToDelete)
            }
        }
    }
}
