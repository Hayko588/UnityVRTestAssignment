using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModelConfig
{
    public string ModelName;
    public ModelExhibit Prefab;
    public Sprite PreviewImage;
    public List<AnimationClip> Animations;
}

[CreateAssetMenu(fileName = "ModelRepository", menuName = "VR/Model Repository", order = 0)]
public class ModelRepository : ScriptableObject
{
    public List<ModelConfig> Models;
}