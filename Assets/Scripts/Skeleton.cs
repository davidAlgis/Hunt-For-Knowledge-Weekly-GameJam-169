using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField]
    private string m_lastDialog;

    public string LastDialog { get => m_lastDialog; }
}
