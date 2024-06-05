namespace AtividadesGoo;

public static class ListExtensions
{
    public static void RemoveRepetidos<T>(this List<T> list)
    {
        HashSet<T> seen = new HashSet<T>();
        int index = 0;

        while (index < list.Count)
        {
            if (seen.Contains(list[index]))
            {
                list.RemoveAt(index);
            }
            else
            {
                seen.Add(list[index]);
                index++;
            }
        }
    }
}
