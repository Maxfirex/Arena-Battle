using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool PlayerLook = true;
    public bool CameraSwitch = true;
    public bool EnemySpawn = true;

	void LateUpdate () {
        FeatureControl.HandleFeatures(FeatureControl.Feature.PlayerLook, PlayerLook);
        FeatureControl.HandleFeatures(FeatureControl.Feature.CameraSwitch, CameraSwitch);
        FeatureControl.HandleFeatures(FeatureControl.Feature.EnemySpawn, EnemySpawn);
	}
}
