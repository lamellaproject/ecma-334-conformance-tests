/*
Rules: E15-15-1-async-no-out-parameters
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Mutate: Read(out int value)
Into: Read(int value)
*/
using System.Threading.Tasks;
class Program { static async Task<int> Read(out int value) { value = 13; await Task.FromResult(0); return value; } static void Main() { } }
