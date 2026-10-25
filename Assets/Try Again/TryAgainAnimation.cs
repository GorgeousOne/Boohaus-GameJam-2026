using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TryAgainAnimation : MonoBehaviour
{

    [SerializeField] public Image comic;
    public Sprite[] frames;
    private int i = 0;

    private float animationFrameRate = 7.0f; // in frames per second
    private float timer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1.0f / animationFrameRate)
        {
            showNextPanel();

            timer -= 1.0f / animationFrameRate;
        };
        
    }

    void showNextPanel()
    {
        if (i == 4) {
            GameManager.Instance.ChangeLevel("Dressing Room");
            return;
        }

        Debug.Log("Display Panel " + i);

        comic.sprite = frames[i];
        i++;
    }
}
