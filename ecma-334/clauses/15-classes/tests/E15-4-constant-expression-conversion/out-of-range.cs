/*
Rules: E15-4-constant-expression-conversion
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const byte Code = 256;
Into: public const byte Code = 255;
Csc: CS0031
*/
class Limits { public const byte Code = 256; }
class Program { static void Main() { byte value = Limits.Code; } }
