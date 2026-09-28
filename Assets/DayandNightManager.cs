using UnityEngine;
using TMPro;

public class DayNightManager : MonoBehaviour
{
    public GameObject whitePlatforms;
    public GameObject blackPlatforms;

    public TMP_Text dayNightText;
    //timer last for 5 sec before change
    public float switchTime = 5f;
    //track the cycle
    private float timer;
    private bool isDay = true;

    void Start()
    {
        ChangePlatforms();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            isDay = !isDay;

            timer = 0;

            ChangePlatforms();
        }
    }

    void ChangePlatforms()
    {
        if (isDay)
        {
            whitePlatforms.SetActive(true);
            blackPlatforms.SetActive(false);

            dayNightText.text = "DAY";
        }
        else
        {
            whitePlatforms.SetActive(false);
            blackPlatforms.SetActive(true);

            dayNightText.text = "NIGHT";
        }
    }
}
