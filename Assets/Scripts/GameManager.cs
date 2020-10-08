using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    [SerializeField]
    private List<EvaristoisTranslation> m_translationTable = new List<EvaristoisTranslation>();
    [SerializeField]
    private FirstPersonLook m_firstPersonLook;
    [SerializeField]
    private int m_nbrOfSucess = 0;
    private bool m_isUnderwater = false;
    [SerializeField]
    private Rigidbody m_rbPlayer;
    [SerializeField]
    private GameObject m_geyserGO;
    private uint m_nbrOfKeys = 0;
    [SerializeField]
    private AudioSource m_soundCheck;

    #region getter
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = GameObject.Find("Manager").GetComponent<GameManager>();
            }
            return m_instance;
        }
    }

    public List<EvaristoisTranslation> TranslationTable { get => m_translationTable; set => m_translationTable = value; }
    public FirstPersonLook FirstPersonLook { get => m_firstPersonLook; set => m_firstPersonLook = value; }
    public uint NbrOfKeys { get => m_nbrOfKeys; set => m_nbrOfKeys = value; }
    public bool IsUnderwater { get => m_isUnderwater; set => m_isUnderwater = value; }
    public Rigidbody RbPlayer { get => m_rbPlayer; set => m_rbPlayer = value; }

    #endregion


    public void Start()
    {
        StartCoroutine(handleExplosionGeyser());
        ParticleSystem particleGeyser = m_geyserGO.GetComponent<ParticleSystem>();
        particleGeyser.Stop();
    }

    public void valueChangeInDropDown(EvaristoisUI ev)
    {
        if (ev.Translation.translation == ev.getTranslationDropdown())
        {
            ev.Translation.sucess = true;
            m_nbrOfSucess++;

        }
        else
        {
            if (ev.Sucess)
            {
                m_nbrOfSucess--;
                ev.Translation.sucess = false;
            }
        }

        if(m_nbrOfSucess == 3)
        {
            foreach(var word in m_translationTable)
            {
                if(word.sucess)
                {
                    word.ev.setEvaristoisGreen();
                    word.ev.disableInteractionDropdown();
                    m_soundCheck.Play();

                }
                
            }
            m_nbrOfSucess = 0;
        }
    }

    public void startCoroutineGeyser(GameObject geyser)
    {
        StartCoroutine(blockGeyser(geyser));
    }

    IEnumerator blockGeyser(GameObject geyser)
    {
        while (m_rbPlayer.transform.position.y <= geyser.transform.position.y)
            yield return new WaitForSeconds(0.1f);

        geyser.SetActive(true);
    }

    IEnumerator handleExplosionGeyser()
    {
        for (; ;)
        {
            if (Vector3.Distance(RbPlayer.transform.position, m_geyserGO.transform.position) > 50)
                StartCoroutine(launchExplosionGeyser());
            
            yield return new WaitForSeconds(60.0f);

        }
    }

    public void startCoroutineLaunchGeyserExplosion()
    {
        StartCoroutine(launchExplosionGeyser());
    }

    private IEnumerator launchExplosionGeyser()
    {
        ParticleSystem particleGeyser = m_geyserGO.GetComponent<ParticleSystem>();
        particleGeyser.Play();
        AudioSource audioSource = m_geyserGO.GetComponent<AudioSource>();
        audioSource.Play();
        yield return new WaitForSeconds(5.0f);
        audioSource.Stop();
        particleGeyser.Stop();
    }
}

[System.Serializable]
public class EvaristoisTranslation
{
    public string evaristois;
    public string translation;
    [HideInInspector]
    public bool sucess;
    [HideInInspector]
    public EvaristoisUI ev;
}