using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispStand_Feedback : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void PlaceWisp (bool place) => _meshRenderer.enabled = place;
}
