using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ProductID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ProductID);
                product.ProductCode = entity.ProductCode;
                product.ProductName = entity.ProductName;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.ProductImage = entity.ProductImage;
                product.MoreImages = entity.MoreImages;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.IncludeVAT = entity.IncludeVAT;
                product.Quantity = entity.Quantity;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                product.Warranty = entity.Warranty;
                product.CreatedBy = entity.CreatedBy;
                product.ModifiedDate = DateTime.Now;
                product.ModifiedBy = entity.ModifiedBy;
                product.MetaKeywords = entity.MetaKeywords;
                product.MetaDescriptions = entity.MetaDescriptions;
                product.Status = entity.Status;
                product.TopHot = entity.TopHot;
                product.ViewCounts = entity.ViewCounts;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ProductName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
    }
}
