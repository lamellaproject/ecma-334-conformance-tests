/*
Rules: E13-15-yield-return-try-catch-error
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: reject
Mutate: catch (Exception) { yield return 17; }
Into: catch (Exception) { }
*/
using System;
using System.Collections.Generic;
class Program
{
    static IEnumerator<int> Items() { yield return 19; try { throw new Exception(); } catch (Exception) { yield return 17; } }
    static void Main() { }
}
