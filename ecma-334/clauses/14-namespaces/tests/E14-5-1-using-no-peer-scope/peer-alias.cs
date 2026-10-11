/*
Rules: E14-5-1-using-no-peer-scope; E14-5-2-alias-target-no-peer-usings
Authority: ECMA-334 7th ed 14.5.1
Version: 7.3
Expected: reject
Mutate: using Pick = Scope.Beacon;
Into: using Pick = Harbor.Beacon;
*/
using Pick = Scope.Beacon;
using Scope = Harbor;
namespace Harbor { class Beacon { } }
class Program
{
    static void Main() { Pick value = null; }
}
