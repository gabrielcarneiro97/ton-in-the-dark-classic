using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsController : UserInterface
{
    SoundManager soundManager;
    public UserInterface menuUI;
    Slider ambientSlider, effectsSlider;
    // Start is called before the first frame update
    new void Start()
    {
        soundManager = SoundManager.instance;
        buttonNames.Add("BackToMenu");
        base.Start();

        ambientSlider = root.Q<Slider>("AmbientSlider");
        effectsSlider = root.Q<Slider>("EffectsSlider");

        ambientSlider.value = soundManager.ambientVolume;
        effectsSlider.value = soundManager.effectsVolume;

        ambientSlider.RegisterValueChangedCallback((ChangeEvent<float> ev) =>
        {
            soundManager.ChangeAmbientVolume(ev.newValue);
        });

        effectsSlider.RegisterValueChangedCallback((ChangeEvent<float> ev) =>
        {
            soundManager.ChangeEffectsVolume(ev.newValue);
        });

    }

    override public EventCallback<ClickEvent> HandleClick(string buttonName)
    {
        return buttonName switch
        {
            "BackToMenu" => (ClickEvent ev) =>
        {
            if (buttonName == "BackToMenu")
            {
                visible.value = false;
                menuUI.visible.value = true;
            }
        }
            ,
            _ => (ClickEvent ev) => { }
        };
    }


}
