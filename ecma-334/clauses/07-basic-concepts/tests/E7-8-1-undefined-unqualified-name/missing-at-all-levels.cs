/*
Rules: E7-8-1-undefined-unqualified-name
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: Missing value = null;
Into: Existing value = null;
Csc: CS0246
*/
class Existing { }
namespace Orchard.Grove { class Reader { static void Read() { Missing value = null; } } }
class Program { static void Main() { } }
