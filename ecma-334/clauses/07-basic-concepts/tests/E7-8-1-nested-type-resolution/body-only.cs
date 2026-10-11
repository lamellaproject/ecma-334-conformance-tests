/*
Rules: E7-8-1-nested-type-resolution
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: class Branch : Root<Token>
Into: class Branch : Root<Branch.Token>
Csc: CS0246
*/
class Root<T> { }
class Branch : Root<Token> { public class Token { } }
class Program { static void Main() { } }
