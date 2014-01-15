using CatalogNHibernate;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDal
{
    public abstract class GenericDal<T> : IGenericDal<T>
    {
        public virtual T Get(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            T vo = session.Get<T>(id);
            NHibernateHelper.CloseSessionFactory();
            return vo;
        }
        public virtual List<T> GetByName(string name)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ICriteria criteria = session.CreateCriteria(typeof(T));
            criteria.Add(Expression.Like("Name", name, MatchMode.Anywhere));
            List<T> vos = (List<T>)criteria.List<T>();
            NHibernateHelper.CloseSessionFactory();
            return vos;
        }
        public virtual List<T> GetAll()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            List<T> vos = (List<T>)session.CreateCriteria(typeof(T)).List<T>();
            NHibernateHelper.CloseSessionFactory();
            return vos;
        }
        public virtual T SaveOrUpdate(T vo)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(vo);
                    transaction.Commit();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            NHibernateHelper.CloseSessionFactory();
            return vo;
        }
        public virtual void Delete(T vo)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Delete(vo);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            NHibernateHelper.CloseSessionFactory();
        }
    }
}
