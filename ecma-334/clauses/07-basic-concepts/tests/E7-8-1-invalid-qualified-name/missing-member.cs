/*
Rules: E7-8-1-invalid-qualified-name
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: Orchard.Missing item = null;
Into: Orchard.Fruit item = null;
Csc: CS0234
*/
namespace Orchard { public class Fruit { } }
class Program { static void Main() { Orchard.Missing item = null; } }
