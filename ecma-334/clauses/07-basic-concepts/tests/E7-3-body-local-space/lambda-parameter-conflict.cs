/*
Rules: E7-3-body-local-space; E7-3-nested-local-name-conflict
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: (int value) =>
Into: (int input) =>
*/
using System;
class Program
{
    static void Main()
    {
        Func<int, int> project = (int value) => { int value = 17; return value; };
        project(23);
    }
}
