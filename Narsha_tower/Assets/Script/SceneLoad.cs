using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//완료된스크립트
public class SceneLoad : MonoBehaviour
{
    public Slider progresbar;
    public Text loadtext;
    public static string Scenepath = null;
    public static void LoadScene(string Scenename)
    {
        Scenepath = Scenename;
        SceneManager.LoadScene("LoadingScene");
    }
    private void Start()
    {
        StartCoroutine(LoadSceneStart());
    }
    IEnumerator LoadSceneStart()
    {
        if (string.IsNullOrEmpty(Scenepath)) yield break;
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(Scenepath);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            yield return null;
            if (progresbar.value < 1f)
            {
                progresbar.value = Mathf.MoveTowards(progresbar.value, 1f, Time.deltaTime);
            }
            if (progresbar.value > 0.9f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
                Debug.Log("넘어간다 꽉 잡아");
            }
        }
        Scenepath = null;
    }
}
