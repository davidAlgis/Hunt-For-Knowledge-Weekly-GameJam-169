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

    private uint m_nbrOfKeys = 0;

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
                    word.ev.disableInteractionDropdown();
                
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
}

[System.Serializable]
public class EvaristoisTranslation
{
    public string evaristois;
    public string translation;
    public bool sucess;
    public EvaristoisUI ev;
}