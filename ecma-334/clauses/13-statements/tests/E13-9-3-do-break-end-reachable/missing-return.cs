/*
Rules: E13-9-3-do-break-end-reachable
Authority: ECMA-334 7th ed 13.9.3
Version: 7.3
Expected: reject
Mutate: break;
Into: return 3;
*/
class Program
{
    static int Read() { do { break; } while (true); }
    static void Main() { }
}
