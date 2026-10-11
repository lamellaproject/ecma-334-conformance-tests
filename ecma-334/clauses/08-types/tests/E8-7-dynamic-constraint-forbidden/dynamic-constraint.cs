/*
Rules: E8-7-dynamic-constraint-forbidden
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: reject
Mutate: where T : dynamic
Into: where T : class
*/
class Gate<T> where T : dynamic { }
class Program { static void Main() { } }
