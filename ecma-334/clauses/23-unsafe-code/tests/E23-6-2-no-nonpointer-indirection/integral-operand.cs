/*
Rules: E23-6-2-no-nonpointer-indirection
Authority: ECMA-334 7th ed 23.6.2
Version: 7.3
Expected: reject
Mutate: int result = *value;
Into: int result = value;
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int value = 31;
        int result = *value;
    }
}
