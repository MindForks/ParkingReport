using Microsoft.EntityFrameworkCore;
using PR.Entities;
using PR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PR.Data.Repositories
{
    public class ReportRepository : IRepository<Report>
    {
        private readonly DbSet<Report> db;
        private readonly PRDbContext context;
        public ReportRepository(PRDbContext context)
        {
            this.context = context;
            db = this.context.Set<Report>();
        }

        public void Create(Report item)
        {
            db.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Find(id);
            if (item != null)
                db.Remove(item);
        }

        public IEnumerable<Report> GetAll()
        {
            return db;
        }

        public IEnumerable<Report> Filter(Expression<Func<Report, bool>> predicate)
        {
            return GetAllQuery()
                .Where(predicate)
                .ToList();
        }

        public Report GetItem(int id)
        {
            return db.Find(id);
        }

        public void Update(Report item)
        {
            db.Update(item);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private IQueryable<Report> GetAllQuery()
        {
            return db;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
