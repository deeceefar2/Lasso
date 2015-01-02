using LassoReader.Constants;
using LassoReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LassoReader.Utility;
using System.Linq;
using System.Text;

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
                        if (currentLine.Contains(Delimiters.COMMENT))
                            continue;

                        currentLine = currentLine.RemoveWhiteSpace();

                        string currentSection;
                        if(currentLine.Contains(Delimiters.SECTIONBEGIN))
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
        ///      STOP  .FT         8400.00                        : STOP DEPTH
        /// MNEM = mnemonic. This mnemonic can be of any length but must not contain any internal
        /// spaces, dots, or colons. Spaces are permitted in front of the mnemonic and between the
        /// end of the mnemonic and the dot.
        /// UNITS = units of the mnemonic (if applicable). The units, if used, must be located directly
        /// after the dot. There must be no spaces between the units and the dot. The units can be of
        /// any length but must not contain any colons or internal spaces.
        /// DATA = value of, or data relating to the mnemonic. This value or input can be of any length
        /// and can contain spaces, dots or colons as appropriate. It must be preceded by at least one
        /// space to demarcate it from the units and must be to the left of the last colon in the line.
        /// DESCRIPTION = description or definition of the mnemonic. It is always located to the right
        /// of the last colon. The length of the line is no longer limited.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public LasSectionItem ParseSectionRow(string row)
        {
            StringBuilder Mnemonic = new StringBuilder();
            StringBuilder Units = new StringBuilder();
            StringBuilder Data = new StringBuilder();
            StringBuilder Description = new StringBuilder();

            for (int i = 0; i < row.Length - 1; i++)
            {
                //get mnemonic
                while (!char.Equals(row[i], Delimiters.DOT))
                {
                    if (!char.IsWhiteSpace(row[i]))
                    {
                        Mnemonic.Append(row[i]);
                    }
                    i++;
                }

                //advance index off '.'
                i++;

                //get units
                while (!char.IsWhiteSpace(row[i]))
                {
                    Units.Append(row[i]);
                    i++;
                }

                //get data
                var colonCount = row.Where(c => c.Equals(Delimiters.COLON)).Count();
                var seenColons = 0;

                while (seenColons != colonCount)
                {
                    if (row[i].Equals(Delimiters.COLON))
                        seenColons++;

                    if (seenColons == colonCount)
                    {
                        Data.Trim();
                        break;
                    }
                    else
                    {
                        Data.Append(row[i]);
                    }
                    i++;
                }

                //advance index off ':'
                i++;

                //get description
                while (i <= row.Length - 1)
                {
                    Description.Append(row[i]);
                    i++;
                }
                Description.Trim();
            }

            return new LasSectionItem 
            {
                Mnemonic = Mnemonic.ToString(),
                Unit = Units.ToString(),
                Data = Data.ToString(),
                Description = Description.ToString()
            };
        }

        public LasData ParseDataRow(string row)
        {
            throw new NotImplementedException();
        }
    }
}
