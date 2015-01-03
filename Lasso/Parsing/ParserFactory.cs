using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LassoReader.Parsing
{
    public static class ParserFactory
    {
        public static ILasRowParser<T> GetParser<T>()
        {
            Type t = typeof(T);

            if (t == typeof(LasSectionItem))
                return (ILasRowParser<T>)new SectionRowParser();
            if (t == typeof(DataRowParser))
                return (ILasRowParser<T>)new DataRowParser();

            return null;

        }
    }
}
