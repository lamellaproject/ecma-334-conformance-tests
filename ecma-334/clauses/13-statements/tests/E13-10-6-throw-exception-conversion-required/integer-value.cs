/*
Rules: E13-10-6-throw-exception-conversion-required
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: reject
Mutate: throw value;
Into: throw new Exception();
*/
using System;
class Program
{
    static void Raise(int value) { throw value; }
    static void Main() { }
}
