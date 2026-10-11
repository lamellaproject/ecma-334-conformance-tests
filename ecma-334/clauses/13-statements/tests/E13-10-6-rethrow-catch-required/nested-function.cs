/*
Rules: E13-10-6-rethrow-catch-required
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: reject
Mutate: void Nested() { throw; }
Into: void Nested() { throw new Exception(); }
*/
using System;
class Program
{
    static void Raise() { try { throw new Exception(); } catch { void Nested() { throw; } Nested(); } }
    static void Main() { }
}
