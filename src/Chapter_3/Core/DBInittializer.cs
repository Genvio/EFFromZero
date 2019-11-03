using System;
using System.Data.Entity;

namespace Chapter_3.Core
{
    //CreateDatabaseIfNotExists - проверяет соответсвие таблиц моделям, если есть несоответсвие - исколючение
    //DropCreateDatabaseIfModelChanges                                                          - пересоздает базу
    //DropCreateDatabaseAlways - всегда пересоздает базу
    public class DBInittializer : CreateDatabaseIfNotExists<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            //once
            context.Runs.Add(new DateTimeOfRun { RecDate = DateTime.Now });
        }
    }
}
