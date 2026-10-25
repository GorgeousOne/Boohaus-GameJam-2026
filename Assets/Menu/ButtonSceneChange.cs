using UnityEngine;
using Yarn.Unity;

// dirty workaround for buttons to have access to GameManger.Instance in Editor
public class ButtonSceneChange : MonoBehaviour
{

    public void ChangeSceneWithUnload(string sceneName)
    {
        DialogueRunner runner = GameObject.FindWithTag("Yarn").GetComponent<DialogueRunner>();
        runner.Stop();
        runner.StopAllCoroutines();
        // GameManager.Instance.ChangeLevel(sceneName);
        GameManager.Instance.ChangeLevel(sceneName);
    }
}
