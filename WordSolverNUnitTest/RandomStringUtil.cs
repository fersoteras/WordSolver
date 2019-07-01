using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordSolverNUnitTest
{
    
    /// <summary>
    /// Random string generators.
    /// </summary>
    static class RandomStringUtil
    {
        /// <summary>
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            // remove last 6 chars.
            
            return path.Substring(0,5);
        }
    }
}
