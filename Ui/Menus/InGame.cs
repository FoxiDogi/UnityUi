using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGame : ScreenBase
{
    public string Score { get { return Score; } set { ScoreText.text = value; } }
    [SerializeField] private Text ScoreText;
}
