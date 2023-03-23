using System.Collections;

namespace OrederLIst;

public class ListEllement<T>
{
    public T Value { get; }
    public ListEllement<T> Next { get; set; }

    public ListEllement(T value)
    {
        Value = value;
    }
}


public class MyLinkedList<T> : IEnumerable<ListEllement<T>>
{
    public ListEllement<T> Head;
    public ListEllement<T> Tail;

    public MyLinkedList()
    {
        Head = null;
        Tail = Head;
    }

    public void AddFirst(T value)
    {
        if (Head == null)
        {
            Head = new ListEllement<T>(value);
            Tail = Head;
        }
        else
        {
            var t = new ListEllement<T>(value);
            t.Next = Head;
            Head = t;
        }
    }

    public void AddLast(T value)
    {
        if (Head == null) 
            AddFirst(value);
        
        Tail.Next = new ListEllement<T>(value);
        Tail = Tail.Next;
    }

    public void AddAfter(ListEllement<T> listEllement, T value)
    {
        var temp = new ListEllement<T>(value);
        temp.Next = listEllement.Next;
        listEllement.Next = temp;
    }

    public ListEllement<T> RemoveFirst()
    {
        if (Head == null) { }

        ListEllement<T> result = Head;
        
        Head = Head.Next;
        
        return result;
    }

    public ListEllement<T> RemoveAfter(ListEllement<T> listEllement)
    {
        ListEllement<T> result;
        if (listEllement == Tail) return null;

        if (listEllement.Next == Tail)
        {
            result = Tail;
            Tail = listEllement;
            return result;
        }
        result = listEllement.Next;
        listEllement = listEllement.Next.Next;
        return result;
    }
    public bool IsEmpty => (Head == null);
    public IEnumerator<ListEllement<T>> GetEnumerator()
    {
        if (IsEmpty)
        {
            yield break;
        }
        
        var current = Head;
        
        while (current.Next != null)
        {
            yield return current;
            current = current.Next;
        }

        yield return current;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}  