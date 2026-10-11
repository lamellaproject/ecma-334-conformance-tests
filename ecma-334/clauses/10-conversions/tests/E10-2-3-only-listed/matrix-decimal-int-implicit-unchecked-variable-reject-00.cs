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
        decimal input = -79228162514264337593543950335m;
        int result = unchecked(input);
    }
}
