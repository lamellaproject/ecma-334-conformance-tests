/*
Rules: E13-11-exception-variable-declaration-space
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: Exception caught = null;
Into: Exception different = null;
*/
using System;
class Program
{
    static void Execute() { try { } catch (Exception caught) { Exception caught = null; } }
    static void Main() { }
}
