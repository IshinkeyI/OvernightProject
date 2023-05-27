using UnityEngine;

public class TicketLogic : MonoBehaviour
{
    [SerializeField] private GameObject tetheredClown;
    [SerializeField] private bool isFirstTicket;

    private TicketManager _ticketManager;
    private UIManager _uiManager;

    private void Start()
    {
        _ticketManager = FindObjectOfType<TicketManager>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;
        _uiManager.SetTicketDescription(_ticketManager.GetRandomDescription());

        if(isFirstTicket) return;
        
        DestroyAction da = tetheredClown.GetComponent<DestroyAction>();
        if(da is null) return;
        
        da.target = Enums.Targets.None;
        da.ExecuteAction(null);
    }
}
