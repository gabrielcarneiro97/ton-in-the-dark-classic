
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UserInterface : MonoBehaviour
{
    public List<string> buttonNames = new List<string>();
    public Observable<int> selectedButton = new(0);
    public Dictionary<string, Button> buttons = new();
    public bool defaultVisibility = true;
    public Observable<bool> visible = new(false);
    public UIDocument uiDocument;
    public VisualElement root;

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    const string submitButton = "Submit_Mac";
#elif UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    const string submitButton = "Submit_Windows";
#endif

    public void Start()
    {
        root = uiDocument.rootVisualElement;
        visible.value = root.visible;
        visible.Subscribe(HandleVisibleChange);

        foreach (var buttonName in buttonNames)
        {
            var button = root.Q<Button>(buttonName);
            button.RegisterCallback(HandleClick(buttonName));
            buttons[buttonName] = button;
            button.RegisterCallback((FocusEvent ev) =>
            {
                selectedButton.value = buttonNames.IndexOf(buttonName);
            });
        }

        selectedButton.Subscribe((int index) =>
        {
            if (index >= 0)
            {
                foreach (var buttonName in buttonNames)
                    buttons[buttonName].RemoveFromClassList("selected");
                buttons[buttonNames[index]].AddToClassList("selected");
            }
        });

        if (buttons.Count > 0) buttons[buttonNames[selectedButton.value]].AddToClassList("selected");
        visible.value = defaultVisibility;
    }

    virtual public EventCallback<ClickEvent> HandleClick(string buttonName)
    {
        return (ClickEvent ev) => { };
    }

    public void HandleVisibleChange(bool visible)
    {
        root.visible = visible;

    }

    public void Update()
    {
        if (visible.value == false) return;
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var newSelectedButton = selectedButton.value + 1;
            if (newSelectedButton >= buttonNames.Count) selectedButton.value = 0;
            else selectedButton.value = newSelectedButton;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var newSelectedButton = selectedButton.value - 1;
            if (newSelectedButton < 0) selectedButton.value = buttonNames.Count - 1;
            else selectedButton.value = newSelectedButton;
        }
        else if (Input.GetButtonDown(submitButton))
        {
            if(buttonNames.Count > 0)
                HandleClick(buttonNames[selectedButton.value])(null);
        }
    }

}
