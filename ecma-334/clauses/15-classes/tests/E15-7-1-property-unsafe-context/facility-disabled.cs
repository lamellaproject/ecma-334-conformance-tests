/*
Rules: E15-7-1-property-unsafe-context
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: unsafe int Token
Into: int Token
Csc: CS0227
*/
class Box { public unsafe int Token => 5; }
class Program { static void Main() { } }
