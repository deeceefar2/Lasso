using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Factory
{
    public interface ISectionFactory
    {
        LasSection GetSectionInstance(char section, LasResult result);
    }
}
