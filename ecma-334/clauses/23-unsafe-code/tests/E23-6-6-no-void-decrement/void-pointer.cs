/*
Rules: E23-6-6-no-void-decrement
Authority: ECMA-334 7th ed 23.6.6
Version: 7.3
Expected: reject
Mutate: void* pointer = null;
Into: byte* pointer = null;
*/
using System;
class Program
{
    static unsafe void Main()
    {
        void* pointer = null;
        pointer--;
    }
}
