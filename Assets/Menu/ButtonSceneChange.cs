using UnityEngine;

// dirty workaround for buttons to have access to GameManger.Instance in Editor
public class ButtonSceneChange : MonoBehaviour
{

    public void ChangeScene(string sceneName)
    {
        // GameManager.Instance.ChangeLevel(sceneName);
        GameManager.Instance.LoadScene(sceneName);
    }
}
