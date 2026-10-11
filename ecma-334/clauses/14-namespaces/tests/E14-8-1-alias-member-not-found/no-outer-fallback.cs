/*
Rules: E14-8-1-alias-member-not-found; E14-8-1-alias-scope-search-order
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: reject
Mutate: using Scope = Empty;
Into: using Scope = Harbor;
*/
using Scope = Harbor;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Empty { }
namespace Home { using Scope = Empty; class Reader { public static int Read() { return Scope::Beacon.Code; } } }
class Program
{
    static void Main() {  }
}
