using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour {
    public Transform target;
   
    // Update is called once per frame
    void Update () {
        Vector3 wantedPosition = Camera.main.WorldToViewportPoint(target.localPosition);
        Debug.Log(wantedPosition);
        wantedPosition.y += 10;
        transform.localPosition = wantedPosition;
        Debug.Log("transformposition" + transform.position);
    }
}
