/*
Rules: P08-range-lifted; E12-4-8-binary-lifted-null; E12-4-8-binary-lifted-value
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 8
Mutate: Range? present = left..right;
Into: Range? present = right..left;
*/
using System;
class Test
{
    static int checks, failures, reads;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static Index? Read(Index? value) { reads++; return value; }
    static int Main()
    {
        Index? left = new Index(2, false);
        Index? right = new Index(4, true);
        Range? present = left..right;
        Check(present.HasValue, "present-result");
        Check(present.HasValue && present.Value.Start.Value == 2 && !present.Value.Start.IsFromEnd, "unwrapped-start");
        Check(present.HasValue && present.Value.End.Value == 4 && present.Value.End.IsFromEnd, "unwrapped-end");
        left = null;
        Range? missingLeft = left..Read(right);
        Check(!missingLeft.HasValue, "null-start");
        Check(reads == 1, "end-still-evaluated-for-null-start");
        left = new Index(1, false);
        right = null;
        Range? missingRight = left..right;
        Check(!missingRight.HasValue, "null-end");
        left = null;
        Range? bothMissing = left..right;
        Check(!bothMissing.HasValue, "both-null");
        Range? omittedEnd = left..;
        Check(!omittedEnd.HasValue, "lifted-omitted-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
