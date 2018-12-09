using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FeatureControl {

    private static Dictionary<string, bool> featuresDictionary = new Dictionary<string, bool>();

    public enum Feature {
        PlayerLook,
        CameraSwitch,
        EnemySpawn
    }
    // Fill default dictionaries
    private static void FillDictionaryWithFeatures(Feature features)
    {
        var enumSize = System.Enum.GetNames(typeof(Feature));

        foreach (string feature in enumSize)
        {
            featuresDictionary.Add(feature, true);
        }
    }
    // Set up feature state
    public static void HandleFeatures(Feature feature, bool enabled)
    {
        featuresDictionary[feature.ToString()] = enabled;
    }
    // Get feature state
    public static bool FeatureEnabled(Feature feature)
    {
        return featuresDictionary[feature.ToString()];
    }
}