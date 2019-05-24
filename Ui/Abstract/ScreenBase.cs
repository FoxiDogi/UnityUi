using UnityEngine;
using System.Collections;
using Sigtrap.Relays;
using UnityEngine.Events;
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
    public UnityEvent ShowEvent;
    public UnityEvent HideEvent;
    private ScreenState state;
    public ScreenState State { get => state;}

    private ScreenState _currentState;
    public ScreenState CurrentState { get { return _currentState; } protected set { ScreenState oldstate = _currentState; _currentState = value; OnStateChanged(oldstate, _currentState); } }
    private void Awake()
    {
     //   Showing.AddListener(ShowHandler);
    }
    public virtual void Show()
    {
        CurrentState = ScreenState.Shown;
    }
    protected virtual void OnStateChanged(ScreenState oldState, ScreenState newState)
    {
       UiManager.Instance.OnScreenStateChanged(this, oldState, newState);
    }
    public virtual void Hide()
    {
        CurrentState = ScreenState.Hidden;
    }
}
