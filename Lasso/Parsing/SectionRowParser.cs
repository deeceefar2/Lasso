using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LassoReader.Models;
using LassoReader.Constants;
using LassoReader.Utility;

namespace LassoReader.Parsing
{
    /// <summary>
    /// Returns section rows, for use with all sections besides the ascii data section
    /// </summary>
    public class SectionRowParser : ILasRowParser<LasSectionItem> 
    {
        public LasSectionItem ParseRow(string row)
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
    }
}
