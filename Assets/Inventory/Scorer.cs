using UnityEngine;

public class Scorer : MonoBehaviour
{

    Transform front;
    Transform back;
    Transform character;

    public float animDuration;
    public Vector2 animDist;

    float animStart;

    void Awake()
    {
        front = transform.Find("Scoring Front");
        back = transform.Find("Scoring Back");

        character = transform.Find("Costume View");
        Debug.Log("we good? " + front + back + character);
    }

    public void StartScoring()
    {
        front.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
        animStart = Time.time;

    }
}
