/*
Rules: E15-15-1-value-task-generic
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Mutate: return 13;
Into: return;
*/
using System.Threading.Tasks;
class Program { static async Task Read() { await Task.FromResult(0); return 13; } static void Main() { } }
