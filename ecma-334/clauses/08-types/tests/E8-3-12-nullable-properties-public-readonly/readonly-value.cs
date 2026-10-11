/*
Rules: E8-3-12-nullable-properties-public-readonly
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: reject
Mutate: value.Value = 4;
Into: value = 4;
*/
class Program { static void Main() { int? value = 3; value.Value = 4; } }
