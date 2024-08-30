using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public int sceneBuildIndex;

    private void Start()
    {
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void OnTriggerEnter2D(Collider2D colllison)
    {
        print("Scene changed to: " + sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
