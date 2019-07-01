using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WordSolver
{
    public class WordFinder : IWordFinder
    {

        private Hashtable _mostRepeated;
        private List<string> _matrix;
        private List<string> _rotatedMatrix;
        public WordFinder(List<string> matrix)
        {
            _matrix = matrix;

            _rotatedMatrix = RotateMatrix(_matrix);

            _mostRepeated = new Hashtable();
        }


        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            // gather  lenght of matrix
            var xWidth = _matrix[0].Length;

            //combine matrix and rotated matrix 
            List<string> mtrx = new List<string>();
            mtrx.AddRange(_matrix);
            mtrx.AddRange(_rotatedMatrix);

            // execution time aux. code
            //Stopwatch timer = new Stopwatch();

            // traverse each element of wordStream.
            // If a word in the stream has already been found, accumulate it's entry
            // on the table without commiting to search it again.If a word peeked on the stream
            // is found on  the matrix , add it on a new hash entry.

            // timer.Start();

            foreach (string word in wordStream)
            {
                //if  word  is already  in our hash, there's no need of search it in the matrix again, just accumulate on the hashTable entry.
                if (_mostRepeated.ContainsKey(word))
                {
                    _mostRepeated[word] = (int)_mostRepeated[word] + 1;

                }
                else
                {
                    //new word , search for a match
                    foreach (string line in mtrx)
                    {
                        // try with contains
                        if (line.Contains(word))
                        {
                            _mostRepeated.Add(word, 1);
                            // word found , break out word-match-matrix loop and resume looping on stream.
                            break;
                        }

                    } //foreach line in mtrx.
                }
            } //foreach word in stream.


            //  timer.Stop();
            //  Console.WriteLine($"find function main loop elapsed time:  { timer.ElapsedTicks}");

            var rptd = _mostRepeated.Cast<DictionaryEntry>().OrderBy(entry => entry.Value).Reverse().ToList();

            var myKeys = rptd.Select(ent => (string)ent.Key);

            return myKeys.Take(10).ToList();
        }

        // ParallelFind applies the same algorith that previous method but using Parallel.Foreach.
        // Ther's a gain in efficency when tested with really big streams , not so with smallish ones.

        public List<string> ParallelFind(List<string> wordStream)
        {
            // gather  lenght of matrix
            var xWidth = _matrix[0].Length;

            //combine matrix and rotated matrix 
            List<string> mtrx = new List<string>();
            mtrx.AddRange(_matrix);
            mtrx.AddRange(_rotatedMatrix);

            // execution time aux. code
            //Stopwatch timer = new Stopwatch();
            // timer.Start();

            Parallel.ForEach(wordStream, (word) =>
            {
                //if  word  is already  in our hash, there's no need of search it in the matrix again, just accumulate on the hashTable entry.
                if (_mostRepeated.ContainsKey(word))
                {
                    _mostRepeated[word] = (int)_mostRepeated[word] + 1;

                }
                else
                {
                    //new word , search for a match
                    foreach (string line in mtrx)
                    {
                        // try with contains
                        if (line.Contains(word))
                        {
                            _mostRepeated.Add(word, 1);
                            // word found , break out word-match-matrix loop and resume looping on stream.
                            break;
                        }

                    } //foreach line in mtrx.
                }
            }); //foreach word in stream.


            //  timer.Stop();
            //  Console.WriteLine($"find function main loop elapsed time:  { timer.ElapsedTicks}");

            var rptd = _mostRepeated.Cast<DictionaryEntry>().OrderBy(entry => entry.Value).Reverse().ToList();

            var myKeys = rptd.Select(ent => (string)ent.Key);

            return myKeys.Take(10).ToList();
        }

        public List<string> RotateMatrix(List<string> oringinalMatrix)
        {
            //generate an array with same elements but rotated 90 degrees.
            int strLength = oringinalMatrix[0].Length;
            List<string> result = new List<string>();

            for (int i = strLength - 1; i >= 0; i--)
            {
                string newLine = "";
                foreach (string line in oringinalMatrix)
                {
                    newLine = newLine + line[i];

                }
                result.Add(newLine);
            }

            return result;
        }
    }
}
