/*
Rules: E23-6-7-no-void-subtraction
Authority: ECMA-334 7th ed 23.6.7
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
        void* result = pointer - 1;
    }
}
