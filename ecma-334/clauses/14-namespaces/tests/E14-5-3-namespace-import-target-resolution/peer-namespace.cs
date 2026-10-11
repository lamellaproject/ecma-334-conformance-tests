/*
Rules: E14-5-3-namespace-import-target-resolution
Authority: ECMA-334 7th ed 14.5.3
Version: 7.3
Expected: reject
Mutate: using Inner;
Into: using Harbor.Inner;
*/
using Harbor;
using Inner;
namespace Harbor { namespace Inner { class Beacon { } } }
class Program
{
    static void Main() { Beacon value = null; }
}
