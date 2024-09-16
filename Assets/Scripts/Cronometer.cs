using System.Collections;
using System.Collections.Generic;
using BNG;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cronometer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float duration, currentTime;
    
    
    public LoadSceneMode loadSceneMode = LoadSceneMode.Single;
    public bool useSceenFader = true;
    public float screenFadeTime = 0.5f;

    ScreenFader sf;
    public string _loadSceneName = string.Empty;
    
    void Start()
    {
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        TimerEndingEvent(SceneName: _loadSceneName);
    }

    void TimerEndingEvent(string SceneName)
    {
        _loadSceneName = SceneName;
        if (useSceenFader) {
            StartCoroutine("FadeThenLoadScene");
        }
        else {
            SceneManager.LoadScene(_loadSceneName, loadSceneMode);
        }
    }
    
    public IEnumerator FadeThenLoadScene() {

        if (useSceenFader) {
            if (sf == null) {
                sf = FindObjectOfType<ScreenFader>();
                // May not have found anything
                if (sf != null) {
                    sf.DoFadeIn();
                }
            }
        }

        if(screenFadeTime > 0) {
            yield return new WaitForSeconds(screenFadeTime);
        }

        SceneManager.LoadScene(_loadSceneName, loadSceneMode);
    }
}
