/*
Rules: E7-7-1-extern-alias-not-transitive
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"alias":"Vendor","library":"Fixture"}],"units":[{"defines":["FIRST_UNIT"],"source":"self"},{"defines":["SECOND_UNIT"],"source":"self"}]}}
Mutate: class Second
Into: extern alias Vendor; class Second
*/
#if LIBRARY
namespace Grove { public class Item { public static int Read() { return 191; } } }
#elif FIRST_UNIT
extern alias Vendor;
class First { public static int Read() { return Vendor::Grove.Item.Read(); } }
#elif SECOND_UNIT
class Second { public static int Read() { return Vendor::Grove.Item.Read(); } }
class Program { static void Main() { First.Read(); Second.Read(); } }
#endif
