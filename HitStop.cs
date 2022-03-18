using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    public Transform shakeCam;
    public Vector3 shakeDir;

    bool isStop;

    public void StopTime()
    {
        if (!isStop)
        {
            isStop = true;
            shakeCam.localPosition = shakeDir;
            Time.timeScale = 0;

            StartCoroutine(HitStopCoroutine());
        }
    }

    IEnumerator HitStopCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        Time.timeScale = 1;
        shakeCam.localPosition = Vector3.zero;
        isStop = false;
    }
}
