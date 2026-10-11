/*
Rules: E13-11-try-handler-or-finally-required
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: try { }
Into: try { } finally { }
*/
using System;
class Program
{
    static void Execute() { try { } }
    static void Main() { }
}
