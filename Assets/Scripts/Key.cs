using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private bool m_isInGeyser = false;
    [SerializeField]
    private GameObject m_colliderGeyser;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            UIManager.Instance.plotLogoKeysUI();
            GameManager.Instance.NbrOfKeys++;
            UIManager.Instance.plotLogoHandUI(false);

            if (m_isInGeyser)
                launchExplosion();
            else
                Destroy(gameObject);
        }
        else
            UIManager.Instance.plotLogoHandUI(true);
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.Instance.plotLogoHandUI(false);
    }

    private void launchExplosion()
    {
        GameManager.Instance.RbPlayer.AddForce(Vector3.up * 2000);
        GameManager.Instance.startCoroutineGeyser(m_colliderGeyser);
        Destroy(gameObject);
    }
}
