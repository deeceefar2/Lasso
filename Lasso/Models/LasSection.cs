using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Models
{
    public class LasSection
    {
        private List<LasSectionItem> _items = new List<LasSectionItem>();
        public List<LasSectionItem> Items 
        { 
            get { return _items; } 
            set { _items = value; } 
        }
    }
}
