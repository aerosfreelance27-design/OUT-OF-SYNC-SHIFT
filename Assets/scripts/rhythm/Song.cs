using UnityEngine;

[CreateAssetMenu(fileName = "Song", menuName = "Game/Song")]
public class Song : ScriptableObject
{
    public AudioClip song;
    public int bpm;
    public float GetSecondsPerBeat()
    {
        return 60f / bpm;
    }
    public float GetBeatsPerSecond()
    {
        return bpm / 60f;
    }

    public float GetSongDuration()
    {
        return song.length;
    }
    public float TotalMsInSong()
    {
        return song.length * 1000f;
    }
    public float MillisecondsIntoSong(float time)
    {
        return time * 1000f;
    } 

}
