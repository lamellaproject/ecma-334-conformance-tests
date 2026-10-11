/*
Rules: E13-15-yield-return-try-catch-error
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: reject
Mutate: catch (Exception) { }
Into: finally { }
*/
using System;
using System.Collections.Generic;
class Program
{
    static IEnumerator<int> Items() { try { yield return 17; } catch (Exception) { } }
    static void Main() { }
}
