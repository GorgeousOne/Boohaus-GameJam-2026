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


    public float animDuration;
    public Vector2 animDist;

    public ParticleSystem bonbons;


    bool startedBonbons;

    int score;

    float animStart = 99999;
    float bonbonStart = 99999;
    Vector2 animStartPoint;
    float bonbonDuration;

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
        bonbonStart = animStart + animDuration + 2;
        Debug.Log(animStart + " " + bonbonStart);
        var audios = GetComponents<AudioSource>();
        // stone statue
        audios[1].Play();

        Debug.Log("" + bonbonStart + Time.time);
        int[] scoreOptions = new int[3];
        scoreOptions[0] = Random.Range(10, 30);
        scoreOptions[1] = Random.Range(80, 150);
        scoreOptions[2] = Random.Range(300, 350);
        score = scoreOptions[Random.Range(0, scoreOptions.Length)];
        Debug.Log("release the bonbons");
        ParticleSystem.MainModule psMain = bonbons.main;
        ParticleSystem.EmissionModule psEMission = bonbons.emission;
        bonbonDuration = (int) Mathf.Ceil(Mathf.Log(score));
        psMain.duration = bonbonDuration;
        psEMission.rateOverTime = 10 + bonbonDuration * 10;
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

        if (time > bonbonStart && time <= bonbonStart + bonbonDuration)
        {
            if (!startedBonbons)
            {
                StartBonbons();
            }
            float t = (time - bonbonStart) / bonbonDuration;
            //smooth out?
            t = 1 - Mathf.Pow(1-t, 3);
            int textScore = (int) Mathf.Ceil(t * score);
            counter.text = "" + textScore;
        }
    }

    void StartBonbons()
    {
        startedBonbons = true;
        bonbons.Play();
    }
}
