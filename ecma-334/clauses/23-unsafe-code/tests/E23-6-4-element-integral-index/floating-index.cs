/*
Rules: E23-6-4-element-integral-index
Authority: ECMA-334 7th ed 23.6.4
Version: 7.3
Expected: reject
Mutate: int result = pointer[index];
Into: int result = pointer[(int)index];
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int value = 13;
        int* pointer = &value;
        double index = 0;
        int result = pointer[index];
    }
}
