using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	// burada yazdıgım T  bir clasa tüm degerleri kullanacak
	public interface IGenericDal<T> where T : class
	{
		void Insert(T t);
		void Delete(T t);
		void Update(T t);
		List<T> GetListAll(); // tümünü getirir
		T GetByID(int id);  // id ye göre getirir
		List<T> GetListAll(Expression<Func<T, bool>> filter); // özellikle şartlı sorgulamalarda kullanılır
	}
}
