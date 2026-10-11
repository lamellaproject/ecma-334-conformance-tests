/*
Rules: E12-12-13-target-type
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: reject
Mutate: value as int
Into: value as int?
*/
class Program { static void Main() { object value = 3; object result = value as int; } }
