using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class EndOfLevel : MonoBehaviour
{
    private int _allNotesCount;
    private UIManager _uiManager;
    private ParticleSystem _fireParticle;

    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _fireParticle = GetComponentInChildren<ParticleSystem>();
        _fireParticle.Stop();
        GetComponent<BoxCollider>().isTrigger = true;
        _allNotesCount = FindObjectsOfType<Note>().Length;
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
        if(Note.NotesCount == _allNotesCount && _fireParticle.isStopped)
            _fireParticle.Play();
        
        if (_fireParticle.isStopped || !Input.GetKeyDown(KeyCode.R)) return;
        
        _fireParticle.Stop();
        _uiManager.ActivateWinCanvas();
    }
}
