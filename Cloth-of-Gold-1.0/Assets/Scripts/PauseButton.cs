using UnityEngine;
using UnityEngine.UI;
public class PauseButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Sprite playButton;
    [SerializeField] Sprite pauseButton;

    void Start()
    {
        Time.timeScale = 0.0f;
        GetComponent<Button>().onClick.AddListener(TogglePause);
    }

    public void TogglePause()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 1.0f) ? 0.0f : 1.0f;
    }
    public void OnEnable()
    {
        button.onClick.AddListener(ChangeSprite);
    }

    public void OnDisable()
    {
        button.onClick.RemoveListener(ChangeSprite);
    }

    void ChangeSprite()
    {
        button.image.sprite = button.image.sprite == playButton ? pauseButton : playButton;
    }

    

}