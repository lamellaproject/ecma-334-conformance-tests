/*
Rules: E15-2-7-partial-no-compiled-extension; E15-2-7-partial-compile-together
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: reject
Mutate: public static partial class Console { }
Into: public static partial class LocalConsole { }
*/
// The source declaration cannot merge with Console from the referenced assembly.
namespace System { public static partial class Console { } }
class Program
{
    static void Main() { System.Console.WriteLine("OK 0"); }
}
