/*
Rules: E14-5-3-no-nested-namespace-import
Authority: ECMA-334 7th ed 14.5.3
Version: 7.3
Expected: reject
Mutate: Inner.Beacon value
Into: Harbor.Inner.Beacon value
*/
using Harbor;
namespace Harbor { namespace Inner { class Beacon { } } }
class Program
{
    static void Main() { Inner.Beacon value = null; }
}
