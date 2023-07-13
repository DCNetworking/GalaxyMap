using System;
namespace GalaxyMap.Utilities
{

    public class CreateTable : Attribute
    {
        public string Name { get; private set; }
        public CreateTable(string name)
        {
            Name = name;
        }
    }
    public class TableColumn : Attribute
    {
        public string Name { get; private set; }
        public SQLColumnType SQLColumnType { get; private set; }
        public SQLKeyType SQLKeyType { get; private set; }
        public TableColumn(string name, SQLColumnType sQLColumnType, SQLKeyType sQLKeyType)
        {
            Name = name;
            SQLColumnType = SQLColumnType;
            SQLKeyType = sQLKeyType;
        }
    }
}

