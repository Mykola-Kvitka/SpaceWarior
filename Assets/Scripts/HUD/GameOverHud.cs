using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUD
{
    public class GameOverHud : MonoBehaviour
    { 
        private void Start()
        {
            Time.timeScale = 0;
        }
        public void HandleRestartButtonOnClickEvent()
        {
            Time.timeScale = 1;
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    
        public void HandleQuitButtonOnClickEvent()
        {
            Time.timeScale = 1;
            Application.Quit();
            Destroy(gameObject);
        }

    }
}
