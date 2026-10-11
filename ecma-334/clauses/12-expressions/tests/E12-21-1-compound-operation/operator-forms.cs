/*
Rules: E12-21-1-compound-operation; E12-21-1-compound-name; E12-21-1-add-form; E12-21-1-subtract-form; E12-21-1-multiply-form; E12-21-1-divide-form; E12-21-1-remainder-form; E12-21-1-and-form; E12-21-1-or-form; E12-21-1-xor-form; E12-21-1-left-shift-form; E12-21-1-right-shift-form; E12-21-4-predefined-eligibility-summary
Authority: ECMA-334 7th ed 12.21.1
Version: 7.3
Expected: run
Stdout: OK 10
Mutate: remainder %= 5
Into: remainder /= 5
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int add = 21; int addResult = (add += 4); Check(add == 25 && addResult == 25, "add-assignment");
        int subtract = 21; int subtractResult = (subtract -= 4); Check(subtract == 17 && subtractResult == 17, "subtract-assignment");
        int multiply = 21; int multiplyResult = (multiply *= 4); Check(multiply == 84 && multiplyResult == 84, "multiply-assignment");
        int divide = 21; int divideResult = (divide /= 4); Check(divide == 5 && divideResult == 5, "divide-assignment");
        int remainder = 21; int remainderResult = (remainder %= 5); Check(remainder == 1 && remainderResult == 1, "remainder-assignment");
        int and = 13; int andResult = (and &= 6); Check(and == 4 && andResult == 4, "and-assignment");
        int or = 13; int orResult = (or |= 6); Check(or == 15 && orResult == 15, "or-assignment");
        int xor = 13; int xorResult = (xor ^= 6); Check(xor == 11 && xorResult == 11, "xor-assignment");
        int left = 13; int leftResult = (left <<= 2); Check(left == 52 && leftResult == 52, "left-shift-assignment");
        int right = -13; int rightResult = (right >>= 2); Check(right == -4 && rightResult == -4, "right-shift-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
