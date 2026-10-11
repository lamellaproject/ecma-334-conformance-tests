/*
Rules: E7-5-3-internal-top-level-domain; E7-5-1-outside-domain-access
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: internal class AssemblyItem
Into: public class AssemblyItem
*/
#if LIBRARY
internal class AssemblyItem { public static int Read() { return 47; } }
#else
class Program { static void Main() { AssemblyItem.Read(); } }
#endif
