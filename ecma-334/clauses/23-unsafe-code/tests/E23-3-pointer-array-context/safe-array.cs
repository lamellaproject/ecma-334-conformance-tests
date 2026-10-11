/*
Rules: E23-3-pointer-array-context
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: int*[] a = new int*[1];
Into: unsafe { int*[] a = new int*[1]; }
*/
using System;
class Program
{
    static void Main()
    {
        int*[] a = new int*[1];
    }
}
