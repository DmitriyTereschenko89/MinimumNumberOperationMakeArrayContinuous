Solution solution = new();
Console.WriteLine(solution.MinOperations(new int[] { 4, 2, 5, 3 }));
Console.WriteLine(solution.MinOperations(new int[] { 1, 2, 3, 5, 6 }));
Console.WriteLine(solution.MinOperations(new int[] { 1, 10, 100, 1000 }));

class Solution
{
	private int BinarySearch(List<int> nums, int target)
	{
		int l = 0;
		int r = nums.Count;
		while (l < r)
		{
			int m = (l + r) / 2;
			if (nums[m] <=  target)
			{
				l = m + 1;
			}
			else
			{
				r = m;
			}
		}
		return l;
	}

	public int MinOperations(int[] nums)
	{
		int n = nums.Length;
		int minOperations = int.MaxValue;
		SortedSet<int> uniqueNums = new();
		foreach (int num in nums)
		{
			uniqueNums.Add(num);
		}
		List<int> newArray = uniqueNums.ToList();
		for (int i = 0; i < newArray.Count; ++i)
		{
			int left = newArray[i];
			int right = left + n - 1;
			int j = BinarySearch(newArray, right);
			int count = j - i;
			minOperations = Math.Min(minOperations, n - count);
		}
		return minOperations;
	}
}