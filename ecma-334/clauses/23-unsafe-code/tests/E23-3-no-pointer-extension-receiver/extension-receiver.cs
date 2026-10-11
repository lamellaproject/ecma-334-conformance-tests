/*
Rules: E23-3-no-pointer-extension-receiver
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: Run(this int* p)
Into: Run(int* p)
*/
using System;
static class Extensions { public static unsafe void Run(this int* p) { } }
class Program
{
    static void Main()
    {

    }
}
