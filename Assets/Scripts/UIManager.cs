using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;
    [SerializeField]
    private GameObject m_mainPanel;
    [SerializeField]
    private GameObject m_templateButtonEvaristois;
    [SerializeField]
    private GameObject m_gridLayout;
    private List<Dropdown.OptionData> m_defaultTranslationDropDown = new List<Dropdown.OptionData>();
    private LayerMask m_layerMaskSkeleton;
    [SerializeField]
    private GameObject m_logoDialog;
    [SerializeField]
    private GameObject m_windowsDialog;
    [SerializeField]
    private GameObject m_cursorGO;
    [SerializeField]
    private Text m_windowsDialogText;
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
        m_mainPanel.SetActive(false);

        m_layerMaskSkeleton = LayerMask.GetMask("Skeleton");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.FirstPersonLook.enabled = m_mainPanel.activeSelf;

            if(!m_mainPanel.activeSelf)
                UnityEngine.Cursor.lockState = CursorLockMode.None;
            else
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;

            m_mainPanel.SetActive(!m_mainPanel.activeSelf);
        }

        RaycastHit rayHit;



        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 10.0f, m_layerMaskSkeleton))
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                plotDialogUI(true, rayHit.collider.GetComponent<Skeleton>());
            else
                plotLogoDialogUI(true);

        }
        else
            plotLogoDialogUI(false);

        if (Input.GetKeyDown(KeyCode.Escape))
            plotDialogUI(false, null);
        

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

    private void plotDialogUI(bool enableDisable, Skeleton skeleton)
    {
        print("plot dialog UI");
        m_windowsDialog.SetActive(enableDisable);

        if (enableDisable)
            plotLogoDialogUI(false);
            
        

        if(skeleton != null)
            m_windowsDialogText.text = skeleton.LastDialog;
        
    }

    private void plotLogoDialogUI(bool enableDisable)
    {
        m_logoDialog.SetActive(enableDisable);
        m_cursorGO.SetActive(!enableDisable);
    }

}
