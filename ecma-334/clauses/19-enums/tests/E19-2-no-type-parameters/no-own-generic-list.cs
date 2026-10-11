/*
Rules: E19-2-no-type-parameters
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: reject
Mutate: enum Code<T>
Into: enum Code
*/
enum Code<T> { Value }
class Program { static void Main() { } }
