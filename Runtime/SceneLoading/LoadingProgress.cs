using System;

namespace Thimas.SceneManagement
{
    public class LoadingProgress : IProgress<float>
    {
        public event Action<float> OnProgressed;
        const float ratio = 1f;

        public void Report(float value)
        {
            OnProgressed?.Invoke(value / ratio);
        }
    }

}
