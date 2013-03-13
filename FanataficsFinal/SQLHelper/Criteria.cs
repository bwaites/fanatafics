using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLHelper
{
    public class Criteria
    {
        #region Private Members
        private string _TableName = string.Empty;
        private List<string> _Fields = new List<string>();
        private List<string> _Values = new List<string>();
        private List<DataTypeHelper.Type.DataType> _Types = new List<DataTypeHelper.Type.DataType>();
        #endregion

        #region Public Properties
        public string TableName { get { return _TableName; } set { _TableName = value; } }
        public List<string> Fields { get { return _Fields; } }
        public List<string> Values { get { return _Values; } }
        public List<DataTypeHelper.Type.DataType> Types { get { return _Types; } }
        #endregion
    }
}
