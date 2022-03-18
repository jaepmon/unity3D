using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgText : MonoBehaviour
{
    public float delayTime;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Disable", delayTime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
