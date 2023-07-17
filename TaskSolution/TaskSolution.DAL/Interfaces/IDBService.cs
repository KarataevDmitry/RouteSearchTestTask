using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSolution.DAL.Interfaces;
public interface IDBService<T> : IAsyncDBService<T> where T : class
{
    int Add(T item);
    T? Get(int Id);
    void Delete(int Id);
    IEnumerable<T>? GetAll();
    void Save();
    T Edit(T changed);

}
