using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
#if ENABLE_SCENEREF
    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    //static async void Init()
    //{
    //    Debug.Log("Bootstrapping...");
    //    await SceneManager.LoadSceneAsync("Bootstrapper", LoadSceneMode.Single);
    //}
#endif
}
