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

    #endregion



    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

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
                    word.ev.disableInteractionDropdown();
                
            }
            m_nbrOfSucess = 0;
        }
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