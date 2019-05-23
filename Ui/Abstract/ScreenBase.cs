using UnityEngine;
using System.Collections;
using Sigtrap.Relays;
public enum ScreenState
{
    Showing,Hiding,Hidden,Shown
}
public interface IScreen
{
    void Show();
    void Hide();
}

public abstract class ScreenBase : MonoBehaviour,IScreen
{
   // [SerializeField] private Relay<bool> Showing;
   
    private ScreenState state;
    public ScreenState State { get => state;}
    private void Awake()
    {
     //   Showing.AddListener(ShowHandler);
    }
    public virtual void Show()
    {
       // Showing.Dispatch(true);
        gameObject.SetActive(true);
        state = ScreenState.Shown;
    }
    private void ShowHandler(bool e)
    {
        //???????
    }
    public virtual void Hide()
    {
       // Showing.Dispatch(false);

        gameObject.SetActive(false);
        state = ScreenState.Hidden;
    }
}
