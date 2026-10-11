/*
Rules: E23-6-4-element-pointer-operand
Authority: ECMA-334 7th ed 23.6.4
Version: 7.3
Expected: reject
Mutate: int result = value[0];
Into: int result = (&local)[0];
*/
using System;
class Program
{
    static unsafe void Main()
    {
        float value = 3.0f;
        int local = 13;
        int result = value[0];
    }
}
