using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject parentOfWinningsWindow;
    [SerializeField] private GameObject parentOfNoteText;
    [SerializeField] private Text noteText;

    public void ActivateWinCanvas()
    {
        parentOfWinningsWindow.SetActive(true);
        TimeController.SetActiveGame(false);
    }

    public void SetNoteText(string text)
    {
        parentOfNoteText.SetActive(true);        
        TimeController.SetActiveGame(false);
        noteText.text = text;
    }
    
    //---------Events In Buttons-----------
    public void CloseNoteWindow()
    {
        parentOfNoteText.SetActive(false);
        TimeController.SetActiveGame(true);
    }
    public void Quit() => Application.Quit();

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}