using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSettings : MonoBehaviour
{
    public GameObject tPlayer;
    private CinemachineFreeLook vcam;

    private void Awake() {
        vcam = GetComponent<CinemachineFreeLook>();
    }
    // Start is called before the first frame update
    private void OnEnable() {
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
            if(tPlayer == null) return;
        }
        var tFollowTarget = tPlayer.transform;
        vcam.LookAt = tFollowTarget;
        vcam.Follow = tFollowTarget;
    }
}
