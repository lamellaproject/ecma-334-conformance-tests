/*
Rules: P08-recursive-positional-ituple
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: (11, 37)
Into: (12, 37)
*/
using System;
using System.Runtime.CompilerServices;
class TupleView : ITuple
{
    public int Size = 2, LengthReads, FirstReads, SecondReads;
    public int Length { get { LengthReads++; return Size; } }
    public object this[int index]
    {
        get
        {
            if (index == 0) { FirstReads++; return 11; }
            if (index == 1) { SecondReads++; return 37; }
            throw new IndexOutOfRangeException();
        }
    }
}
class Program
{
    static int checks, failures;
    static bool Matches(object input) { return input is (11, 37); }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        TupleView view = new TupleView();
        Check(Matches(view) && view.LengthReads == 1 && view.FirstReads == 1 && view.SecondReads == 1, "ituple-length-indexed-values");
        view.Size = 3;
        Check(!Matches(view) && view.LengthReads == 2 && view.FirstReads == 1 && view.SecondReads == 1, "length-mismatch-no-indexing");
        Check(!Matches(new object()), "object-not-ituple");
        Check(!Matches(null), "ituple-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
