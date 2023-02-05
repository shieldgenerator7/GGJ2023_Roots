using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public TreeController tree;
    public TreeGameObject treeHealth;
    public float duration = 0;
    public KeyCode keyCode = KeyCode.None;

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
        if (treeHealth)
        {
            treeHealth.treeHealth.onHealthChanged += listenForDeath;
            this.enabled = false;
        }
        if (duration > 0)
        {
            startTime = Time.time;
            this.enabled = true;
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
        if (keyCode != KeyCode.None)
        {
            if (Input.GetKeyDown(keyCode))
            {
                onCompleted();
            }
        }
    }

    void listenForDeath(int health)
    {
        if (health <= 0)
        {
            onCompleted();
        }
    }

    void onCompleted()
    {
        sceneChange.goToScene(scene);
    }
}
