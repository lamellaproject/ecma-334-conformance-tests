/*
Rules: E15-15-1-valueless-task-nongeneric
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Mutate: return;
Into: return 13;
*/
using System.Threading.Tasks;
class Program { static async Task<int> Read() { await Task.FromResult(0); return; } static void Main() { } }
