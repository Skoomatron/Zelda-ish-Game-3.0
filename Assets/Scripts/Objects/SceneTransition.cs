using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("Scene Transition Mechanics")]
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue storedPosition;
    [Header("Scene Animations")]
    public GameObject fadeIn;
    public GameObject fadeOut;
    public float fadeWait;
    private void Awake()
    {
        if(fadeIn != null)
        {
            GameObject panel = Instantiate(fadeIn, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            storedPosition.initialValue = playerPosition;
            StartCoroutine(FadeCo());
        }
    }

    private IEnumerator FadeCo()
    {
        if (fadeOut != null)
        {
            Instantiate(fadeOut, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
