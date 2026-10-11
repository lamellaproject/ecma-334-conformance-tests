/*
Rules: E15-15-1-async-no-ref-parameters
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Mutate: Read(ref int value)
Into: Read(int value)
*/
using System.Threading.Tasks;
class Program { static async Task<int> Read(ref int value) { await Task.FromResult(0); return value; } static void Main() { } }
