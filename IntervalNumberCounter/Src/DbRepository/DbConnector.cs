using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IntervalNumberCounter.Src.DbRepository
{
    public class DbConnector
    {
        private string _path;

        private BinaryFormatter _binaryFormatter;

        public DbConnector ( string path )
        {
            _path = path;
            _binaryFormatter = new BinaryFormatter( );
        }

        private bool IsEmptyFile ( FileStream fileStream ) => fileStream.Length == 0;

        public DataBase Open ( )
        {
            using ( var fileStream = new FileStream( _path, FileMode.OpenOrCreate ) )
            {
                return IsEmptyFile( fileStream ) ? DbBuilder.Build() : _binaryFormatter.Deserialize( fileStream ) as DataBase;
            }
        }

        public void Save ( DataBase dataBase )
        {
            using ( var fileStream = new FileStream( _path, FileMode.Open ) )
            {
                _binaryFormatter.Serialize( fileStream, dataBase );
            }
        }
    }
}
