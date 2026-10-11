/*
Rules: E12-8-19-checked-constant; E12-8-19-integral-conversion-context
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: reject
Mutate: checked((sbyte)154)
Into: unchecked((sbyte)154)
Csc: CS0221
*/
using System;
class Program
{
    const sbyte Narrow = checked((sbyte)154);
    static void Main() { Console.WriteLine(Narrow); }
}
