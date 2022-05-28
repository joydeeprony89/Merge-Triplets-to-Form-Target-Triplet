using System;
using System.Collections.Generic;

namespace Merge_Triplets_to_Form_Target_Triplet
{
  class Program
  {
    static void Main(string[] args)
    {
      var triplets = new int[4][] { new int[] { 2, 5, 3 }, new int[] { 2, 3, 4 }, new int[] { 1, 2, 5 }, new int[] { 5, 2, 3 } };
      var target = new int[] { 5, 5, 5 };

      Solution s = new Solution();
      s.MergeTriplets(triplets, target);
    }

  }

  public class Solution
  {
    public bool MergeTriplets(int[][] triplets, int[] target)
    {
      // Algorithm
      // eliminate the items in triplets, if at any position of that set no is gt the target same position no
      // why so ?[1,8,4] for this at 2 position we have 8 and target we have as 7, so from this set we will never get the solution as we take Max(8, canbe smaller or bigger no than 8), so will get always 8 or more from this set

      // After eleminating those sets from the rest of the sets in triplets we are left with the sets where each no at same position of the target we are having the same no of lesser no, How ? because all the sets where at any position we had bigger no than target posiiton are eliminated.
      // After eleminating those sets from the rest of the sets in triplets we have to see at any position of a set we have a same no as compared to target same position, How to ? Will have a hashset and push nos if any no we have found which is smaller or equal to the target position no. 
      // after looping the entire triplets if the set count is three which means we have found sets where at any given position same as target posiition we are having no which is equal to target posiiton no

      Dictionary<int, int> hash = new Dictionary<int, int>();
      foreach (var set in triplets)
      {
        //Step -1 - Eliminate the sets which having bigger nos
        if (set[0] > target[0] || set[1] > target[1] || set[2] > target[2]) continue;

        // Step -2 - If match found add at that specific position where match found.
        if (set[0] == target[0] && !hash.ContainsKey(0)) hash.Add(0, set[0]);
        if (set[1] == target[1] && !hash.ContainsKey(1)) hash.Add(1, set[1]);
        if (set[2] == target[2] && !hash.ContainsKey(2)) hash.Add(2, set[2]);
      }

      return hash.Count == 3 && hash[0] == target[0] && hash[1] == target[1] && hash[2] == target[2];
    }
  }
}
