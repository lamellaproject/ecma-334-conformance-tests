/*
Rules: E12-2-1-namespace-context; E12-2-2-value-required
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: reject
Mutate: object value = Shade;
Into: object value = new Shade.Box();
*/
namespace Shade { class Box { } }
class Program { static void Main() { object value = Shade; } }
