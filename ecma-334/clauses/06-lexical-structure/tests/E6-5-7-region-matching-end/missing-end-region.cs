/*
Rules: E6-5-7-region-matching-end
Authority: ECMA-334 7th ed 6.5.7
Version: 7.3
Expected: reject
Mutate: #region unmatched
Into: // removed opener
*/
#region unmatched
class Program { static void Main() { } }
