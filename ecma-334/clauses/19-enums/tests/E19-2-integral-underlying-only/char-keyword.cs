/*
Rules: E19-2-integral-underlying-only
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: reject
Mutate: enum Code : char
Into: enum Code : ushort
*/
enum Code : char { One = 1 }
class Program { static void Main() { } }
