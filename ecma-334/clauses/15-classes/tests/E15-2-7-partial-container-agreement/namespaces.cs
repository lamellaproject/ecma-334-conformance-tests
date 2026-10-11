/*
Rules: E15-2-7-partial-container-agreement
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: reject
Mutate: namespace West
Into: namespace East
*/
namespace East { public partial class Meter { public int Left; } }
namespace West { public partial class Meter { public int Right; } }
class Program
{
    static void Main() { new East.Meter().Right = 71; }
}
