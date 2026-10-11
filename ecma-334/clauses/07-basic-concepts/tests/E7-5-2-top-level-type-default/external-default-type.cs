/*
Rules: E7-5-2-top-level-type-default; E7-5-3-internal-top-level-domain
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: class DefaultItem
Into: public class DefaultItem
*/
#if LIBRARY
namespace Orchard { class DefaultItem { public static int Read() { return 17; } } }
#else
class Program { static void Main() { Orchard.DefaultItem.Read(); } }
#endif
