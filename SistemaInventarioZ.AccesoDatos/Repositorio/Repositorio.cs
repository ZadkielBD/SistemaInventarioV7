using Microsoft.EntityFrameworkCore;
using SistemaInventarioZ.AccesoDatos.Data;
using SistemaInventarioZ.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioZ.Modelos.Especificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task Agregar(T entidad)
        {
            await dbSet.AddAsync(entidad); // insert into Table
        }

        public async Task<T> Obtener(int id)
        {
            return await dbSet.FindAsync(id); // select * from (Solo por Id)
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null) 
            {
                query = query.Where(filtro); // select /* from where ...
            }
            if (incluirPropiedades != null)
            {
                foreach (var IncluirProp in incluirPropiedades.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncluirProp); // ejemplo "Categoria.Marca"
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query); // order by           
            }
            if (!isTracking)
            {
                query = query.AsNoTracking(); // select * from ... no tracking
            }
            return await query.ToListAsync();
        }

        public PagedList<T> ObtenerTodosPaginado(Parametros parametros, Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro); // select /* from where ...
            }
            if (incluirPropiedades != null)
            {
                foreach (var IncluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncluirProp); // ejemplo "Categoria.Marca"
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query); // order by           
            }
            if (!isTracking)
            {
                query = query.AsNoTracking(); // select * from ... no tracking
            }
            return PagedList<T>.ToPagedList(query, parametros.PageNuember, parametros.PageSize);
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro); // select /* from where ...
            }
            if (incluirPropiedades != null)
            {
                foreach (var IncluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncluirProp); // ejemplo "Categoria.Marca"
                }
            }
            if (!isTracking)
            {
                query = query.AsNoTracking(); // select * from ... no tracking
            }
            return await query.FirstOrDefaultAsync();
        }

        public void Remover(T entidad)
        {
            dbSet.Remove(entidad); // delete from Table where Id = entidad.Id
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad); // delete from Table where Id in (entidad.Id1, entidad.Id2...)
        }
    }
}
