/*
Rules: E14-5-2-alias-not-transitive
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: reject
Mutate: return Pick.Code + 1;
Into: return Harbor.Beacon.Code + 1;
*/
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Home { using Pick = Harbor.Beacon; class First { public static int Read() { return Pick.Code; } } }
namespace Home { class Second { public static int Read() { return Pick.Code + 1; } } }
class Program
{
    static void Main() {  }
}
