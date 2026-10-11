/*
Rules: E15-3-8-static-access-instance; E15-3-8-static-access-type; E15-3-8-constants-static
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: new Register().Code
Into: Register.Code
*/
class Register { public const int Code = 191; }
class Program { static void Main() { int value = new Register().Code; } }
