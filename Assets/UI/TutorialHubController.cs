using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TutorialHubController : UserInterface
{
    List<VisualElement> tutorials = new();

    new void Start()
    {
        base.Start();

        tutorials.Add(root.Q<VisualElement>("WalkTutorial"));
        tutorials.Add(root.Q<VisualElement>("InteractTutorial"));
        tutorials.Add(root.Q<VisualElement>("OpenMenuTutorial"));

    }

    new void Update() { }

    public void StartTutorials()
    {
        StartCoroutine(RunAllTutorials());
    }

    IEnumerator RunAllTutorials()
    {
        foreach (var tutorial in tutorials)
        {
            if (tutorial.ClassListContains("opacity-0"))
            {
                tutorial.ToggleInClassList("opacity-0");
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForSeconds(1f);
            tutorial.ToggleInClassList("opacity-0");
            yield return new WaitForSeconds(2f);
        }
    }


}
