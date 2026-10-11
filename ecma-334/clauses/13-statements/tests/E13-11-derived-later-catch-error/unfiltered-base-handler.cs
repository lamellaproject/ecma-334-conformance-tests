/*
Rules: E13-11-derived-later-catch-error
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: catch (Exception)
Into: catch (Exception) when (false)
*/
using System;
class Program
{
    static void Execute() { try { } catch (Exception) { } catch (ArgumentException) { } }
    static void Main() { }
}
