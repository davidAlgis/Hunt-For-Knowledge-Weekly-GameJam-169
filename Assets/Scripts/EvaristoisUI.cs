using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaristoisUI : MonoBehaviour
{
    private EvaristoisTranslation m_evaristoisTranslation = null;
    private string m_textEvaristois;
    private Dropdown m_dropdown;
    private Text m_text;
    private bool m_sucess = false;

    public EvaristoisTranslation Translation { get => m_evaristoisTranslation; }
    public bool Sucess { get => m_sucess; set => m_sucess = value; }

    public void Awake()
    {
        GameObject tempGO;
        DebugTool.tryFindGOChildren(gameObject, "Evaristois/EvaristoisText", out tempGO);
        m_text = tempGO.GetComponent<Text>();
        DebugTool.tryFindGOChildren(gameObject, "TranslationDropdown", out tempGO);
        m_dropdown = tempGO.GetComponent<Dropdown>();
        m_dropdown.onValueChanged.AddListener(delegate {
            GameManager.Instance.valueChangeInDropDown(this);
        });
    }


    public string getEvaristois()
    {
        return m_text.text;
    }

    public void setEvaristois(string text)
    {
        m_text.text = text;
    }

    public void setTranslationDropdown(List<Dropdown.OptionData> list)
    {
        m_dropdown.options = list;
    }

    public string getTranslationDropdown()
    {
        return m_dropdown.options[m_dropdown.value].text;
    }

    public void disableInteractionDropdown()
    {
        m_dropdown.interactable = false;
    }

    public void setTranslation(EvaristoisTranslation tr)
    {
        //Should be set only once.
        if (m_evaristoisTranslation == null)
            m_evaristoisTranslation = tr;
        else
            return;
    }
    
    public EvaristoisTranslation getTranslation()
    {
        return m_evaristoisTranslation;
    }

}
