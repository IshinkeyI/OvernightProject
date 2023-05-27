using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TicketManager : MonoBehaviour
{
    [SerializeField] private List<string> ticketDescription;

    private UIManager _uiManager;
    private int _allTicketsCount;
    private int _countOfTicketFound;
    
    public int AllTicketsCount => _allTicketsCount;

    public int CountOfTicketFound => _countOfTicketFound;

    private void Start()
    {
        _allTicketsCount = FindObjectsOfType<TicketLogic>().Length;
        _uiManager = FindObjectOfType<UIManager>();
    }

    public string GetRandomDescription()
    {
        int i = Random.Range(0, ticketDescription.Count);
        string s = ticketDescription[i];
        ticketDescription.Remove(s);
        return s;
    }

    public void SetTicketCount()
    {
        _countOfTicketFound++;

        if (_countOfTicketFound == _allTicketsCount)
            _uiManager.SetWinWindow();
    }
    
    
}