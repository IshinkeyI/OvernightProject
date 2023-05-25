using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class Note : MonoBehaviour
{
    [SerializeField, TextArea(6, 12, order = 15)] private string noteText;
    private UIManager _uiManager;

    public static int NotesCount { get; private set; }

    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        enabled = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        enabled = false;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.R)) return;
        
        NotesCount++;
        _uiManager.SetNoteText(noteText);
        gameObject.SetActive(false);
    }
}
