using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteTiming : MonoBehaviour
{
    public static NoteTiming instance;
    public List<NoteTime> times = new List<NoteTime>();
    public List<NoteTime> manualTimes = new List<NoteTime>();
    public float spawnPredictTime = 2, currentTime;
    bool started = false;
    
    [Header("Spawning info")]

    public List<Transform> arrowSpawns, playerTwoSpawns;
    public List<GameObject> arrows;
    public GameObject playerTwoBoard;
    public Transform spawnedParent;
    private void Awake()
    {
        instance = this;
        started = false;
        GameManager.OnStartPlayingMusic += GameManager_OnStartPlayingMusic;
        GameManager.OnEndMusic += GameManager_OnEndMusic;
    }

    private void GameManager_OnEndMusic(object sender, System.EventArgs e)
    {
        started = false;
    }

    private void GameManager_OnStartPlayingMusic(object sender, System.EventArgs e)
    {
        started = true;
        currentTime = 0;
        times.ForEach(x => x.hasSpawned = false);


    }
    public void Start()
    {

        EnablePlayerTwo();
    }
    public void EnablePlayerTwo()
    {
        playerTwoBoard.SetActive(ChangeScene.twoPlayerMode);

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NoteTime ti = new NoteTime();
            ti.secondItPlays = currentTime;
            ti.hasSpawned = false;
            manualTimes.Add(ti);
        }
        if (started)
        {
            currentTime += Time.deltaTime;
        }
        if (currentTime > 0)
        {
            times.ForEach((x) =>
            {
                if (currentTime + spawnPredictTime >= x.secondItPlays && x.hasSpawned == false)
                {
                    Spawn();
                    x.hasSpawned = true;
                }
            });
        }
    }

    public void Spawn()
    {
        int rand1 = Random.Range(0, 4);
        int rand2 = Random.Range(0, 4);
        Transform t = Instantiate(arrows[rand1], arrowSpawns[rand1].position, arrows[rand1].transform.rotation).transform;
        t.GetComponent<NoteObject>().isPlayerOne = true;
        t.parent = spawnedParent;

        if (playerTwoSpawns.Count > 0 && GameManager.instance.hasPlayerTwo == true)
        {
            t = Instantiate(arrows[rand2], playerTwoSpawns[rand2].position, arrows[rand2].transform.rotation).transform;
            t.GetComponent<NoteObject>().isPlayerOne = false;
            t.parent = spawnedParent;
        }
    }
}

[System.Serializable]
public class NoteTime
{
    public float secondItPlays;
    public bool hasSpawned = true;
}