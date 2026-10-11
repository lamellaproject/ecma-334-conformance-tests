/*
Rules: E15-3-9-3-struct-nested-access-limit
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: reject
Mutate: protected class Token
Into: private class Token
*/
struct Packet { protected class Token { } }
class Program { static void Main() { } }
