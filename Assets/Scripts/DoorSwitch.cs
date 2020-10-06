using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject m_doorGO;

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.Instance.NbrOfKeys >= 2)
            {

                m_doorGO.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x +3.0f, transform.position.y, transform.position.z), 10.0f);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z -0.02f), 10.0f);
                UIManager.Instance.plotLogoHandUI(false);
                Destroy(this);
            }

        }
        else
            UIManager.Instance.plotLogoHandUI(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.Instance.NbrOfKeys >= 2)
            {

                m_doorGO.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 3.0f, transform.position.y, transform.position.z), 10.0f);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z - 0.02f), 10.0f);
                UIManager.Instance.plotLogoHandUI(false);
                Destroy(this);
            }
        }
        else
            UIManager.Instance.plotLogoHandUI(true);
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.Instance.plotLogoHandUI(false);
    }
}
