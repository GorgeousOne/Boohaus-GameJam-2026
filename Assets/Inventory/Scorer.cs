using TMPro;
using UnityEngine;

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

    public ParticleSystem bonbons;


    int score;

    float animStart = -999;
    Vector2 animStartPoint;

    void Awake()
    {
        character = GameObject.Find("Costume View").GetComponent<RectTransform>();
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


        var audios = GetComponents<AudioSource>();
        audios[1].PlayOneShot(stoneStatue);

        int[] scoreOptions = new int[3];
        scoreOptions[0] = Random.Range(10, 30);
        scoreOptions[1] = Random.Range(80, 150);
        scoreOptions[2] = Random.Range(300, 350);
        score = scoreOptions[Random.Range(0, scoreOptions.Length)];
        counter.text = "" + score;

        Debug.Log("shoot");
        ParticleSystem.MainModule psMain = bonbons.main;
        ParticleSystem.EmissionModule psEMission = bonbons.emission;
        int scale = (int) Mathf.Ceil(Mathf.Log(score));
        psMain.duration = scale;
        psEMission.rateOverTime = 10 + scale * 10;
        bonbons.Play();
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
