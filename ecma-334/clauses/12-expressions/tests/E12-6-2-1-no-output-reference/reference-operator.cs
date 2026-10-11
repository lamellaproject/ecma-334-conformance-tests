/*
Rules: E12-6-2-1-no-output-reference
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: reject
Mutate: operator +(ref Box operand)
Into: operator +(in Box operand)
*/
struct Box { public static Box operator +(ref Box operand) { return operand; } }
class Program { static void Main() { } }
