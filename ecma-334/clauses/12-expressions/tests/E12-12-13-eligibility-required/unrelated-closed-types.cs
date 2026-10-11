/*
Rules: E12-12-13-eligibility-required
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: reject
Mutate: value as string
Into: (object)value as string
*/
class Program { static void Main() { int value = 3; string result = value as string; } }
