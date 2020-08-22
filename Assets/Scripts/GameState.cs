using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class GameState : ScriptableObject
{
    

    private bool _playing;
    public bool Playing
    {
        get { return _playing; }
        set
        {
            _playing = value;
            Raise();
        }
    }

    private int _player1Score;
    public int Player1Score
    {
        get { return _player1Score; }
        set
        {
            _player1Score = value;
            Raise();
        }
    }

    private int _player2Score;
    public int Player2Score
    {
        get { return _player2Score; }
        set
        {
            _player2Score = value;
            Raise();
        }
    }

    // Listener pattern stuff
    public interface EventListener
    {
        void OnSateChanged();
    }

    private readonly List<EventListener> eventListeners =
        new List<EventListener>();

    private void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnSateChanged();
    }

    public void RegisterListener(EventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(EventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

}
