/*
Rules: E7-1-entry-async-return-restriction
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: static async void Main()
Into: static async Task Main()
*/
using System.Threading.Tasks;
class Program
{
    static async void Main() { await Task.Delay(1); }
}
