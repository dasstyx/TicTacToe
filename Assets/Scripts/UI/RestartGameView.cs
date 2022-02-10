using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace tictac.UI
{
    [RequireComponent(typeof(Button))]
    public class RestartGameView : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}