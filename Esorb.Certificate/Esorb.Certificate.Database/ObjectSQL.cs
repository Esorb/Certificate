using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Database
{
    public class ObjectSQL : IObjectSQL
    {
        private string _Insert;
        private string _Update;
        private string _SelectById;
        private string _SelectAll;
        private string _DeleteById;
        private string _DeleteAll;
        private string _Count;
        private string _CreateTable;
        private string _DropTable;


        public ObjectSQL(String TableName, Dictionary<String, string> TableFields)
        {

            _Insert = CreateInsertStatement(TableName, TableFields);
            _Update = CreateUpdateStatement(TableName, TableFields);
            _SelectById = CreateSelectByIdStatement(TableName, TableFields);
            _SelectAll = CreateSelectAllStatement(TableName, TableFields);
            _DeleteById = "DELETE FROM " + TableName + " WHERE ID = @ID;";
            _DeleteAll = "DELETE FROM " + TableName + ";";
            _Count = "SELECT count(*) FROM " + TableName + ";";
            _CreateTable = CreateCreateTableStatement(TableName, TableFields);
            _DropTable = "DROP TABLE IF EXISTS " + TableName + ";";
        }


        public string Insert => _Insert;
        public string Update => _Update;
        public string SelectById => _SelectById;
        public string SelectAll => _SelectAll;
        public string DeleteById => _DeleteById;
        public string DeleteAll => _DeleteAll;
        public string Count => _Count;
        public string CreateTable => _CreateTable;
        public string DropTable => _DropTable;


        private string CreateInsertStatement(String TableName, Dictionary<String, string> TableFields)
        {
            StringBuilder sB = new StringBuilder();

            sB.Append("INSERT INTO ").Append(TableName).Append(" (ID, ");
            sB.Append(GetFieldListCommaSeparated(TableFields, false, ""));
            sB.Append(") VALUES (@ID, ");
            sB.Append(GetFieldListCommaSeparated(TableFields, false, "@"));
            sB.Append(");");

            Console.WriteLine(sB.ToString());

            return sB.ToString();
        }


        private string CreateUpdateStatement(String TableName, Dictionary<String, string> TableFields)
        {
            StringBuilder sB = new StringBuilder();

            sB.Append("UPDATE ").Append(TableName).Append(" SET ");
            sB.Append(GetSetFieldListCommaSeparated(TableFields));
            sB.Append(" WHERE ID = @ID;");

            return sB.ToString();
        }


        private string CreateSelectByIdStatement(String TableName, Dictionary<String, string> TableFields)
        {
            StringBuilder sB = new StringBuilder();

            sB.Append("SELECT ");
            sB.Append(GetFieldListCommaSeparated(TableFields, true, ""));
            sB.Append(" FROM ");
            sB.Append(TableName);
            sB.Append(" WHERE ID = @ID;");

            return sB.ToString();
        }


        private string CreateSelectAllStatement(String TableName, Dictionary<String, string> TableFields)
        {
            StringBuilder sB = new StringBuilder();

            sB.Append("SELECT ");
            sB.Append(GetFieldListCommaSeparated(TableFields, true, ""));
            sB.Append(" FROM ");
            sB.Append(TableName);
            sB.Append(";");

            return sB.ToString();
        }


        private string CreateCreateTableStatement(String TableName, Dictionary<String, string> TableFields)
        {
            StringBuilder sB = new StringBuilder();

            sB.Append("CREATE TABLE IF NOT EXISTS '").Append(TableName);
            sB.Append("' ( 'ID' TEXT PRIMARY KEY, ");
            sB.Append(GetFieldTypeListCommaSeparated(TableFields)).Append(" );");

            return sB.ToString();
        }


        private string GetFieldListCommaSeparated(Dictionary<String, string> TableFields, bool withID, string At)
        {
            StringBuilder sB = new StringBuilder();

            if (withID)
            {
                sB.Append("ID, ");
            }

            int max = TableFields.Count;
            int pos = 1;

            foreach (var field in TableFields)
            {
                sB.Append(At).Append(field.Key);
                if (pos < max)
                {
                    sB.Append(", ");
                    pos++;
                };
            }

            return sB.ToString();
        }


        private string GetFieldTypeListCommaSeparated(Dictionary<String, string> TableFields)
        {
            StringBuilder sB = new StringBuilder();

            int max = TableFields.Count;
            int pos = 1;

            foreach (var field in TableFields)
            {
                sB.Append("'").Append(field.Key).Append("' ").Append(field.Value);
                if (pos < max)
                {
                    sB.Append(", ");
                    pos++;
                };
            }

            return sB.ToString();
        }


        private string GetSetFieldListCommaSeparated(Dictionary<String, string> TableFields)
        {
            StringBuilder sB = new StringBuilder();

            int max = TableFields.Count;
            int pos = 1;

            foreach (var field in TableFields)
            {
                sB.Append(field.Key).Append(" = @").Append(field.Key);
                if (pos < max)
                {
                    sB.Append(", ");
                    pos++;
                };
            }

            return sB.ToString();
        }
    }
}
