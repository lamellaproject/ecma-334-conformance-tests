/*
Rules: E15-3-9-3-nonnested-access-limit
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: reject
Mutate: private protected class Token
Into: internal class Token
*/
namespace Orbit { private protected class Token { } }
class Program { static void Main() { } }
