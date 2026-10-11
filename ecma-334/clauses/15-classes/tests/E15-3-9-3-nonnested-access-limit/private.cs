/*
Rules: E15-3-9-3-nonnested-access-limit
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: reject
Mutate: private class Token
Into: internal class Token
*/
private class Token { }
class Program { static void Main() { } }
