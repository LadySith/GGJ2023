using UnityEngine;

public class BeatDetector : MonoBehaviour
{
    public AudioSource audioSource;
    public float threshold = 0.1f;
    public float updateInterval = 0.05f;
    private bool hasStartedPlaying; 
    private float[] samples;
    private float nextUpdateTime;

    private void Start()
    {
        samples = new float[audioSource.clip.samples];
        audioSource.clip.GetData(samples, 0);
        hasStartedPlaying = false;
        nextUpdateTime = Time.time + updateInterval;
        GameManager.OnStartPlayingMusic += GameManager_OnStartPlayingMusic;
    }

    private void GameManager_OnStartPlayingMusic(object sender, System.EventArgs e)
    {
        hasStartedPlaying = true;
    }

    private void Update()
    {
        if (Time.time >= nextUpdateTime && hasStartedPlaying)
        {
            int sampleIndex = (int)(audioSource.time * audioSource.clip.frequency);
            int sampleCount = (int)(updateInterval * audioSource.clip.frequency);

            for (int i = 0; i < sampleCount; i++)
            {
                int currentSample = sampleIndex + i;
                if (currentSample >= samples.Length) break;

                if (samples[currentSample] > threshold)
                {
                    // A beat has been detected!
                    Debug.Log("Beat detected at sample " + currentSample);

                    // Trigger an event or perform some other action here
                }
            }

            nextUpdateTime += updateInterval;
        }
    }
}
