using UnityEngine.Events;

public class Observable<T>
{
    private T _value;
    public T value
    {
        get => _value;
        set
        {
            _value = value;
            onValueChanged.Invoke(value);
        }
    }

    private readonly UnityEvent<T> onValueChanged = new();

    public Observable(T value)
    {
        this.value = value;
    }

    public void Subscribe(UnityAction<T> action)
    {
        onValueChanged.AddListener(action);
    }

    public void Unsubscribe(UnityAction<T> action)
    {
        onValueChanged.RemoveListener(action);
    }
}
