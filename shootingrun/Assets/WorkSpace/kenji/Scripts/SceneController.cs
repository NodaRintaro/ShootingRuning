using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Collider ChangeScene;
    public Button StartScene;
    public string Scene;//移行先のゲームシーンをinspectorに書きなさい
    public Button GameScene;
    public string Scene2;
    public Button OnotherScene;//アタッチはボタンにしてるけど変えられる
    public string Scene3;
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;

    public void MoveA()
    {
        SceneManager.LoadScene(Scene);
    }//一個目の移行先シーン

    public void MoveLoadNextSceneB()
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(Scene);
        AsyncOperation async1 = SceneManager.LoadSceneAsync(Scene);
        while (!async.isDone)
        {
            _slider.value = async.progress;
            yield return null;
        }
        while (!async1.isDone)
        {
            _slider.value = async.progress;
            yield return null;
        }
    }

    public void MoveB()
    {
        SceneManager.LoadScene(Scene2);
    }

    ////コライダ―に入ったらscene切替
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(Scene);
    }
    public void MoveLoadNextSceneC()
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadNextScene());
    }
    public void MoveC()
    {
        SceneManager.LoadScene(Scene);
    }
}
