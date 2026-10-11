/*
Rules: E12-23-exception
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static void Main()
    {
        const long input = 65536L;
        char result = checked((char)input);
    }
}
