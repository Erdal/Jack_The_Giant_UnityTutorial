using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;

	void Awake()
    {
        MakeSingleton();
	}

    void MakeSingleton()
    { //Here we are making sure that this class never gets deleted when we leave the original scene it is made in
      //We are also making sure that when we return to this scene we do not create the same class again.
        if (instance != null)
        {
            Destroy(gameObject); //destroy object
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Dont destroy object
        }
    }

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true); //Turn on panel
        fadeAnim.Play("FadeIn"); //Fade it in
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.2f)); //wait a moment
        SceneManager.LoadScene(level); //Change scene
        fadeAnim.Play("FadeOut"); //Fade out to scene
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f)); //Wait some more
        fadePanel.SetActive(false); //Turn off panel
    }
}
