using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(GameManager.Instance.NbrOfKeys >= 3)
            {

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 2.3f, transform.position.y + 0.8f, transform.position.z), 10.0f);
                UIManager.Instance.plotLogoHandUI(false);
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
                UIManager.Instance.plotLogoHandUI(false);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 2.3f, transform.position.y + 0.8f, transform.position.z), 10.0f);
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
