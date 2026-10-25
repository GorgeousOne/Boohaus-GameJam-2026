using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{

    public GameObject front;
    public GameObject back;
    public GameObject uifront;
    public GameObject uiback;
    public RectTransform character;
    public TextMeshProUGUI counter;

    public AudioClip stoneStatue;


    public float animDuration;
    public Vector2 animDist;



    float animStart = -999;
    Vector2 animStartPoint;

    void Awake()
    {

        character = GameObject.Find("Costume View").GetComponent<RectTransform>();
        Debug.Log("we good? " + front + back + character);
    }

    public void StartScoring()
    {
        Debug.Log("lets go!");
        front.SetActive(true);
        back.SetActive(true);
        uifront.SetActive(false);
        uiback.SetActive(false);
        animStart = Time.time;
        animStartPoint = character.anchoredPosition;


        counter.text = "42";

        var audios = GetComponents<AudioSource>();
        audios[1].PlayOneShot(stoneStatue);
    }

    void Update()
    {
        float time = Time.time;
        if (time > animStart && time < animStart + animDuration)
        {
            float t = (time - animStart) / animDuration;
            Vector2 delta = Vector2.Lerp(Vector2.zero, animDist, t);
            character.anchoredPosition = animStartPoint + delta;
        }
    }


}
