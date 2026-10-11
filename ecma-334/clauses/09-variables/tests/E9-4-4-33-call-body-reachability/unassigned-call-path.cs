/*
Rules: E9-4-4-33-call-body-reachability; E9-4-4-33-call-site-analysis
Authority: ECMA-334 7th ed 9.4.4.33
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 0;
Csc: CS0165
*/
class Program
{
    static void Visit(bool early)
    {
        int cell;
        int Read() { return cell; }
        if (early) Read();
        cell = 29;
        Read();
    }
    static void Main() { Visit(false); }
}
