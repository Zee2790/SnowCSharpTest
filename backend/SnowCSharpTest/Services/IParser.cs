using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnowCSharpTest.Models;

namespace SnowCSharpTest.Services
{
    /// <summary>
    /// Provides functions to Parse the data
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses the given string and returns the List of the Bar object
        /// </summary>
        /// <param name="data">The string contains info about Bar and saparated by carriage return</param>
        /// <returns>List of Bar model objects</returns>
        IList<Bar> Parse(string data);
    }
}
