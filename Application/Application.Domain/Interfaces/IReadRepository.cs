using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Interfaces
{
    public interface IReadRepository<T>
    {
        List<T> ReadAllItems();
        List<T> ReadActiveItems();
        T GetItemById(int id);
    }
}
