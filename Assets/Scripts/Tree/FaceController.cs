using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FaceController : MonoBehaviour
{
    public Sprite defaultFace;
    public Sprite painFace;
    public Sprite excitedFace;

    [Tooltip("How long to hold the face before returning to default face")]
    public float faceDuration = 3;

    private float faceStartTime = 0;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        FindObjectOfType<TreeGameObject>().treeHealth.onHealthChanged += (i) => makePained();
    }

    // Update is called once per frame
    void Update()
    {
        if (faceStartTime > 0)
        {
            if (Time.time >= faceStartTime + faceDuration)
            {
                sr.sprite = defaultFace;
                faceStartTime = 0;
            }
        }
    }

    public void makeExcited()
    {
        changeFace(excitedFace);
    }

    public void makePained()
    {
        changeFace(painFace);
    }

    public void changeFace(Sprite face)
    {
        sr.sprite = face;
        faceStartTime = Time.time;
    }
}
