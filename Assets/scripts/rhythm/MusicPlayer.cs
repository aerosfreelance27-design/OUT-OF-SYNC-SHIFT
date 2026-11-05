using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public Song songAsset; // Reference to the song asset to load
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loadSong();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSongProgress();
    }
    void loadSong()
    {
        Song song = songAsset; // Use the assigned song asset
        if (song != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = song.song;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Song not found!");
        }
    }
    void UpdateSongProgress()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            songAsset.MillisecondsIntoSong(audioSource.time);
        }
    }
}
