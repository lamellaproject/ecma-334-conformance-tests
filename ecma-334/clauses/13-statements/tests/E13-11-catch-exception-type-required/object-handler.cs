/*
Rules: E13-11-catch-exception-type-required
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: catch (object)
Into: catch (Exception)
*/
using System;
class Program
{
    static void Execute() { try { } catch (object) { } }
    static void Main() { }
}
