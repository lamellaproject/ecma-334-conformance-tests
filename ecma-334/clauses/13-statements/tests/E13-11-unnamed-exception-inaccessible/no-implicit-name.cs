/*
Rules: E13-11-unnamed-exception-inaccessible
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: catch (Exception)
Into: catch (Exception caught)
*/
using System;
class Program
{
    static void Execute() { try { } catch (Exception) { Console.WriteLine(caught); } }
    static void Main() { }
}
