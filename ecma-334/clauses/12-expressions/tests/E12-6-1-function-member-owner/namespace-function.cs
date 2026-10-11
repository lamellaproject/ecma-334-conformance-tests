/*
Rules: E12-6-1-function-member-owner
Authority: ECMA-334 7th ed 12.6.1
Version: 7.3
Expected: reject
Mutate: namespace Shade
Into: class Shade
*/
namespace Shade { static void Method() { } }
class Program { static void Main() { } }
