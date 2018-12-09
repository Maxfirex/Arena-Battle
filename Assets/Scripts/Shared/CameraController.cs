using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float sensitivity = 5f;
    public float smoothing = 2f;

	// Use this for initialization
	void Start () {
		if (player == null)
        {
            Debug.Log("<color=red><b>Warning:</b></color> Player not defined. Using default player.");
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        if (FeatureControl.FeatureEnabled(FeatureControl.Feature.CameraSwitch))
        {
            CameraControl.Switch();
        }
        if (FeatureControl.FeatureEnabled(FeatureControl.Feature.PlayerLook))
        {
            CameraControl.Look(player, sensitivity, smoothing);
        }    
    }
}
