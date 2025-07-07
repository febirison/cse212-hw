public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan for MultiplesOf:
    // 1. Create a new double array of size 'length' to store the multiples.
    // 2. Use a for loop to iterate from 1 to 'length' (inclusive).
    // 3. For each iteration i, calculate the multiple as number * i.
    // 4. Store the multiple in the array at index i-1.
    // 5. If length is 0, return an empty array.
    // 6. Return the array.

    // Create array of size 'length'
    double[] result = new double[length];

    // Handle edge case: if length is 0, return empty array
    if (length == 0)
        return result;

    // Loop to calculate multiples
    for (int i = 1; i <= length; i++)
    {
        result[i - 1] = number * i;
    }

    return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan for RotateListRight:
    // 1. Check if amount equals data.Count; if so, no rotation needed, return immediately.
    // 2. Normalize amount using amount % data.Count to handle large amounts (though not needed as amount is in [1, data.Count]).
    // 3. Use list slicing to split the list:
    //    a. Get the last 'amount' elements (data.GetRange(data.Count - amount, amount)) to move to the front.
    //    b. Get the first 'data.Count - amount' elements (data.GetRange(0, data.Count - amount)) to move to the end.
    //    c. Create a new list by concatenating: last 'amount' elements + first 'data.Count - amount' elements.
    //    d. Update the original data list to match the new rotated list.
    // 4. Handle edge cases: If data is empty, return immediately (no action needed).

    // If list is empty or amount equals data.Count, no rotation needed
    if (data.Count == 0 || amount == data.Count)
        return;

    // Normalize amount (optional, as amount is guaranteed in [1, data.Count])
    amount = amount % data.Count;

    // Get the two parts of the list
    List<int> lastPart = data.GetRange(data.Count - amount, amount); // Last 'amount' elements
    List<int> firstPart = data.GetRange(0, data.Count - amount);     // First 'data.Count - amount' elements

    // Clear the original list and add parts in rotated order
    data.Clear();
    data.AddRange(lastPart);
    data.AddRange(firstPart);
    }
}
