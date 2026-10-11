/*
Rules: E9-4-4-23-fixed-subexpression-order; E9-4-4-23-embedded-expression-scope; E9-4-4-23-later-subexpression-entry; E9-4-4-23-last-subexpression-exit
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: (cell = Mark(1, 8)) < Mark(2, cell)
Into: Mark(2, cell) < (cell = Mark(1, 8))
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Mark(int digit, int value) { trace = trace * 10 + digit; return value; }
    static void Main()
    {
        int cell = 2;
        trace = 0; bool less = (cell = Mark(1, 8)) < Mark(2, cell);
        Check(!less && cell == 8 && trace == 12, "less-than-order");
        trace = 0; bool lessEqual = (cell = Mark(1, 8)) <= Mark(2, cell);
        Check(lessEqual && cell == 8 && trace == 12, "less-or-equal-order");
        trace = 0; bool greater = (cell = Mark(1, 8)) > Mark(2, cell);
        Check(!greater && cell == 8 && trace == 12, "greater-than-order");
        trace = 0; bool greaterEqual = (cell = Mark(1, 8)) >= Mark(2, cell);
        Check(greaterEqual && cell == 8 && trace == 12, "greater-or-equal-order");
        trace = 0; bool equal = (cell = Mark(1, 8)) == Mark(2, cell);
        Check(equal && cell == 8 && trace == 12, "equal-order");
        trace = 0; bool unequal = (cell = Mark(1, 8)) != Mark(2, cell);
        Check(!unequal && cell == 8 && trace == 12, "unequal-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
