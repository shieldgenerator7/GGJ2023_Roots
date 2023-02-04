using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject m_Mob;

    [SerializeField]
    private AnnounceWave waveAnnouce;

    private float lastSpawn = 0f;
    public float timeBetweenSpawns = 1f;

    private Queue<GameObject> spawnQueue = new Queue<GameObject>();

    public static MobSpawner instance;
    // Start is called before the first frame update


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        lastSpawn = Time.time;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnQueue.Count > 0)
        {
            if (Time.time > lastSpawn + timeBetweenSpawns)
            {
                Instantiate(spawnQueue.Dequeue(), transform.position, Quaternion.identity);
                lastSpawn = Time.time;
            }
        }
    }

    public void QueueWave(Wave wave)
    {
        waveAnnouce.SetText(wave.WaveAnnouncement);
        wave.Mobs.ForEach(x =>
        {
            for (int i = 0; i <= x.Count; i++)
            {
                spawnQueue.Enqueue(x.Mob);
            }
        });

        
    }

}
