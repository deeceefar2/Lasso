using LassoReader.Constants;
using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Factory
{
    public class SectionFactory : ISectionFactory
    {
        public LasSection GetSectionInstance(char section, LasResult result)
        {
            switch (char.ToUpper(section))
            {
                case Sections.VERSIONINFO:
                    return result.Version;
                case Sections.WELLINFO:
                    return result.Well;
                case Sections.PARAMETERINFO:
                    return result.Parameter;
                case Sections.OTHER:
                    return result.Other;
                case Sections.CURVEINFO:
                    return result.Curve;
                default:
                    throw new ArgumentException("Invalid Section");
            }
        }
    }
}
