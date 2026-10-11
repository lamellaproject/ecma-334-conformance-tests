/*
Rules: E7-8-1-invalid-qualified-name
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: Orchard.Fruit<int, long> item = null;
Into: Orchard.Fruit<int> item = null;
*/
namespace Orchard { public class Fruit<T> { } }
class Program { static void Main() { Orchard.Fruit<int, long> item = null; } }
