/*
Rules: E16-2-3-no-async-use
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: ref struct Entry
Into: struct Entry
*/
using System.Threading.Tasks;
ref struct Entry { }
class Program
{
    static async Task Work(Entry item) { await Task.CompletedTask; }
    static void Main() { }
}
