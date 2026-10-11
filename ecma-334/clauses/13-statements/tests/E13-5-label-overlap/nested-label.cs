/*
Rules: E13-5-label-overlap
Authority: ECMA-334 7th ed 13.5
Version: 7.3
Expected: reject
Mutate: { mark: ; }
Into: { other: ; }
*/
class Program
{
    static void Main() { mark: ; { mark: ; } }
}
