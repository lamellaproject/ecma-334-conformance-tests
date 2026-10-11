/*
Rules: E9-4-4-23-embedded-expression-scope; E9-4-4-23-fixed-subexpression-order; E9-4-4-23-first-subexpression-entry; E9-4-4-23-later-subexpression-entry; E9-4-4-23-last-subexpression-exit
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 14
Mutate: (cell = Mark(1, 6)) + Mark(2, cell)
Into: Mark(2, cell) + (cell = Mark(1, 6))
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Mark(int digit, int value) { trace = trace * 10 + digit; return value; }
    static void Main()
    {
        int cell = 3;
        trace = 0; int add = (cell = Mark(1, 6)) + Mark(2, cell);
        Check(add == 12 && cell == 6 && trace == 12, "addition-order-and-exit");
        trace = 0; int sub = (cell = Mark(1, 6)) - Mark(2, cell);
        Check(sub == 0 && cell == 6 && trace == 12, "subtraction-order-and-exit");
        trace = 0; int mul = (cell = Mark(1, 6)) * Mark(2, cell);
        Check(mul == 36 && cell == 6 && trace == 12, "multiplication-order-and-exit");
        trace = 0; int div = (cell = Mark(1, 6)) / Mark(2, cell);
        Check(div == 1 && cell == 6 && trace == 12, "division-order-and-exit");
        trace = 0; int rem = (cell = Mark(1, 6)) % Mark(2, cell);
        Check(rem == 0 && cell == 6 && trace == 12, "remainder-order-and-exit");
        trace = 0; int left = (cell = Mark(1, 6)) << Mark(2, cell);
        Check(left == 384 && cell == 6 && trace == 12, "left-shift-order-and-exit");
        trace = 0; int right = (cell = Mark(1, 6)) >> Mark(2, cell);
        Check(right == 0 && cell == 6 && trace == 12, "right-shift-order-and-exit");
        trace = 0; int and = (cell = Mark(1, 6)) & Mark(2, cell);
        Check(and == 6 && cell == 6 && trace == 12, "and-order-and-exit");
        trace = 0; int or = (cell = Mark(1, 6)) | Mark(2, cell);
        Check(or == 6 && cell == 6 && trace == 12, "or-order-and-exit");
        trace = 0; int xor = (cell = Mark(1, 6)) ^ Mark(2, cell);
        Check(xor == 0 && cell == 6 && trace == 12, "xor-order-and-exit");
        int positive = +(cell = 19); Check(positive == 19 && cell == 19, "unary-plus-exit");
        int negative = -(cell = 21); Check(negative == -21 && cell == 21, "unary-minus-exit");
        int complement = ~(cell = 23); Check(complement == -24 && cell == 23, "complement-exit");
        int converted = (int)(short)(cell = 25); Check(converted == 25 && cell == 25, "cast-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
