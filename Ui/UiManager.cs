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
     
    }
    public T GetScreen<T>() where T : ScreenBase
    {
        ScreenBase window = Screens.Find(x => x.GetType() == typeof(T));
        return (T)(object)window;
    }
    public void  OnScreenStateChanged(ScreenBase screen, ScreenState oldState, ScreenState newState)
    {
       
    }
    public T Show<T>() where T: ScreenBase
    {
        ScreenBase screen = GetScreen<T>();
        screen.Show();
        return (T)screen;
    }
    public T Hide<T>() where T : ScreenBase
    {
        ScreenBase screen = GetScreen<T>();
        screen.Hide();
        return (T)screen;
    }
}
