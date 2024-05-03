using System;
using System.Linq;
using System.Reflection;

namespace IntervalNumberCounter.Src.DbRepository
{
    public static class DbBuilder
    {
        public static DataBase Build ( )
        {
            var @namespace = "IntervalNumberCounter.Src.Models.Tables";

            var typesInNamespace = Assembly.GetExecutingAssembly( ).GetTypes( )
               .Where( t => t.Namespace == @namespace );

            var dataBase = new DataBase( );

            var tableProperties = dataBase.GetType( ).GetProperties( );

            foreach ( var property in tableProperties )
            {
                var selectedType = typesInNamespace.Where( t => t.Name == property.Name ).First();
                var table = Activator.CreateInstance( selectedType ); /// cоздаёт объект таблицы
                property.SetValue( dataBase, table );
            }

            return dataBase;
        }
    }
}
