/*
Rules: E15-3-8-instance-access-type; E15-3-8-instance-access-receiver
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: Register.Value
Into: new Register().Value
*/
class Register { public int Value = 193; }
class Program { static void Main() { int value = Register.Value; } }
