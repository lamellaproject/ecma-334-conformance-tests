/*
Rules: E19-2-integral-name-resolution
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: reject
Mutate: System.Decimal
Into: System.Int32
*/
enum Amount : System.Decimal { One = 1 }
class Program { static void Main() { } }
