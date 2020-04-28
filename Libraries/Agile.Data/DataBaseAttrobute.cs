using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Data
{
    public class DataBaseAttrobute : Attribute
    {
        public DataProviderType DataProviderType { get; set; }

        public DataBaseAttrobute(DataProviderType dataProviderType)
        {
            DataProviderType = dataProviderType;
        }
    }
}
