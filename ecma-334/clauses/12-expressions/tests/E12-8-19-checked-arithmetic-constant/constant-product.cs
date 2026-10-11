/*
Rules: E12-8-19-checked-arithmetic-constant
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: reject
Mutate: checked(65536 * 32768)
Into: unchecked(65536 * 32768)
Csc: CS0220
*/
using System;
class Program
{
    const int Product = checked(65536 * 32768);
    static void Main() { Console.WriteLine(Product); }
}
