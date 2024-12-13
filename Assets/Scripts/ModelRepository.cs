using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModelConfig
{
    public string ModelName;
    public GameObject Prefab;
    public List<Motion> Animations;
}

[CreateAssetMenu(fileName = "ModelRepository", menuName = "VR/Model Repository", order = 0)]
public class ModelRepository : ScriptableObject
{
    public List<ModelConfig> Models;
}