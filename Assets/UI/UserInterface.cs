
using UnityEngine;
using UnityEngine.UIElements;

public class UserInterface : MonoBehaviour
{
    public Observable<bool> visible = new(false);
    public UIDocument uiDocument;
    public VisualElement root;

    public void Start()
    {
        root = uiDocument.rootVisualElement;
        visible.value = root.visible;
        visible.Subscribe(HandleVisibleChange);
    }

    public void HandleVisibleChange(bool visible)
    {
        root.visible = visible;

    }

}
