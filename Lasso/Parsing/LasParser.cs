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
        public LasResult Parse(Stream stream) 
        {
            var result = new LasResult();
            try
            {
                using (TextReader tr = new StreamReader(stream))
                {
                    bool atAsciiHeader = false;
                    LasSection currentSection = null;
                    ILasRowParser<LasSectionItem> sectionParser = null;

                    string currentLine;
                    char sectionIdentifier;

                    while ((currentLine = tr.ReadLine()) != null && !atAsciiHeader)
                    {
                        currentLine = currentLine.Trim();

                        if(currentLine.IndexOf(Delimiters.COMMENT) == 0)
                            continue; //skip comment lines

                        //we are at the beginning of a section lets find out what section
                        //and setup up the appropriate objects to grab the data
                        if(currentLine.IndexOf(Delimiters.SECTIONBEGIN) == 0)
                        {
                            if (currentLine.Length < 2)
                                throw new Exception("Missing section character.");

                            sectionIdentifier = currentLine[1];

                            if (sectionIdentifier.Equals(Sections.VERSIONINFO))
                                currentSection = result.Version;
                            if (sectionIdentifier.Equals(Sections.WELLINFO))
                                currentSection = result.Well;
                            if (sectionIdentifier.Equals(Sections.CURVEINFO))
                                currentSection = result.Curve;
                            if (sectionIdentifier.Equals(Sections.PARAMETERINFO))
                                currentSection = result.Parameter;
                            if (sectionIdentifier.Equals(Sections.OTHER))
                                currentSection = result.Other;
                            if(sectionIdentifier.Equals(Sections.ASCIIDATA))
                            {
                                atAsciiHeader = true;
                                break;
                            }
                            sectionParser = ParserFactory.GetParser<LasSectionItem>();
                        }
                        else //else parse data in all sections 
                        {
                            if(sectionParser != null)
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
                throw;
                //return new LasResult
                //{
                //    Error = ex.Message
                //};
            }
        }

        public LasResult ParseAsync(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
