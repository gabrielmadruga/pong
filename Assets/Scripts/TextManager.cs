using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour, GameState.EventListener
{
    [SerializeField] private GameState GameState = null;
    [SerializeField] private TextMeshProUGUI mainMessage = null;
    [SerializeField] private TextMeshProUGUI player1Score = null;
    [SerializeField] private TextMeshProUGUI player2Score = null;

    public void PlayerScores(int n)
    {
        if (n == 1)
        {
            player1Score.text = (int.Parse(player1Score.text) + 1).ToString();
        }
        else
        {
            player2Score.text = (int.Parse(player2Score.text) + 1).ToString();
        }
    }

    private void OnEnable()
    {
        GameState.RegisterListener(this);
    }

    private void OnDisable()
    {
        GameState.UnregisterListener(this);
    }

    public void OnSateChanged()
    {
        mainMessage.gameObject.SetActive(!GameState.Playing);
        player1Score.text = GameState.Player1Score.ToString();
        player2Score.text = GameState.Player2Score.ToString();
    }
}
