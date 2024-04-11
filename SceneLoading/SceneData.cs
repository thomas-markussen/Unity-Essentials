using System;
using Eflatun.SceneReference;

namespace Thimas.SceneManagement
{
    [Serializable]
    public class SceneData
    {
        public SceneReference reference;
        public string name;
        public SceneType sceneType;
    }
}

