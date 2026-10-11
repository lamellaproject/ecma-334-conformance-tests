/*
Rules: E13-6-2-4-async-no-ref-struct-local
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: reject
Mutate: ref struct Token
Into: struct Token
*/
ref struct Token { public int Value; }
class Program { static async void Work() { Token item = default(Token); } static void Main() { } }
