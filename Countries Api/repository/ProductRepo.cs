using Countries_Api.DAL;
using Countries_Api.Models;

namespace Countries_Api.repository
{
    public class ProductRepo:IRepo<product>
    {
        private readonly AppDbContext _Db;
        public ProductRepo(AppDbContext Db)
        {
            _Db = Db;
        }
        public IEnumerable<product> GetAll()
        {
            return _Db.Products.ToList();
        }

        public product GetbyId(int? id)
        {
            return _Db.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Delate(int? id)
        {
            product cat = _Db.Products.FirstOrDefault(x => x.Id == id);
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

        public void Create(product product)
        {
            _Db.Products.AddAsync(product);
            _Db.SaveChanges();
        }
        public void Update(int? id, product product)
        {
            product productdb = _Db.Products.FirstOrDefault(x => x.Id == id);
            productdb.Name = product.Name;

            _Db.SaveChanges();
        }
    }
}
