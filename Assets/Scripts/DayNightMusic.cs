using UnityEngine;

public class DayNightMusic : MonoBehaviour
{
    public DayNightCycle dayNightCycle;
    public AudioSource dayMusic;
    public AudioSource nightMusic;

    private float fadeSpeed = 1f;

    private float dayMaxVolumne = 0.006f;
    private float nightMaxVolumne = 0.006f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (dayMusic != null)
        {
            dayMusic.loop = true;
            dayMusic.volume = 0f;
            dayMusic.Play();
        }

        if (nightMusic != null)
        {
            nightMusic.loop = true;
            nightMusic.volume = 0f;
            nightMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dayNightCycle == null || dayMusic == null || nightMusic == null)
        {
            return;
        }

        float targetDayVolume = dayNightCycle.IsNight ? 0f : dayMaxVolumne;
        float targetNightVolume = dayNightCycle.IsNight ? nightMaxVolumne : 0f;

        dayMusic.volume = Mathf.MoveTowards(dayMusic.volume, targetDayVolume, fadeSpeed * Time.deltaTime);
        nightMusic.volume = Mathf.MoveTowards(nightMusic.volume, targetNightVolume, fadeSpeed * Time.deltaTime);
    }
}
