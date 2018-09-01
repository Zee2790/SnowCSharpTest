using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnowCSharpTest.Models
{
    /// <summary>
    /// Represents the Bar properties
    /// </summary>
    public class Bar
    {
        /// <summary>
        /// Gets or sets the BarCode i.e A, B etc. 
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// Gets or sets the Color of the bar i.e Blue, Red etc.
        /// </summary>
        public string Color { get; set; }
        
        /// <summary>
        /// Gets or sets the Size of the Bar i.e 5, 10 etc.  
        /// </summary>
        public int Size { get; set; }

    }
}