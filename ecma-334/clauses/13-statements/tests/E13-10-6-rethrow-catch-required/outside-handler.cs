/*
Rules: E13-10-6-rethrow-catch-required
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: reject
Mutate: throw;
Into: throw new Exception();
*/
using System;
class Program
{
    static void Raise() { throw; }
    static void Main() { }
}
