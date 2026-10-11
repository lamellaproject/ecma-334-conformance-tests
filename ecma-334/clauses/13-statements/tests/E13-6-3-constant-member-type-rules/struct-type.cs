/*
Rules: E13-6-3-constant-member-type-rules
Authority: ECMA-334 7th ed 13.6.3
Version: 7.3
Expected: reject
Mutate: const Token item = default(Token);
Into: Token item = default(Token);
*/
struct Token { }
class Program { static void Main() { const Token item = default(Token); } }
