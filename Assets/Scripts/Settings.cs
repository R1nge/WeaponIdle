using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings", order = 1)]
public class Settings : ScriptableObject
{
    public bool sound;
    public bool music;
    public bool notifications;
}
