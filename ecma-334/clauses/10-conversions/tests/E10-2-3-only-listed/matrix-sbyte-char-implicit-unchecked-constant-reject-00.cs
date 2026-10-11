/*
Rules: E10-2-3-only-listed; E10-2-3-no-char
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
        const sbyte input = (sbyte)(-128);
        char result = unchecked(input);
    }
}
