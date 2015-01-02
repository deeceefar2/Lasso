using LassoReader.Constants;
using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LassoReader.Utility;

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
                    string currentLine;
                    while ((currentLine = tr.ReadLine()) != null)
                    {
                        if (currentLine.Contains(Sections.COMMENT))
                            continue;

                        currentLine = currentLine.RemoveWhiteSpace();

                        string currentSection;
                        if(currentLine.Contains(Sections.SECTIONBEGIN))
                        {
                            currentSection = currentLine[1].ToString();
                            if(currentSection.Equals(Sections.VERSIONINFO, StringComparison.OrdinalIgnoreCase))
                            {
                                while((currentLine = tr.ReadLine()) != null)
                                {
                                   //result.Version.Items.Add(ParseSectionRow(currentLine));
                                }
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

        /// <summary>
        /// Three line delimiters are used in the "~V", "~W", "~C", and "~P" sections of LAS files. The line delimiters
        /// are as follows:
        /// a) the first dot in a line,
        /// b) the first space after the first dot in a line
        /// c) the last colon in a line 
        /// EXAMPLE: 
        ///     STEP  .FT         0.20                           : STEP
        ///     STRT  .FT         7900.00                        : START DEPTH
        //      STOP  .FT         8400.00                        : STOP DEPTH
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public LasSectionItem ParseSectionRow(string row)
        {
            var rowItem = new LasSectionItem();

            for (int i = 0; i < row.Length-1; i++)
            {
                //get mnemonic
                while(!char.Equals(row[i], Sections.DOT))
                {
                    if (!char.IsWhiteSpace(row[i]))
                    {
                        rowItem.Mnemonic += row[i];
                    }
                    i++;
                }

                //advance index off of '.'
                i++;
                
                //get units
                while (!char.IsWhiteSpace(row[i]))
                {
                    rowItem.Unit += row[i];
                    i++;
                }

                //get data
                while (!char.Equals(row[i], Sections.COLON))
                {
                    if (!char.IsWhiteSpace(row[i]))
                    {
                        rowItem.Data += row[i];
                    }
                    i++;
                }

                //advance index off of ':'
                i++;

                //get description

                break;
            }
            return rowItem;
        }

        public LasData ParseDataRow(string row)
        {
            throw new NotImplementedException();
        }
    }
}
