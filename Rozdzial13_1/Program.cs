public class BubbleSort
{
    public static int[] BubbleSorting(int[] items, SortType sortType)
    {
     
        for (int i = items.Length - 1; i >= 0; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                bool swap = false;
                switch (sortType)
                {
                    case SortType.Ascending:
                        swap = items[j - 1] > items[j];
                        break;

                    case SortType.Descending:
                        swap = items[j - 1] < items[j];
                        break;
                }
                if (swap)
                {
                    int temp = items[j - 1];
                    items[j - 1] = items[j];
                    items[j] = temp;
                }
            }
        }
        return items;
    }

    public static void Main2()
    {
        var x = BubbleSort.BubbleSorting(new int[] { 1, 3, 4, 2, }, SortType.Descending);
        foreach(var item in x)
            Console.WriteLine(item);
    }
}

public enum SortType
{
    Ascending,
    Descending
}

// delegateBubbleSort

class BubbleSortWithDelegate
{
    //public static int[] BubbleSortDelegate(int[] items, Func<int,int,bool> compare)
    public static int[] BubbleSortDelegate(int[] items, BubbleSortWithDelegate.Comparer compare)
    {
        if(compare == null)
            throw new ArgumentNullException(nameof(compare));

        for(int i = items.Length-1;i >=0; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                if(compare(items[j-1], items[j]))
                {
                    int temp = items[j - 1];
                    items[j-1] = items[j];
                    items[j] = temp;
                }
            }
        }
        return items;

    }
    

    //public delegate TResult Func<in T1, in T2, out TResult>(in T1 arg1, in T2 t2);
    public delegate TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);
    
    public delegate bool Comparer(int first, int second);

    // Examples of method for delegates to comparison
    public static bool GreaterThan(int first, int second)
    {
        return first.CompareTo(second) > 0;
    }

    public static bool AlphabeticalGreaterThan(int first, int second)
    {
        return first.ToString().CompareTo(second.ToString()) > 0;
    }

    public static void Main()
    {
        Console.WriteLine("Lambda expression: ascending");
        var firstSortByLambdaDelegate = BubbleSortWithDelegate.BubbleSortDelegate(new int[] { 1, 3, 4, 2, }, (int first, int second) => (first.CompareTo(second)) > 0 ? true : false);
        Display(firstSortByLambdaDelegate);

        Console.WriteLine($"\nAscending sorting");
        var secondSortByDelegateWithMethod = BubbleSortWithDelegate.BubbleSortDelegate(new int[] { 1,22, 5, 6, 11, 9, 3, 2, 0 }, new Comparer(GreaterThan));
        Display(secondSortByDelegateWithMethod);


        Console.WriteLine($"\nAlphabetical sorting");
        var thirdSortByDelegateWithMethod = BubbleSortWithDelegate.BubbleSortDelegate(new int[] { 1,22, 5, 6, 11, 9, 3, 2, 0 }, AlphabeticalGreaterThan);// in c# 3.0 not necessary new statement delegate
        Display(thirdSortByDelegateWithMethod);


        Console.WriteLine("\nLambda expression 2: descending");
        var fourSortByLambdaDelegate = BubbleSortDelegate(new int[] { 1, 3, 4, 2, }, (first, second) => { return first < second; }); // best way of creating lambda expression
        Display(fourSortByLambdaDelegate);
    }

    // generic display method, works with IEnumerable collection whose is IComparable
    public static void Display<T> (IEnumerable<T> collection) where T : IComparable<T>
    {
        foreach(T item in collection)
        {
            Console.WriteLine(item);
        }
    }


}