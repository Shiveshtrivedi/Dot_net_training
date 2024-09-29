using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Management_System
{
    public class Book : Asset
    {
        public string Author { get; set; }
        public Book(string name, string author) : base(name)
        {
            Author = author;
        }

        public override string GetAssetType() => "Book";

    }

    public class SoftwareLicense : Asset
    {
        public string LicenseKey { get; set; }

        public SoftwareLicense(string name, string licenseKey) : base(name)
        {
            LicenseKey = licenseKey;
        }
        public override string GetAssetType() => "Software";
    }

    public class Hardware : Asset
    {
        public string Specification { get; set; }
        public Hardware(string name, string specification) : base(name)
        {
            Specification = specification;
        }
        public override string GetAssetType() => "Hardware";
    }
}
