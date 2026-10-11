/*
Rules: E19-2-integral-name-resolution
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: reject
Mutate: using Storage = System.Char
Into: using Storage = System.UInt16
*/
using Storage = System.Char;
enum Code : Storage { One = 1 }
class Program { static void Main() { } }
