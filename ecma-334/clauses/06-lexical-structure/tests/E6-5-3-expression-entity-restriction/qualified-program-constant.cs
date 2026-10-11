/*
Rules: E6-5-3-expression-entity-restriction
Authority: ECMA-334 7th ed 6.5.3
Version: 7.3
Expected: reject
Mutate: #if Program.Known
Into: #if true
*/
class Program
{
    public const bool Known = true;
    static void Main()
    {
#if Program.Known
        return;
#endif
    }
}
