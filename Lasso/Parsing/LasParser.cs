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
    public class LasParser : ILasParser<LasResult>
    {
        //section and data parser handle section and acii rows differently because the LAS
        //standard defines two different delimited row styles for the section data and ascii data.
        private ILasRowParser<LasSectionItem> _headerParser;
        private ILasRowParser<string[]> _dataParser;

        public LasParser()
        {
            _headerParser = new SectionRowParser();
            _dataParser = new DataRowParser();
        }

        /// <summary>
        /// Synchronous Parse method accepts stream as input. Returns LasResult on successful
        /// parse.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>LasResult</returns>
        public LasResult Parse(Stream stream) 
        {
            var result = new LasResult();
            try
            {
                using (TextReader tr = new StreamReader(stream))
                {
                    //state
                    LasSection currentSection = null;
                    bool atAsciiHeader = false;
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
                        }
                        else //else parse data in all sections 
                        {
                            currentSection.Items.Add(_headerParser.ParseRow(currentLine));
                        }
                    }
                    
                    //we're at the asci data section, parse the data rows! does not currently handled wrapped
                    //data rows.
                    while((currentLine = tr.ReadLine()) != null && atAsciiHeader)
                    {
                        currentLine = currentLine.Trim();
                        result.DataRows.LogAsciiData.Add(_dataParser.ParseRow(currentLine));
                    }
                }

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public LasResult ParseAsync(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
