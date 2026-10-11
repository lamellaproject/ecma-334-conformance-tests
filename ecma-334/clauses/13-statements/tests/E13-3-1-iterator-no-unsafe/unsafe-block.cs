/*
Rules: E13-3-1-iterator-no-unsafe
Authority: ECMA-334 7th ed 13.3.1
Version: 7.3
Expected: reject
Mutate: unsafe { }
Into: { }
*/
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> Values() { unsafe { } yield return 6; }
    static void Main() { }
}
