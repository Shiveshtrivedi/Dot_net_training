using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Management_System
{
    public abstract class Asset
    {
        public string Name { get; set; }

        public Asset(string name)
        {
            Name = name;
        }

        public abstract string GetAssetType();
    }
}
