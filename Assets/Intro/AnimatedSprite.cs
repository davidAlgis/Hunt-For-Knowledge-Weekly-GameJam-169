using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimatedSprite : MonoBehaviour
{

    public Sprite[] sprites;
    public int spritePerFrame = 6;
    public bool loop = true;
    public bool destroyOnEnd = false;
    private bool m_musicIsPlayed = false;

    private int index = 0;
    private Image image;
    private int frame = 0;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        image.color = new Color(1, 1, 1, 1);
    }

    void Update()
    {
        if (!loop && index == sprites.Length) 
            return;

        frame++;

        if (frame < spritePerFrame) 
            return;

        image.sprite = sprites[index];

        if (index == 10 && m_musicIsPlayed == false)
            IntroManager.Instance.playSound();

        frame = 0;
        index++;

        if (index >= sprites.Length)
        {
            if (loop) 
                index = 0;
            if (destroyOnEnd)
            {

                Destroy(gameObject);
                IntroManager.Instance.displayText();
            }
        }
    }
}