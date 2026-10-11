/*
Rules: E23-2-unsafe-features-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: reject
Mutate: int* pointer = null;
Into: unsafe { int* pointer = null; }
*/
using System;
class Program
{
    static void Main()
    {
        int* pointer = null;
    }
}
