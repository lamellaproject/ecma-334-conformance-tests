/*
Rules: E7-1-ed5-entry-without-async
Authority: ECMA-334 5th ed 8.1
Version: 5
Expected: reject
Version-Witness: version-witnesses/E7-1-ed5-entry-without-async/async-void.cs.part
Mutate: static async void Main()
Into: static void Main()
*/
// ECMA-334 5th ed 8.1, p. 36 (PDF p. 58).
class Program
{
    static async void Main() { }
}
