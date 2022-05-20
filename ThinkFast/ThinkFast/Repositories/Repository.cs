using SQLite;
using ThinkFast.Models;
using ThinkFast.Models.Games;

namespace ThinkFast.Repositories
{
    public class Repository
    {
        private readonly SQLiteConnection database;
        public Repository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Result>();
            database.CreateTable<ExampleRepeat>();
            //database.CreateTable<Rate>();

            Result = new RepositoryBase<Result>(database);
            ExampleRepeat = new RepositoryBase<ExampleRepeat>(database);
        }
        
        public IRepositoryBase<Result> Result;
        public IRepositoryBase<ExampleRepeat> ExampleRepeat;


        //public bool CheckRate()
        //{
        //    return database.Table<Rate>().Any();
        //}

        //public int SaveRate()
        //{

        //    return database.Insert(new Rate());
        //}
    }
}