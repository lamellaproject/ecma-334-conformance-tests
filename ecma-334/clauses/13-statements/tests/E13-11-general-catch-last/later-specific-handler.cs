/*
Rules: E13-11-general-catch-last
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: catch { }
Into: catch (ArgumentException) { }
*/
using System;
class Program
{
    static void Execute() { try { } catch { } catch (Exception) { } }
    static void Main() { }
}
