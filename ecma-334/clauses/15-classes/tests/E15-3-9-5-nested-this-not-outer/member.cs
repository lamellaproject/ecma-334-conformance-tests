/*
Rules: E15-3-9-5-nested-this-not-outer
Authority: ECMA-334 7th ed 15.3.9.5
Version: 7.3
Expected: reject
Mutate: return this.code;
Into: return new Host().code;
*/
class Host
{
    private int code;
    public class Node { public int Read() { return this.code; } }
}
class Program { static void Main() { } }
