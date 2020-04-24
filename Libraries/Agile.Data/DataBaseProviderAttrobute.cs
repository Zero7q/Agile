using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Data
{
    public class DataBaseProviderAttrobute : Attribute
    {
        public DataProviderType DataProviderType { get; set; }

        public DataBaseProviderAttrobute(DataProviderType dataProviderType)
        {
            DataProviderType = dataProviderType;
        }
    }
}
