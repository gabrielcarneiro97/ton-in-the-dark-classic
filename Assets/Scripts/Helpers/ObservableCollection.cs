

using System.Collections.Generic;
using UnityEngine.Events;

public class ObservableCollection<C, T> where C : ICollection<T>
{

    private C _value;

    private readonly UnityEvent<C> onValueChanged = new();

    public C value
    {
        get => _value;
    }

    public ObservableCollection(C value)
    {
        _value = value;
    }

    public void Add(T item)
    {
        _value.Add(item);
        onValueChanged.Invoke(_value);
    }

    public void Remove(T item)
    {
        _value.Remove(item);
        onValueChanged.Invoke(_value);
    }

    public void Subscribe(UnityAction<C> action)
    {
        onValueChanged.AddListener(action);
    }

    public void Unsubscribe(UnityAction<C> action)
    {
        onValueChanged.RemoveListener(action);
    }
}
