using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SliderLoadScene : SliderBase
{
    [SerializeField] private float timePerPercent = 0.05f; // Thời gian để tăng 1%
    private AsyncOperation asyncOperation;
    private bool isLoadingComplete = false;

    protected override void Start()
    {
        base.Start();
        slider.minValue = 0;
        slider.maxValue = 1;
        slider.value = 0;
        StartCoroutine(LoadSceneAsync());
    }

    protected override void OnChange(float amount)
    {
        if (slider != null)
        {
            slider.value = amount;
            Debug.Log("Loading progress: " + ((float)amount * 100) + "%");
        }
    }

    IEnumerator LoadSceneAsync()
    {
        // Bắt đầu tải scene thực sự (nhưng chưa kích hoạt)
        if (UIManager.Instance.currentScene == UIManager.SceneType.MAINMENU)
        {
            asyncOperation = UIManager.Instance.ChangeScene(UIManager.SceneType.GAMEPLAY);
        }
        else if (UIManager.Instance.currentScene == UIManager.SceneType.GAMEPLAY)
        {
            asyncOperation = UIManager.Instance.ChangeScene(UIManager.SceneType.MAINMENU);
        }

        if (asyncOperation != null)
        {
            asyncOperation.allowSceneActivation = false;

            // Bắt đầu coroutine tăng từng phần trăm
            StartCoroutine(IncrementLoadingBar());

            // Đợi cho đến khi loading UI đạt 100% và loading thực sự hoàn tất
            while (!isLoadingComplete || asyncOperation.progress < 0.9f)
            {
                yield return null;
            }

            // Đợi thêm 2 giây sau khi đã tăng đến 100%
            yield return new WaitForSeconds(0.2f);

            // Cho phép kích hoạt scene mới
            asyncOperation.allowSceneActivation = true;
        }
    }

    IEnumerator IncrementLoadingBar()
    {
        // Tăng dần từ 0 đến 100%
        for (int i = 0; i <= 100; i++)
        {
            float progress = i / 100f;
            OnChange(progress);

            // Đợi một khoảng thời gian nhỏ trước khi tăng tiếp
            yield return new WaitForSeconds(timePerPercent);
        }

        isLoadingComplete = true;
    }
}