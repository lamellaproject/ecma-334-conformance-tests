/*
Rules: E10-2-3-only-listed
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
        const long input = 2147483647L;
        int result = unchecked(input);
    }
}
