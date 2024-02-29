using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour, IGameUI
{
    public GameUI UiType;

    public Image pressedButton;
    public Image unpressedButton;

    private bool isPressing = false;
    private bool isUIActive = false;
    private bool isCounting = false;

    public void Update()
    {
        if (isUIActive && !isCounting)
        {
            StartCoroutine(count());   
        }
        pressedButton.gameObject.SetActive(isPressing);
        unpressedButton.gameObject.SetActive(!isPressing);
    }

    public void Init()
    {}

    public void SetActive(bool active)
    {
        isUIActive = active;
        if (!active) 
        {
            isCounting = false;
        }
        gameObject.SetActive(active);
    }

    public GameUI GetUIType()
    {
        return UiType;
    }

    private IEnumerator count() 
    {
        isCounting = true;
        yield return new WaitForSeconds(0.75f);
        isPressing = !isPressing;
        isCounting = false;
    }
}
