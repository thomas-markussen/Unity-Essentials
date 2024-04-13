using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Thimas.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        float _fillSpeed = 0.5f;
        [SerializeField]
        Image _loadingBar;
        [SerializeField]
        Canvas _loadingCanvas;
        [SerializeField]
        Camera _loadingCamera;
        [SerializeField, Space(5)]
        SceneGroup[] _sceneGroups;
        [SerializeField]
        bool _debugSceneLog;

        float _targetProgress;
        bool _isLoading;

        // Editor
        [SerializeField]
        bool _showButtons;

        public readonly SceneGroupManager _manager = new();

        async void Start()
        {
            await LoadSceneGroup(0);
        }

        private void Awake()
        {
            if (!_debugSceneLog) return;

            _manager.OnSceneLoaded += sceneName => Debug.Log("Loaded: " + sceneName + " at " + Time.fixedTime);
            _manager.OnSceneUnloaded += sceneName => Debug.Log("Unloaded: " + sceneName + " at " + Time.fixedTime);
        }

        private void Update()
        {
            if (!_isLoading) return;

            float currentFillAmount = _loadingBar.fillAmount;
            float progressDif = Mathf.Abs(currentFillAmount - _targetProgress);

            float dynamicFillSpeed = progressDif * _fillSpeed;

            _loadingBar.fillAmount = Mathf.Lerp(currentFillAmount, _targetProgress, Time.deltaTime * dynamicFillSpeed);
        }

        public async Task LoadSceneGroup(int index)
        {
            _loadingBar.fillAmount = 0f;
            _targetProgress = 1f;

            if (index < 0 || index >= _sceneGroups.Length)
            {
                Debug.LogError("Invalid scene group index:" + index);
                return;
            }

            LoadingProgress progress = new();
            progress.OnProgressed += target => _targetProgress = Mathf.Max(target, _targetProgress);

            EnableLoadingCanvas();
            await _manager.LoadScenes(_sceneGroups[index], progress);
            EnableLoadingCanvas(false);
        }

        void EnableLoadingCanvas(bool enable = true)
        {
            _isLoading = enable;
            _loadingCanvas.gameObject.SetActive(enable);
            _loadingCamera.gameObject.SetActive(enable);
        }

        public async void LoadSceneGroup1() => await LoadSceneGroup(0);
        public async void LoadSceneGroup2() => await LoadSceneGroup(1);
    }
}
