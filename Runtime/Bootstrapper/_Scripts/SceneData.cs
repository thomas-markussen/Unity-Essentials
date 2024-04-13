using System;
#if ENABLE_SCENEREF
using Eflatun.SceneReference;
#endif
namespace Thimas.SceneManagement
{
    [Serializable]
    public class SceneData
    {
#if ENABLE_SCENEREF
        public SceneReference reference;
#else
public public string reference;
#endif
        public string name;
        public SceneType sceneType;
    }
}

