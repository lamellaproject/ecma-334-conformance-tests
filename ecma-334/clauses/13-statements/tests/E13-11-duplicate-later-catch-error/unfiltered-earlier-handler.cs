/*
Rules: E13-11-duplicate-later-catch-error
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: catch (Exception first)
Into: catch (ArgumentException first)
*/
using System;
class Program
{
    static void Execute() { try { } catch (Exception first) { } catch (Exception second) { } }
    static void Main() { }
}
