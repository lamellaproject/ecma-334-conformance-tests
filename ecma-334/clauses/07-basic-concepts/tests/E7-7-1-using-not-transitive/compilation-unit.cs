/*
Rules: E7-7-1-using-not-transitive
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: reject
Fixture: {"program":{"units":[{"defines":["FIRST_UNIT"],"source":"self"},{"defines":["SECOND_UNIT"],"source":"self"}]}}
Mutate: class Program
Into: using Grove; class Program
*/
#if FIRST_UNIT
using Grove;
namespace Grove { class Item { public static int Read() { return 223; } } }
class First { public static int Read() { return Item.Read(); } }
#elif SECOND_UNIT
class Program { static void Main() { First.Read(); Item.Read(); } }
#endif
