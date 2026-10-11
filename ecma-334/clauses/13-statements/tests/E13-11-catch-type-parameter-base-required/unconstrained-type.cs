/*
Rules: E13-11-catch-type-parameter-base-required
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: where T : class
Into: where T : Exception
*/
using System;
class Program
{
    static void Execute<T>() where T : class { try { } catch (T) { } }
    static void Main() { }
}
