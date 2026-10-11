/*
Rules: E14-5-4-extension-no-static-import
Authority: ECMA-334 7th ed 14.5.4
Version: 7.3
Expected: reject
Mutate: int value = Next(28);
Into: int value = 28.Next();
*/
using static Extension;
static class Extension { public static int Next(this int value) { return value + 1; } }
class Program
{
    static void Main() { int value = Next(28); }
}
