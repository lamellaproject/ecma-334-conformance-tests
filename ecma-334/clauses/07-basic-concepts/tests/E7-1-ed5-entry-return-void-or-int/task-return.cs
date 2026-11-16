/*
Rules: E7-1-ed5-entry-return-void-or-int
Authority: ECMA-334 5th ed 8.1
Version: 5
Expected: reject
Version-Witness: version-witnesses/E7-1-ed5-entry-return-void-or-int/task-return.cs.part
Mutate: static Task Main()
Into: static void Main()
*/
using System.Threading.Tasks;
// ECMA-334 5th ed 8.1, p. 36 (PDF p. 58).
class Program
{
    static Task Main() { throw null; }
}
