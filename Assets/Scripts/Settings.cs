using UnityEngine;

public class Settings : MonoBehaviour
{
    public bool sound;
    public bool music;
    public bool notifications;

    private void Awake() => Load();

    private void Load()
    {
        sound = PlayerPrefs.GetInt("Sound") == 1;
        music = PlayerPrefs.GetInt("Music") == 1;
        notifications = PlayerPrefs.GetInt("Notifications") == 1;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Sound", sound ? 1 : 0);
        PlayerPrefs.SetInt("Music", music ? 1 : 0);
        PlayerPrefs.SetInt("Notifications", notifications ? 1 : 0);
        PlayerPrefs.Save();
    }
}