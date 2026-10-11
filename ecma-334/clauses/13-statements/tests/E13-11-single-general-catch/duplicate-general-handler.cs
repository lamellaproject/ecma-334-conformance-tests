/*
Rules: E13-11-single-general-catch
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: reject
Mutate: catch { int second = 2; }
Into: finally { int second = 2; }
*/
using System;
class Program
{
    static void Execute() { try { } catch { } catch { int second = 2; } }
    static void Main() { }
}
