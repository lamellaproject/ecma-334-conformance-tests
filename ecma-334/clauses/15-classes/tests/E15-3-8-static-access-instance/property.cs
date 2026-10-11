/*
Rules: E15-3-8-static-access-instance; E15-3-8-static-access-type
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: new Register().Value
Into: Register.Value
*/
class Register { public static int Value { get { return 181; } } }
class Program { static void Main() { int value = new Register().Value; } }
