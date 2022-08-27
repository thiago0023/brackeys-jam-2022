using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispStand_Feedback : MonoBehaviour
{
    [SerializeField] private GameObject wisp;

    public void PlaceWisp (bool place) => wisp.SetActive(place);
}
