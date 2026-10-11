/*
Rules: E14-8-1-type-left-alias; E14-8-1-alias-scope-search-order
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: reject
Mutate: using Scope = System.Int32;
Into: using Scope = Harbor;
*/
using Scope = Harbor;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Home { using Scope = System.Int32; class Reader { public static int Read() { return Scope::Beacon.Code; } } }
class Program
{
    static void Main() {  }
}
