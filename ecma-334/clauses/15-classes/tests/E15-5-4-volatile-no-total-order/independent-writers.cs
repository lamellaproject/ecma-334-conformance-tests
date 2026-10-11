/*
Rules: E15-5-4-volatile-no-total-order
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: First = 1;
Into: First = 2;
*/
using System;
using System.Threading;
class Program
{
    static volatile int First, Second;
    static int FirstReaderFirst, FirstReaderSecond, SecondReaderFirst, SecondReaderSecond;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void WriteFirst() { First = 1; }
    static void WriteSecond() { Second = 1; }
    static void ReadFirstThenSecond() { FirstReaderFirst = First; FirstReaderSecond = Second; }
    static void ReadSecondThenFirst() { SecondReaderSecond = Second; SecondReaderFirst = First; }
    static void Main()
    {
        Thread firstWriter = new Thread(WriteFirst), secondWriter = new Thread(WriteSecond);
        Thread firstReader = new Thread(ReadFirstThenSecond), secondReader = new Thread(ReadSecondThenFirst);
        firstWriter.Start();
        secondWriter.Start();
        firstReader.Start();
        secondReader.Start();
        firstWriter.Join();
        secondWriter.Join();
        firstReader.Join();
        secondReader.Join();
        // Accept all combinations, including observations without one common ordering of the independent writes.
        Check(FirstReaderFirst == 0 || FirstReaderFirst == 1, "first-reader-first-allowed-values");
        Check(FirstReaderSecond == 0 || FirstReaderSecond == 1, "first-reader-second-allowed-values");
        Check(SecondReaderSecond == 0 || SecondReaderSecond == 1, "second-reader-second-allowed-values");
        Check(SecondReaderFirst == 0 || SecondReaderFirst == 1, "second-reader-first-allowed-values");
        Check(First == 1 && Second == 1, "independent-volatile-writers-completed-after-join");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
