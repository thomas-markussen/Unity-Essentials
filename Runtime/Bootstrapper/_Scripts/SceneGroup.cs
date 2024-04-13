using System;
using System.Collections.Generic;
using System.Linq;

namespace Thimas.SceneManagement
{
    [Serializable]
    public class SceneGroup
    {
        public string groupName = "New Scene Group";
        public List<SceneData> scenes;

        public string FindSceneNameByType(SceneType sceneType)
        {
#if ENABLE_SCENEREF
            return scenes.FirstOrDefault(scene => scene.sceneType == sceneType)?.reference.Name;
#else
            return scenes.FirstOrDefault(scene => scene.sceneType == sceneType)?.reference;
#endif
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

