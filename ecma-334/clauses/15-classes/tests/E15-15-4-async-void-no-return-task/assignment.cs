/*
Rules: E15-15-4-async-void-no-return-task
Authority: ECMA-334 7th ed 15.15.4
Version: 7.3
Expected: reject
Mutate: Task task = Work();
Into: Work();
*/
using System.Threading.Tasks;
class Program
{
    static async void Work() { await Task.FromResult(0); }
    static void Main() { Task task = Work(); }
}
