/*
Rules: E23-6-1-safe-element-access-pointer-error; E23-6-1-pointer-expression-safe-error
Authority: ECMA-334 7th ed 23.6.1
Version: 7.3
Expected: reject
Mutate: static void Main()
Into: static unsafe void Main()
*/
using System;
class Program
{
    static unsafe int*[] Fetch() { return new int*[1]; }
    static void Main()
    {
        var pointer = Fetch()[0];
    }
}
