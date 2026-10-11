/*
Rules: E14-5-3-ambiguous-type-imports
Authority: ECMA-334 7th ed 14.5.3
Version: 7.3
Expected: reject
Mutate: Beacon value
Into: Harbor.Beacon value
*/
using Harbor;
using Canal;
namespace Harbor { class Beacon { } }
namespace Canal { class Beacon { } }
class Program
{
    static void Main() { Beacon value = null; }
}
