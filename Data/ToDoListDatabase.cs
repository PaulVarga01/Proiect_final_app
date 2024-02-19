using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Proiect_final_app.Models;

namespace Proiect_final_app.Data
{
    public class ToDoListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ToDoListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ToDoList>().Wait();
        }
        public Task<List<ToDoList>> GetToDoListsAsync()
        {
            return _database.Table<ToDoList>().ToListAsync();
        }
        public Task<ToDoList> GetToDoListAsync(int id)
        {
            return _database.Table<ToDoList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveToDoListAsync(ToDoList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteToDoListAsync(ToDoList slist)
        {
            return _database.DeleteAsync(slist);
        }

    }
}
