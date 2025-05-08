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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Step one: Create a new doubles array, it's "length" will be the size
        //Step two: Use a for loop to get the array data
        //Step three: Start with index being 0 to the length -1 (because we want it to be the length number and the array will start at 0)
        //Step four: The result will be multiply the number by the place it is in the length
        //Step five: Return the array after the loop is done

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i+1);
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Step one: Determine the count of the data and assign it to a variable
        //Step two: Split the data into two parts
        //Step three: Clear the old list
        //Step four: Join the two lists

        int count = data.Count;

        List<int> lastPart = data.GetRange(count-amount, amount);

        List<int> firstPart = data.GetRange(0, count-amount);

        data.Clear();

        data.AddRange(lastPart);
        data.AddRange(firstPart);

    }
}
