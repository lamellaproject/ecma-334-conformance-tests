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
        float input = -3.40282347e+38f;
        uint result = checked(input);
    }
}
