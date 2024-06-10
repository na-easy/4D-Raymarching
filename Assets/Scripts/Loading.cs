using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Text LoadingPercentage;
    public Image LoadingProgressBar;

    private static Loading instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(int sceneNum)
    {
        instance.componentAnimator.SetTrigger("SceneClosing");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneNum);
        instance.loadingSceneOperation.allowSceneActivation = false;

        instance.LoadingProgressBar.fillAmount = 0;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        componentAnimator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            componentAnimator.SetTrigger("SceneOpening");

            instance.LoadingProgressBar.fillAmount = 1;

            shouldPlayOpeningAnimation = false;
        }
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            LoadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";

            // Просто присвоить прогресс:
            //LoadingProgressBar.fillAmount = loadingSceneOperation.progress; 

            // Присвоить прогресс с быстрой анимацией, чтобы ощущалось плавнее:
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, loadingSceneOperation.progress,
                Time.deltaTime * 5);
        }
    }

    public void OnAnimationOver()
    {
        // Чтобы при открытии сцены, куда мы переключаемся, проигралась анимация opening:
        shouldPlayOpeningAnimation = true;

        loadingSceneOperation.allowSceneActivation = true;
    }
}
