/*
Rules: E19-6-enum-integral-conversion
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: reject
Mutate: Code item = number
Into: Code item = (Code)number
*/
enum Code { Mark = 3 }
class Program { static void Main() { int number = 3; Code item = number; } }
