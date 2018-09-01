using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SnowCSharpTest.Models;

namespace SnowCSharpTest.Services
{
    public class ParserService : IParser
    {
        private readonly string[] _splitChars = { @"\n", @"\r\n" };

        /// <inheritdoc />
        /// <summary>
        /// Parses the given string and convert it to List of Bar object. 
        /// We assume that each record is saparated by the carriage return. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IList<Bar> Parse(string data)
        {
            // we will return an empty list instead of null in order to compatible with .net's standards
            data = data.Replace(" ", "");

            //data.Replace(" ", string.Empty);

            var result = new List<Bar>();
            char[] splitchar = { '\n' };

            if (String.IsNullOrWhiteSpace(data))
            {
                return result;
            }

            // we except that in the given string each record is saparated by the carriage return
            //var records = data.Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);

            var records = data.Split(splitchar);

            if (records.Length < 1) // TODO: we might need to throw exception if string can't be split into saparate records
            {
                // right now just return empty list
                return result;
            }

            var lineNumber = 1;

            foreach (var record in records)
            {
                string barcode = record.Split(':')[0];

                if (record.Length < 2)
                {
                    // throw new InvalidDataException("JJJJ line must start with '#' sign. The line " + lineNumber + " is wrong.");

                }

                else
                {

                    // each line must start with # otherwise throw exception
                    if (record.ToCharArray()[0] != (char)35)
                    {
                        throw new InvalidDataException("Each line must start with '#' sign. The line " + lineNumber +
                        " is wrong.");

                    }

                    // Must be wtitten BarCode 

                    if (barcode.Length < 2)
                    {
                        throw new InvalidDataException("Bar Code is empty Must be mention Bar code");
                    }

                    var rawData = record.Substring(1).Split(':');

                    // it must be only 3 valid properties in each line
                    if (rawData.Length != 3)
                    {
                        throw new InvalidDataException("Error parsing the data at line " + lineNumber);
                    }

                    // size must always be in integer form
                    var size = -1;
                    if (!int.TryParse(rawData[2], out size))
                    {
                        throw new InvalidDataException(
                        "Size must always be an integer number. Wrong size is given at line " + lineNumber);
                    }


                    var bar = new Bar { BarCode = rawData[0], Color = rawData[1], Size = size };

                    result.Add(bar);
                }

                lineNumber++;
            }
            return result;
        }
    }
}