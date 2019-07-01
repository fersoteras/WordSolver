Notes on resolution of Qu test

Problem description:
This test  is about creating a program or library with a function that
receives two parameters (a matrix with embedded words readable left to right and top to bottom)
and a stream with words that may be included in the matrix ( no one , some  or all the words in the
stream could be found on the matrix).The return list should be ordered By repetitions found on stream.




Analysis:
My first idea to tackle this problem was to scan the matrix with two nested for each loop and a 
helper function checking for vertical and horizontal match for each word in the stream on each
letter of the word stream.

After  reviewing substring search api, I figured out that using string.contain function against a matrix made of concatenation
of the parametrized matrix and a rotated copy of it  would save me of the need of writing a
helper function to search top-to bottom matches.
As a sidenote: an alternate  way to find actual matches would be to use Regexp.

To store the number of repetitions of matched words,  a HastTable will be used.
Once an entry is logged in the Table,any new occurence of entered word  causes an
accumulation on the value of matched word key without need of rescan of the matrix.

After having a working version , I am planning to search for optimization using Parallel.Foreach or Plinq or just a streamlined version of the basic implementation.



Solution steps:

As a first step I will create a VS solution with 3 projects , a Cmd project in case I need some command execution , a class library 
project to hold the actual implementation of my library and a test class with a some test code and 2 sample matrices and their sample streams for debugging and testing purposes.
Class wordfinder is to be part of WordSolver class library. 
I named them WordSolverCmd , WordSolver and WordSolverNUnitTest.

Once my solution project structure is created, I started working on testing environment by creating a Test class 
with a pair of sample set of strings that are valid as parameters to my WordSolver and a pair of sample collection of words representing the stream.Those samples would stand at both sides of possible range ( a collection with a few elements and another with a bit more of 100000).
One of the matrices have the elements of the one in the test description , the other have the max allowed elements (64x64).
Those sample objects are generated on Setup() method of my NUnit test class.
Since all needed code reside on Library and Test projects, I deleted unused Cmd project.

Result:
Implementation of WordFinder.Find() is faster to ParallelFind() for small streams and the
Last if faster for large ones (Timer.ElapsedTicks values for each case are stated on each test comment).


