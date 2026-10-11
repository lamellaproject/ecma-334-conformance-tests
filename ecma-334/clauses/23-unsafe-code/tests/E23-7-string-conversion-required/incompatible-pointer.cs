/*
Rules: E23-7-string-conversion-required
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: fixed (byte* pointer = text)
Into: fixed (char* pointer = text)
*/
using System;
class Program
{
    static unsafe void Main()
    {
        string text = "reed";
        fixed (byte* pointer = text) { }
    }
}
