using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : Singleton<UiManager>
{
    [SerializeField] private List<ScreenBase> Screens;
    private IScreen currentScreen;
    public IScreen CurrentScreen { get => currentScreen; }

    private void Test()
    {
        GetScreen<MainMenu>().HelloText = "HelloWorld";
        ShowScreen(GetScreen<MainMenu>());
    }
    public T GetScreen<T>() where T : IScreen
    {
        ScreenBase window = Screens.Find(x => x.GetType() == typeof(T));
        return (T)(object)window;
    }
    public void ShowScreen(IScreen window)
    {
        if (currentScreen==null)
            currentScreen = window;

        currentScreen.Hide();
        currentScreen = window;
        currentScreen.Show();
    }
}
