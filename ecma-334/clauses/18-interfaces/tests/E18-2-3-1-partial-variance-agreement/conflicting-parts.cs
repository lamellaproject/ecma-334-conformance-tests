/*
Rules: E18-2-3-1-partial-variance-agreement
Authority: ECMA-334 7th ed 18.2.3.1
Version: 7.3
Expected: reject
Mutate: partial interface IRead<T>
Into: partial interface IRead<out T>
Csc: CS1067
*/
partial interface IRead<out T> { }
partial interface IRead<T> { }
class Program { static void Main() { } }
