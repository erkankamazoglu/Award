using AwardEntity.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore; 
using System.Linq.Expressions; 
using Utility.ConfigurationFile; 

namespace Dal
{
    public abstract class BaseCrudDal<TEntity> : IBaseDal<TEntity> where TEntity : BaseEntity
    { 
        public IEnumerable<TEntity> GetAll()
        {
            return GetAll(null, null);
        }

        public IEnumerable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>>? predicates)
        {
            return GetAll(predicates, null);
        }

        public IEnumerable<TEntity> GetAll(List<string> includes)
        {
            return GetAll(null, includes);
        }

        public virtual IEnumerable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>>? predicates, List<string>? includes)
        {
            IEnumerable<TEntity> entities;
            try
            {
                using (SqlConnection conn = new(ConfigurationFileHelper.GetDefaultConnectionString()))
                {
                    conn.Open(); 
                    using (ModelContext context = new(conn))
                    { 
                        IQueryable<TEntity> queryable = context.Set<TEntity>(); 

                        if (predicates != null)
                        {
                            foreach (var predicate in predicates)
                            {
                                queryable = queryable.Where(predicate);
                            }
                        }

                        if (includes != null)
                        {
                            foreach (string include in includes)
                            {
                                queryable = queryable.Include(include);
                            }
                        }

                        entities = queryable.ToList();
                    } 
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return entities;
        }

        public virtual TEntity? GetById(int id)
        {
            return GetById(id, null);
        }

        public virtual TEntity? GetById(int id, List<string> includes)
        {
            TEntity? entity = GetAll(new List<Expression<Func<TEntity, bool>>>
            {
                i => i.Id == id
            }, includes).FirstOrDefault(); 
            return entity;
        }

        public virtual void Add(TEntity entity)
        { 
            using (SqlConnection conn = new(ConfigurationFileHelper.GetDefaultConnectionString()))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        using (ModelContext context = new(conn))
                        {
                            context.Database.UseTransaction(sqlTran);

                            entity.AddDate = DateTime.Now;
                            context.Set<TEntity>().Add(entity);
                            context.SaveChanges();
                        }

                        sqlTran.Commit();
                    }
                    catch (Exception e)
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (SqlConnection conn = new(ConfigurationFileHelper.GetDefaultConnectionString()))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        using (ModelContext context = new(conn))
                        {
                            context.Database.UseTransaction(sqlTran);

                            entity.UpdateDate = DateTime.Now;
                            context.Set<TEntity>().Update(entity);
                            context.SaveChanges();
                        }
                        sqlTran.Commit();
                    }
                    catch (Exception e)
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
        }

        public virtual void Delete(int id)
        {
            using (SqlConnection conn = new(ConfigurationFileHelper.GetDefaultConnectionString()))
            {
                conn.Open();
                using (SqlTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        using (ModelContext context = new(conn))
                        {
                            context.Database.UseTransaction(sqlTran);

                            TEntity entity = context.Set<TEntity>().Find(id);
                            if (entity != null)
                            {
                                context.Set<TEntity>().Remove(entity);
                                context.SaveChanges();
                            }
                        }
                        sqlTran.Commit();
                    }
                    catch (Exception e)
                    {
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}