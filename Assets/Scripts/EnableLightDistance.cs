using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLightDistance : MonoBehaviour
{
    private Light m_light;
    [SerializeField]
    private Transform m_transformPlayer;
    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>();
        m_light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(gameObject.transform.position, m_transformPlayer.position) < 50)
            m_light.enabled = true;
    }
}
