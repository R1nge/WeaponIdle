using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private AudioSource sound, music;
    [SerializeField] private Image soundButton, musicButton;

    private void Start()
    {
        sound.enabled = settings.sound;
        music.enabled = settings.music;
        SetColor();
    }

    public void ToggleSound()
    {
        if (sound.enabled)
        {
            sound.enabled = false;
            settings.sound = false;
        }
        else
        {
            sound.enabled = true;
            settings.sound = true;
        }

        SetColor();
        settings.Save();
    }

    public void ToggleMusic()
    {
        if (music.enabled)
        {
            music.enabled = false;
            settings.music = false;
        }
        else
        {
            music.enabled = true;
            settings.music = true;
        }

        SetColor();
        settings.Save();
    }

    private void SetColor()
    {
        soundButton.color = sound.enabled ? Color.green : Color.red;
        musicButton.color = music.enabled ? Color.green : Color.red;
    }
}