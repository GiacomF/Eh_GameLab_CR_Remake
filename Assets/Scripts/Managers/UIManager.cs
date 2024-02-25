using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIManager>();
            if (_instance == null)
                Debug.LogError("UIManager not found, can't create singleton object");
            return _instance;
        }
    }

    private IGameUI currentUI;
    private Dictionary<GameUI, IGameUI> registeredUIs = new Dictionary<GameUI, IGameUI>();

    public Transform UiContainer;
    private void Awake()
    {
        foreach (IGameUI enumeratedUi in UiContainer.GetComponentsInChildren<IGameUI>(true))
        {
            RegisterUI(enumeratedUi.GetUIType(), enumeratedUi);
        }
        ShowUI(new List<GameUI>() { GameUI.NONE });
    }

    public void RegisterUI(GameUI UItype, IGameUI UItoRegister)
    {
        UItoRegister.Init();
        registeredUIs.Add(UItype, UItoRegister);

    }

    public void ShowUI(List<GameUI> UITypes)
    {
        foreach (KeyValuePair<GameUI, IGameUI> kvp in registeredUIs)
        {
            kvp.Value.SetActive(UITypes.Contains(kvp.Key));
        }
    }
}
