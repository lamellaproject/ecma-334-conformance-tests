/*
Rules: E7-8-1-type-alias-conflict
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"alias":"Vendor","library":"Fixture"}]}}
Version-Witness: version-witnesses/extern-conflict-e39253a45f.cs.part
Mutate: class Vendor { public class Fruit { } }
Into: class Local { public class Fruit { } }
*/
#if LIBRARY
public class Fruit { }
#else
namespace Orchard
{
    extern alias Vendor;
    class Vendor { public class Fruit { } }
    class Reader { public Vendor.Fruit value; }
}
class Program { static void Main() { } }
#endif
