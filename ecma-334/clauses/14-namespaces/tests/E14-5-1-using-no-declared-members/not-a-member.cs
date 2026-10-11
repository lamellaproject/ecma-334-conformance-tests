/*
Rules: E14-5-1-using-no-declared-members
Authority: ECMA-334 7th ed 14.5.1
Version: 7.3
Expected: reject
Mutate: Home.Beacon value
Into: Harbor.Beacon value
*/
using Harbor;
namespace Harbor { class Beacon { } }
namespace Home { class Local { } }
class Program
{
    static void Main() { Home.Beacon value = null; }
}
