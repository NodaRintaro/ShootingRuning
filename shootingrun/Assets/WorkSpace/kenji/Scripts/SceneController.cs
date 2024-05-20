using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Collider ChangeScene;
    public Button StartScene;
    public string Scene;//�ڍs��̃Q�[���V�[����inspector�ɏ����Ȃ���
    public Button GameScene;
    public string Scene2;
    public Button OnotherScene;//�A�^�b�`�̓{�^���ɂ��Ă邯�Ǖς�����
    public string Scene3;
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;

    public void MoveA()
    {
        SceneManager.LoadScene(Scene);
    }//��ڂ̈ڍs��V�[��

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

    ////�R���C�_�\�ɓ�������scene�ؑ�
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
