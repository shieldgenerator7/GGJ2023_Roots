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

    private float currentTime = 0f;

    private bool done = false;

    private Queue<GameObject> spawnQueue = new Queue<GameObject>();


    void Start()
    {
        lastSpawn = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnQueue.Count > 0)
        {
            if (transform.localScale.x < 1)
            {
                currentTime += Time.deltaTime;
                var x = Mathf.Lerp(0, 1, currentTime / 2f);
                Debug.Log(x);
                transform.localScale = new Vector3(x, 1, 1);
            }
            else
            {
                if (Time.time > lastSpawn + timeBetweenSpawns)
                {
                    if (spawnQueue.Peek())
                    {
                        Instantiate(spawnQueue.Dequeue(), transform.position, Quaternion.identity);
                        lastSpawn = Time.time;
                    }

                    if (spawnQueue.Count == 0)
                    {
                        done = true;
                        currentTime = 0f;
                    }
                }
            }
        }

        if (done)
        {
            if (transform.localScale.x <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                currentTime += Time.deltaTime;
                var x = Mathf.Lerp(1, 0, currentTime / 1f);
                Debug.Log(x);
                transform.localScale = new Vector3(x, 1, 1);
            }
        }

    }

    public void QueueWave(Wave wave)
    {
        waveAnnouce.SetText(wave.WaveAnnouncement);
        wave.Mobs.ForEach(x =>
        {
            for (int i = 0; i < x.Count; i++)
            {
                spawnQueue.Enqueue(x.Mob);
            }
        });
    }

    private void OnEnable()
    {
        currentTime = 0f;
    }

}
