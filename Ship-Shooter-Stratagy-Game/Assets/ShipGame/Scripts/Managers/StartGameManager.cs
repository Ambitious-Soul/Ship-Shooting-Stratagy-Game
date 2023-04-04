using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameManager : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void SoundCredit()
    {
        Application.OpenURL("https://pixabay.com/users/moodmode-33139253/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=138828");
    }

}
