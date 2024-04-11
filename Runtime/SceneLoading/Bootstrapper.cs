using UnityEngine;
using UnityEngine.SceneManagement;

namespace Thimas.SceneManagement
{
    public class Bootstrapper : PersistentSingleton<Bootstrapper>
    {
        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        //static async void Init()
        //{
        //    Debug.Log("Bootstrapping...");
        //    await SceneManager.LoadSceneAsync("Bootstrapper", LoadSceneMode.Single);
        //}
    }
}