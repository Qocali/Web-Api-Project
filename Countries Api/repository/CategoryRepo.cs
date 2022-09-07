using Countries_Api.DAL;
using Countries_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Countries_Api.repository
{
    public class CategoryRepo : IRepo<category>
    {
        private readonly AppDbContext _Db;
        public CategoryRepo(AppDbContext Db)
        {
            _Db = Db;
        }
         public IEnumerable<category> GetAll()
        {
           return _Db.Categorys.ToList() ;
        }

        public category GetbyId(int? id)
        {
            return _Db.Categorys.FirstOrDefault(x => x.Id == id);
        }

        public void Delate(int? id)
        {
            category cat=_Db.Categorys.FirstOrDefault(x => x.Id == id);
            if (cat.IsDeactive)
            {
                cat.IsDeactive = false;
            }
            else
            {
                cat.IsDeactive = true;
            }
            _Db.SaveChanges();
        }

        public void Create(category category)
        {
             _Db.Categorys.AddAsync(category);
            _Db.SaveChanges();
        }
        public void Update(int? id,category category)
        {
            category categorydb=_Db.Categorys.FirstOrDefault(x=>x.Id==id);
            categorydb.Name = category.Name;
           
            _Db.SaveChanges();
        }
    }
}
