using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

enum DestroyMode { None, Destroy, Disable }

public class CutsceneController : MonoBehaviour
{
    PlayableDirector _director;

    [Header("Events")]
    public UnityEvent OnDirectorPlayed;
    public UnityEvent OnDirectorStopped;

    [SerializeField, Header("Variables")]
    bool _playOnStart = true;
    [SerializeField]
    DestroyMode _destroyMode = DestroyMode.None;

    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();

        _director.played += Played;
        _director.stopped += Stopped;
    }

    private void Start()
    {
        if (_playOnStart)
            StartTimeline();
    }

    private void Played(PlayableDirector director)
    {
        OnDirectorPlayed?.Invoke();
    }

    private void Stopped(PlayableDirector director)
    {
        OnDirectorStopped?.Invoke();

        switch (_destroyMode)
        {
            case DestroyMode.None:
                break;

            case DestroyMode.Destroy:
                Destroy(gameObject);
                break;

            case DestroyMode.Disable:
                gameObject.SetActive(false);
                break;
        }
    }

    public void StartTimeline()
    {
        _director.Play();
    }
}