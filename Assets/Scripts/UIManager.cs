using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;
    [SerializeField]
    private GameObject m_mainCanvas;
    [SerializeField]
    private GameObject m_templateButtonEvaristois;
    [SerializeField]
    private GameObject m_gridLayout;
    private List<Dropdown.OptionData> m_defaultTranslationDropDown = new List<Dropdown.OptionData>();

    #region getter
    public static UIManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = GameObject.Find("Manager").GetComponent<UIManager>();
            }
            return m_instance;
        }
    }
    #endregion

    public void Awake()
    {
        Dropdown.OptionData temp;
        foreach (var word in GameManager.Instance.TranslationTable)
        {
            
            temp = new Dropdown.OptionData(word.translation);
            //temp.text = word.translation;

            m_defaultTranslationDropDown.Add(temp);
        }

        shuffleDropDownTranslation();

        foreach (var word in GameManager.Instance.TranslationTable)
        {
            GameObject goTemp = (GameObject)Instantiate(m_templateButtonEvaristois, m_gridLayout.transform);
            //goTemp.transform.SetParent(m_gridLayout.transform);
            EvaristoisUI ev = goTemp.GetComponent<EvaristoisUI>();
            word.ev = ev;
            ev.setTranslation(word);
            ev.setEvaristois(word.evaristois);
            ev.setTranslationDropdown(m_defaultTranslationDropDown);
            
        }
        m_mainCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.FirstPersonLook.enabled = m_mainCanvas.activeSelf;

            if(!m_mainCanvas.activeSelf)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

            m_mainCanvas.SetActive(!m_mainCanvas.activeSelf);
        }

    }

    private void shuffleDropDownTranslation()
    {
        for (int i = 0; i < m_defaultTranslationDropDown.Count; i++)
        {
            Dropdown.OptionData temp = m_defaultTranslationDropDown[i];
            int randomIndex = Random.Range(i, m_defaultTranslationDropDown.Count);
            m_defaultTranslationDropDown[i] = m_defaultTranslationDropDown[randomIndex];
            m_defaultTranslationDropDown[randomIndex] = temp;
        }
    }

}
