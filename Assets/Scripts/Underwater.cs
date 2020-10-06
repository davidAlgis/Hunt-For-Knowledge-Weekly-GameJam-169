using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    [SerializeField]
    private float m_waterHeight;
    [SerializeField]
    private GameObject m_waterGO;
    private Color m_normalColor;
    private Color m_underwaterColor;

    // Use this for initialization
    void Start()
    {
        m_normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        m_underwaterColor = new Color(0.05f, 0.42f, 0.57f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < m_waterHeight) != GameManager.Instance.IsUnderwater)
        { 
            GameManager.Instance.IsUnderwater = transform.position.y < m_waterHeight;

            if (GameManager.Instance.IsUnderwater) 
                SetUnderwater();
            if (!GameManager.Instance.IsUnderwater) 
                SetNormal();
        }
    }

    void SetNormal()
    {
        m_waterGO.SetActive(false);
        RenderSettings.fog = false;
        RenderSettings.fogColor = m_normalColor;
        RenderSettings.fogDensity = 0.01f;

    }

    void SetUnderwater()
    {
        m_waterGO.SetActive(true);
        RenderSettings.fog = true;
        RenderSettings.fogColor = m_underwaterColor;
        RenderSettings.fogDensity = 0.07f;

    }
}
