using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public TreeController tree;
    public float duration = 0;

    public SceneChange sceneChange;
    public SceneChange.Scene scene;

    private float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (tree)
        {
            tree.onCompleted += onCompleted;
            this.enabled = false;
        }
        if (duration > 0)
        {
            startTime = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0)
        {
            if (Time.time > startTime + duration)
            {
                onCompleted();
            }
        }
    }

    void onCompleted()
    {
        sceneChange.goToScene(scene);
    }
}
