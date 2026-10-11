/*
Rules: E13-6-4-async-own-scope
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: void Local()
Into: async void Local()
*/
using System.Threading.Tasks;
class Program
{
    static async void Work() { void Local() { await Task.CompletedTask; } }
    static void Main() { }
}
