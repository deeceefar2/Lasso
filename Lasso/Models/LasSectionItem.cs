using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Models
{
    public class LasSectionItem
    {
        public LasSectionItem()
        {
        }

        public string Mnemonic { get; set; }
        public string Unit { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }
    }
}
