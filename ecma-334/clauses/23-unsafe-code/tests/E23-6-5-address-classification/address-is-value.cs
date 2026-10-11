/*
Rules: E23-6-5-address-classification
Authority: ECMA-334 7th ed 23.6.5
Version: 7.3
Expected: reject
Mutate: &value = null;
Into: int* pointer = &value;
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int value = 13;
        &value = null;
    }
}
