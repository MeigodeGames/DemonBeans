using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [Header("Transition Modes")]
    [SerializeField] private bool _changeSceneByInput;
    [SerializeField] private bool _changeSceneByTime;

    [Header("Transition Parameters")]
    [SerializeField] private float _timeToChange = 3.0f;
    [SerializeField] private string _sceneName;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private bool _useTimedLoading = false;

    private bool _isLoading = false;

    private void Start()
    {
        if (_changeSceneByTime)
            Invoke(nameof(LoadLevel), _timeToChange);
    }

    private void Update()
    {
        if (!_changeSceneByInput)
            return;

        if (Input.anyKeyDown)
            LoadLevel();
    }

    private void LoadLevel()
    {
        if (_isLoading)
            return;

        if (_audioClip)
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);

        _isLoading = true;

        if (_useTimedLoading)
            ScreenManager.Instance.LoadLevelLoading(_sceneName);
        else
            ScreenManager.Instance.LoadLevel(_sceneName);
    }
}
