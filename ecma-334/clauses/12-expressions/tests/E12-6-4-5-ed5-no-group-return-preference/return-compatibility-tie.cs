/*
Rules: E12-6-4-5-ed5-no-group-return-preference
Authority: ECMA-334 5th ed 12.6.4.4
Version: 5
Expected: reject
Version-Witness: version-witnesses/E12-6-4-5-ed5-no-group-return-preference/return-compatibility-tie.cs.part
Mutate: Route(Read)
Into: Route((Number)Read)
*/
// ECMA-334 5th ed 11.8, pp. 107-108 (PDF pp. 129-130),
// and 12.6.4.1, 12.6.4.4, pp. 133-135 (PDF pp. 155-157).
delegate int Number(int input);
delegate object Boxed(int input);
class Program
{
    static int Read(int input) { return input + 3; }
    static void Route(Number reader) { }
    static void Route(Boxed reader) { }
    static void Main()
    {
        Route(Read);
    }
}
