using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class MenuButtons : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }
        
        public void LoadSceneNumber(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}