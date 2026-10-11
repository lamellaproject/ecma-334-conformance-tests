/*
Rules: E14-5-2-alias-unique
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: reject
Mutate: using Pick = Canal.Beacon;
Into: using Other = Canal.Beacon;
*/
using Pick = Harbor.Beacon;
using Pick = Canal.Beacon;
namespace Harbor { class Beacon { } }
namespace Canal { class Beacon { } }
class Program
{
    static void Main() { Pick value = null; }
}
