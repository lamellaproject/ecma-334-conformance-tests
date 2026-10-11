/*
Rules: E19-4-no-value-cycle
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: reject
Mutate: Value = Value
Into: Value = 1
*/
enum Code { Value = Value }
class Program { static void Main() { } }
