using LassoReader.Constants;
using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LassoReader.Utility;
using System.Linq;
using System.Text;
using LassoReader.Factory;

namespace LassoReader.Parsing
{
    public class LasParser : ILasParser
    {
      
        private ISectionFactory _sectionFactory;

        public LasParser()
        {
            _sectionFactory = new SectionFactory();
        }

        public LasResult Parse(Stream stream) 
        {
            var result = new LasResult();
            try
            {
                using (TextReader tr = new StreamReader(stream))
                {
                    LasSection currentSection = null;
                    SectionRowParser sectionParser = null;
                    DataRowParser dataParser = null;

                    string currentLine;
                    while ((currentLine = tr.ReadLine()) != null)
                    {
                        currentLine = currentLine.Trim();

                        if(currentLine.IndexOf(Delimiters.COMMENT) == 0)
                            continue; //skip comment lines

                        if(currentLine.IndexOf(Delimiters.SECTIONBEGIN) == 0)
                        {
                            var sectionIdentifier = currentLine[1];

                            if(sectionIdentifier.Equals(Sections.ASCIIDATA))
                            {
                                dataParser = new DataRowParser(result.Curve);
                                sectionParser = null;
                            }
                            else
                            {
                                currentSection = _sectionFactory.GetSectionInstance(sectionIdentifier, result);
                                sectionParser = new SectionRowParser();
                                dataParser = null;
                            }
                        }
                        else
                        {
                            if(dataParser != null)
                            {
                                result.Data.LogData = dataParser.ParseRow(currentLine);
                            }
                            else if(sectionParser != null)
                            {
                                currentSection.Items.Add(sectionParser.ParseRow(currentLine));
                            }
                            
                        }

                    }
                }

                return result;
            }
            catch(Exception ex)
            {
                return new LasResult
                {
                    Error = ex.Message
                };
            }
        }

        public LasResult ParseAsync(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
