/*
Rules: E13-11-try-end-reachable
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: catch (Exception) { }
Into: catch (Exception) { return 53; }
*/
using System;
class Program
{
    static int Value() { try { throw new Exception(); } catch (Exception) { } }
    static void Main() { }
}
