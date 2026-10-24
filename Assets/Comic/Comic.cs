using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Comic : MonoBehaviour
{

    [SerializeField] public Image comic;
    public Sprite[] panels;
    private int i = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // comic = GetComponentInChildren<Image>();
        // comic = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.I.InteractInput)
        {
            showNextPanel();
            // Debug.Log("Yo");
        }
    }

    void showNextPanel()
    {
        if (i == 3){ GameManager.Instance.ChangeLevel("Dressing Room"); };
        comic.sprite = panels[i];
        i++;
    }
}
