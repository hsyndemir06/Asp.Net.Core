using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        // sadece bloglara ait bir metot oldugu icin burda yazdım
        // category.categoryname getirebilmek icin
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);

    }
}
