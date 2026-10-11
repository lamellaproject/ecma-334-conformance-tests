/*
Rules: E15-15-1-async-no-in-parameters
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Mutate: Read(in int value)
Into: Read(int value)
*/
using System.Threading.Tasks;
class Program { static async Task<int> Read(in int value) { await Task.FromResult(0); return value; } static void Main() { } }
