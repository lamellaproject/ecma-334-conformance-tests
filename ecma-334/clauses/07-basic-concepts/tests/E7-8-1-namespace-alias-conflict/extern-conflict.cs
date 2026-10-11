/*
Rules: E7-8-1-namespace-alias-conflict
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"alias":"Vendor","library":"Fixture"}]}}
Version-Witness: version-witnesses/extern-conflict-34b19f8a1d.cs.part
Mutate: namespace Vendor { public class Fruit { } }
Into: namespace Local { public class Fruit { } }
*/
#if LIBRARY
public class Fruit { }
#else
namespace Orchard
{
    extern alias Vendor;
    namespace Vendor { public class Fruit { } }
    class Reader { public Vendor.Fruit value; }
}
class Program { static void Main() { } }
#endif
