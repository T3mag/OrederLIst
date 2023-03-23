using System.Text;

namespace OrederLIst;

public class OrderedList<T> where T : IComparable
{
    private MyLinkedList<T> List;

    public OrderedList()
    {
        List = new MyLinkedList<T>();
    }

    public void Add(T value)
    {
        if (List.IsEmpty)
        {
            List.AddFirst(value);

        }
        else
        {
            ListEllement<T> previous = null;
            var current = List.Head;
            while (true)
            {
                if (current == null)
                {
                    List.AddLast(value);
                    break;
                }

                if (current.Value.CompareTo(value) == 0) break;

                if (value.CompareTo(current.Value) < 0)
                {
                    if (previous == null) List.AddFirst(value);
                    else
                    {
                        AddAfter(previous, value);
                    }

                    break;
                }

                previous = current;
                current = current.Next;
            }
        }
    }

    public void Delete(T value)
    {
        ListEllement<T> previous = null;
        foreach (var node in List)
        {
            if (value.CompareTo(node.Value) == 0)
            {
                if (previous == null) List.RemoveFirst();
                else
                {
                    RemoveAfter(previous);
                }

                break;
            }
        }
    }

    public void Merge(OrderedList<T> inputted)
    {
        var inPointer = List.Head;
        var outPointer = inputted.List.Head;

        ListEllement<T> previous = null; // Current List's previous pointer

        while (outPointer != null)
        {
            if (inPointer == null && outPointer != null)
            {
                var temp1 = previous.Next;
                var temp2 = outPointer.Next;
                previous.Next = outPointer;
                outPointer.Next = temp1;
                outPointer = temp2;
            }
            else
            {
                if (outPointer.Value.CompareTo(inPointer.Value) < 0)
                {
                    if (previous == null)
                    {
                        var temp = outPointer.Next;
                        outPointer.Next = inPointer;
                        outPointer = outPointer.Next;
                    }
                    else
                    {
                        var temp1 = previous.Next;
                        var temp2 = outPointer.Next;
                        previous.Next = outPointer;
                        outPointer.Next = temp1;
                        outPointer = temp2;
                    }
                }
                else
                {
                    previous = inPointer;
                    inPointer = inPointer.Next;
                }
            }
        }
    }

    public void AddAfter(ListEllement<T> listEllement, T value)
    {
        var temp = new ListEllement<T>(value);
        temp.Next = listEllement.Next;
        listEllement.Next = temp;
    }

    public ListEllement<T> RemoveAfter(ListEllement<T> listEllement)
    {
        ListEllement<T> result;
        if (listEllement == List.Tail) return null;

        if (listEllement.Next == List.Tail)
        {
            result = List.Tail;
            List.Tail = listEllement;
            return result;
        }

        result = listEllement.Next;
        listEllement = listEllement.Next.Next;
        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var node in List)
            sb.Append(node.Value + ",");
        var s = sb.ToString();
        return s;
    }
}