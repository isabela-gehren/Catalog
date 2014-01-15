using CatalogNHibernate;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace CatalogDal
{
    public class BrandDal : IBrandDal
    {
        public BrandVO Get(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            BrandVO vo = session.Get<BrandVO>(id);
            NHibernateHelper.CloseSessionFactory();
            return vo;
        }

        public List<BrandVO> GetByName(string name)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ICriteria criteria = session.CreateCriteria(typeof(BrandVO));
            criteria.Add(Expression.Like("Name", name, MatchMode.Anywhere));
            List<BrandVO> vos = (List<BrandVO>)criteria.List<BrandVO>();
            NHibernateHelper.CloseSessionFactory();
            return vos;
        }

        public int SaveOrUpdate(BrandVO vo)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            session.SaveOrUpdate(vo);
            NHibernateHelper.CloseSessionFactory();
            return vo.Id;
        }

        public void Delete(BrandVO vo)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            session.Delete(vo);
            NHibernateHelper.CloseSessionFactory();
        }

        
    }
}
