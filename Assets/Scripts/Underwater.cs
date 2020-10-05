using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    [SerializeField]
    private float m_waterHeight;
    [SerializeField]
    private GameObject m_waterGO;
    private bool m_isUnderwater;
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
        if ((transform.position.y < m_waterHeight) != m_isUnderwater)
        {
            print("is under water");
            m_isUnderwater = transform.position.y < m_waterHeight;

            if (m_isUnderwater) 
                SetUnderwater();
            if (!m_isUnderwater) 
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
