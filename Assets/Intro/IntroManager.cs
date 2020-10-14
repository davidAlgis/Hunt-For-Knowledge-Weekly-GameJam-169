using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    private static IntroManager m_instance;
    [SerializeField]
    private Text m_textIntro;
    private AudioSource m_audioSource;

    public static IntroManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = GameObject.Find("IntroManager").GetComponent<IntroManager>();
            }
            return m_instance;
        }
    }

    public void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        //Handheld.PlayFullScreenMovie("Intro2.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

    public void displayText()
    {
        StartCoroutine(FadeTextToFullAlpha());
    }


    public IEnumerator FadeTextToFullAlpha(float time = 2.5f)
    {
        m_textIntro.color = new Color(m_textIntro.color.r, m_textIntro.color.g, m_textIntro.color.b, 0);
        while (m_textIntro.color.a < 1.0f)
        {
            m_textIntro.color = new Color(m_textIntro.color.r, m_textIntro.color.g, m_textIntro.color.b, m_textIntro.color.a + (Time.deltaTime / time));
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        StartCoroutine(FadeTextToZeroAlpha());
    }

    public IEnumerator FadeTextToZeroAlpha(float time = 2.5f)
    {
        m_textIntro.color = new Color(m_textIntro.color.r, m_textIntro.color.g, m_textIntro.color.b, 1);
        while (m_textIntro.color.a > 0.0f)
        {
            m_textIntro.color = new Color(m_textIntro.color.r, m_textIntro.color.g, m_textIntro.color.b, m_textIntro.color.a - (Time.deltaTime / time));
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
    }


    public void playSound()
    {
        print("play soudn");
        m_audioSource.Play();
    }
}
