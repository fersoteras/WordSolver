using NUnit.Framework;
using System.Collections.Generic;
using WordSolver;
using WordSolverNUnitTest;

namespace Tests
{
    public class WordSolverNUnitTest
    {
        // use setup method to create test records once and access them in every test method that needs them.
        private List<string> _matrixSmall;
        private List<string> _matrixLarge;
        private List<string> _searchWordsShort;
        private List<string> _searchWordsNoMatch;
        private List<string> _searchWordsLong;

        [SetUp]
        public void Setup()
        {
            // create test matrices and stream lists.

            _matrixSmall = new List<string>() {"abcdc","fgwio",  "chill" , "pqnsd", "uvdxy"};

            _matrixLarge = new List<string>() { "abcdcxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxy",
                                                                    "fgwioxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxx",
                                                                    "chillxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyx",
                                                                    "pqnsdxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxy",
                                                                    "uvdxyxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxy",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx", //16
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx", //32
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                     "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "xyxyxyxxyxyxyxxyxyyxyxyxyxyxyxxyxyxyxyxxyxyxyxxyxyyxyxyxyxyxyxyx",
                                                                    "fireearthethergoldxyxcoldxywarmxxyxyyxyxyhotyxyxxyxyxycopersnowvy"//64 
                                                                   
                                                                  };

            _searchWordsShort = new List<string>() { "cold", "wind", "snow","chill" };
            _searchWordsNoMatch = new List<string> { "foo", "bar", "zoo" };
            _searchWordsLong = new List<string>() { "cold", "wind", "snow", "chill", "wind" , "wind", "snow" , "wind"  };

            // initialize long stream with 100.000 random strings.
            for (int i = 0; i <= 100000; i++)
            {
                var randomString = RandomStringUtil.GetRandomString();
                _searchWordsLong.Add(randomString);
            }
            //add multiple repeated entries to test 10 most repeated requeriment.
            var repeatedEntries = new string[] {    "cold", "cold", "cold", "cold", "cold", "cold", "chill", "chill", "snow" , "snow","wind", "fire","earth","ether","gold","coper","hot","warm"};
            _searchWordsLong.AddRange( repeatedEntries);
        }


        //timer.ElapsedTicks = 35
        [Test]
        public void TestFindSmallMatrixShortStream()
        {
            var solver = new WordFinder(_matrixSmall);
            var result = (List<string>)solver.Find(_searchWordsShort);
            Assert.AreEqual(3, result.Count);

        }
        //timer.ElapsedTicks = 3697521
        [Test]
        public void TestFindLargeMatrixLongStream()
        {
            var solver = new WordFinder(_matrixLarge);
            var result = (List<string>)solver.Find(_searchWordsLong);
            Assert.AreEqual(10, result.Count);
            Assert.AreEqual((result.GetRange(0, 3)), new List<string>() { "cold", "wind", "snow" });
        }

        [Test]
        public void TestFindSmallMatrixShortStreamNoMatch()
        {
            var solver = new WordFinder(_matrixSmall);
            var result = (List<string>)solver.Find(_searchWordsNoMatch);
            Assert.AreEqual(0, result.Count);

        }



        //  timer.ElapsedTicks =   48507 .
        [Test]
        public void TestParallelFindSmallMatrixShortStream()
        {
            var solver = new WordFinder(_matrixSmall);
            var result = solver.ParallelFind(_searchWordsShort);
            Assert.AreEqual(3, result.Count);

        }
        //timer.ElapsedTicks = 1010277
        [Test]
        public void TestParallelFindBigMatrixLongStream()
        {
            var solver = new WordFinder(_matrixLarge);
            var result = solver.ParallelFind(_searchWordsLong);

            Assert.AreEqual(10, result.Count);
            Assert.AreEqual((result.GetRange(0, 3)), new List<string>() { "cold", "wind", "snow" });

        }

  
        [Test]
        public void TestRotateMatrixSmall()
        {
            var solver = new WordFinder(_matrixSmall);
            var rotatedMtrx = solver.RotateMatrix(_matrixSmall);

            Assert.AreEqual(rotatedMtrx[0] , "coldy");
            Assert.AreEqual(rotatedMtrx[4] , "afcpu");
        }

        [Test]
        public void TestRotateMatrixLarge()
        {
            var solver = new WordFinder(_matrixLarge);
            var rotatedMtrx = solver.RotateMatrix(_matrixLarge);

            Assert.AreEqual(rotatedMtrx[0], "yxyyyxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxv");                      
            Assert.AreEqual(rotatedMtrx[63], "afcpuxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxf");
        }
    }
}