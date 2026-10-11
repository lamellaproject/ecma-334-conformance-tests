/*
Rules: E13-11-finally-block-reachable
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: if (true)
Into: if (false)
*/
using System;
class Program
{
    static void Use(int value) { }
    static void Execute() { int value; if (true) try { } finally { Use(value); } }
    static void Main() { }
}
