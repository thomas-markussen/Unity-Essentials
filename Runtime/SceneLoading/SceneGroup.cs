using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Thimas.SceneManagement
{
    [Serializable]
    public class SceneGroup
    {
        public string groupName = "New Scene Group";
        public List<SceneData> scenes;

        public string FindSceneNameByType(SceneType sceneType)
        {
            return scenes.FirstOrDefault(scene => scene.sceneType == sceneType)?.reference.Name;
        }
    }

    public enum SceneType
    {
        ActiveScene,
        MainMenu,
        UserInterface,
        HUD,
        Cinematic,
        Environment,
        Tooling
    }
}

