/*
Rules: E12-8-9-1-no-result-context
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: reject
Mutate: object result = action();
Into: action();
*/
using System;
class Program
{
    static void Touch() { }
    static void Main() { Action action = Touch; object result = action(); }
}
