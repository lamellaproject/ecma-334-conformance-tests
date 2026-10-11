/*
Rules: E10-2-3-only-listed; E10-2-11-nonconstant
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static void Main()
    {
        int input = -2147483648;
        sbyte result = checked(input);
    }
}
