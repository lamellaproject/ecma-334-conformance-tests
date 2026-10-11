/*
Rules: E10-2-11-int-range
Authority: ECMA-334 7th ed 10.2.11
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static void Main()
    {
        const int input = -129;
        sbyte result = unchecked(input);
    }
}
