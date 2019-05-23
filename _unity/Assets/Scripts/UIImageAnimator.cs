using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIImageAnimator : MonoBehaviour 
{
    public Sprite[] sprites;
    public int spriteDuration = 6;
    public bool loop = true;
    public float loopDelay = 0;
    public bool destroyOnEnd = false;

    private int index = 0;
    private SpriteRenderer image;
    private int frame = 0;

    public bool RePlayOnEnable;
    public bool CanPlay;

    float loopTime= -1;

    void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!CanPlay) return;
        if (!loop && index == sprites.Length) return;
        frame++;
        if (frame < spriteDuration) return;

        if(loopTime > Time.time) return;
        
        image.sprite = sprites[index];
        frame = 0;
        index++;
        if (index >= sprites.Length)
        {
            if (loop) index = 0;
            if (destroyOnEnd) Destroy(gameObject);
            loopTime = Time.time + loopDelay;
        }
    }

    void OnEnable()
    {
        if (RePlayOnEnable)
        {
            Rewind();
            CanPlay = false;
            loopTime = -1;
            Restart();
        }
    }

    public void Rewind()
    {
        frame = 0;
        index = 0;
        if (sprites.Length == 0)
        {
            return;
        }
        image.sprite = sprites[index];
    }

    public void Restart()
    {
        Rewind();
        CanPlay = true;
        loopTime = -1;
    }

    public void GoToLast()
    {
        frame = 0;
        index = sprites.Length - 1;
        if (sprites.Length == 0)
        {
            return;
        }
        image.sprite = sprites[index];
    }
}
