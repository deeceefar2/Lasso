using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Models
{
    public class LasData
    {
        private Dictionary<string, List<string>> _data;
        public Dictionary<string, List<string>> LogData  
        { 
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }
}
