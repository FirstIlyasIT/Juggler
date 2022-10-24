using System.Collections;

namespace JugglerClient.StorageContext;

public class JugglerList<T> : IEnumerable<T>, IEnumerable
{
    private readonly List<T> _items;

    public JugglerList(List<T> items)
    {
        _items = items;
    }

    public JugglerList()
    {
        _items = new List<T>();
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public T First(Func<T, bool> func)
    {
        return _items.First(func);
    }
    
    public T? FirstOrDefault(Func<T, bool> func)
    {
        return _items.FirstOrDefault(func);
    }
    
    public IList<T> ToList()
    {
        return _items;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}