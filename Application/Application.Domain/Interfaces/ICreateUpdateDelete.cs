using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Interfaces
{
	public interface ICreateUpdateDelete<T>
	{
		void CreateItem(T item);
		void UpdateItem(T item);
		void DeleteItem(int itemId);
	}
}
