using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject ticketDescriptionParent;
    [SerializeField] private TextMeshProUGUI ticketDescription;
    [SerializeField] private Button exitButton;
    [SerializeField] private Text ticketCount;

    [SerializeField] private GameObject winWindowParent;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button reloadButton;

    [SerializeField] private GameObject startDescriptionParent;
    [SerializeField] private Button closeStartDesc;

    [SerializeField] private Image startWindowImage;

    private TicketManager _ticketManager;
    private void Start()
    {
        StartCoroutine(StartWindowCor());
        closeStartDesc.onClick.AddListener(()=>startDescriptionParent.SetActive(false));
        closeStartDesc.onClick.AddListener(()=>TimeController.SetActiveGame(true));

        _ticketManager = FindObjectOfType<TicketManager>();
        ticketCount.text = _ticketManager.CountOfTicketFound + "|" + _ticketManager.AllTicketsCount;

        winWindowParent.SetActive(false);
        closeButton.onClick.AddListener(()=>SceneManager.LoadScene(0));
        reloadButton.onClick.AddListener(()=>SceneManager.LoadScene(SceneManager.GetActiveScene().name));

        ticketDescriptionParent.SetActive(false);
        exitButton.onClick.AddListener(DisableDescription);
    }

    public void SetTicketDescription(string s)
    {
        ticketDescription.text = s;
        ticketDescriptionParent.SetActive(true);
        TimeController.SetActiveGame(false);
    }

    private IEnumerator StartWindowCor()
    {
        startWindowImage.enabled = true;
        float f = 1f;
        while (f > 0)
        {
            yield return new WaitForSeconds(0.05f);
            startWindowImage.color = new Color(0,0,0,f);
            f -= 0.05f;
        }
        startDescriptionParent.SetActive(true);
        startWindowImage.gameObject.SetActive(false);
        TimeController.SetActiveGame(false);
    }
    
    private void DisableDescription()
    {
        TimeController.SetActiveGame(true);
        ticketDescriptionParent.SetActive(false);
        _ticketManager.SetTicketCount();
        ticketCount.text = _ticketManager.CountOfTicketFound + "|" + _ticketManager.AllTicketsCount;
    }

    public void SetWinWindow()
    {
        winWindowParent.SetActive(true);
    }
    
}