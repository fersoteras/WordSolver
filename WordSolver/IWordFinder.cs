using System;
using System.Collections.Generic;
using System.Text;

namespace WordSolver
{
    interface IWordFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}