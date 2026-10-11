/*
Rules: E19-6-enum-integral-conversion
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: reject
Mutate: int number = Code.Mark
Into: int number = (int)Code.Mark
*/
enum Code { Mark = 3 }
class Program { static void Main() { int number = Code.Mark; } }
