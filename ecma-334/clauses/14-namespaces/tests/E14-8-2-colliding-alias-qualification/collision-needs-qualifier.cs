/*
Rules: E14-8-2-colliding-alias-qualification; E14-5-2-alias-member-name-collision
Authority: ECMA-334 7th ed 14.8.2
Version: 7.3
Expected: reject
Mutate: Scope.Beacon.Code
Into: Scope::Beacon.Code
*/
using Scope = Harbor;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Scope { class Beacon { public const int Code = 31; } }
class Program
{
    static void Main() { int value = Scope.Beacon.Code; }
}
