using UnityEngine;
using TMPro;
public class Shifting : MonoBehaviour
{
    public float shiftCooldown = 4.5f; // Time in seconds between shifts
    private float lastShiftTime = -Mathf.Infinity; // Time of the last shift
    public TMP_Text BPMText; // Reference to the TextMeshPro text component
    private int lastBPM = 0; // Store the last BPM value to detect changes
    public int starterBPM = 120; // Starting BPM value
    private MusicPlayer player; // Reference to the MusicPlayer script
    private GameInput inputActions;
    public Song sixtybpm; // Reference to the 60 BPM song asset
    public Song eightybpm; // Reference to the 80 BPM song asset
    public Song hundredbpm; // Reference to the 100 BPM song asset
    public Song hundredtwentybpm; // Reference to the 120 BPM song asset
    public Song hundredfortybpm; // Reference to the 140 BPM song asset
    public Song hundredsixtybpm; // Reference to the 160 BPM song asset
    public Song hundredeightybpm; // Reference to the 180 BPM song asset
    void Awake()
    {
        inputActions = new GameInput();
    }
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastBPM = starterBPM;
        UpdateBPMText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBPMText();
        if (inputActions.Player.ShiftBPM.triggered && Time.time - lastShiftTime >= shiftCooldown)
        {
            ShiftBPM();
            lastShiftTime = Time.time; // Update the last shift time
            CheckBPMChange();
        }
        ChangeSong();
    }
    void UpdateBPMText()
    {
        if (BPMText != null)
        {
            BPMText.text = lastBPM.ToString();
        }
    }
    void ShiftBPM()
    {
        float axisValue = inputActions.Player.ShiftBPM.ReadValue<float>();

        if (axisValue > 0.5f) // Shift up
        {
            lastBPM += 20;
            UpdateBPMText();
            Debug.Log("BPM shifted to: " + lastBPM);
        }
        else if (axisValue < -0.5f) // Shift down
        {
            lastBPM -= 20;
            UpdateBPMText();
            Debug.Log("BPM shifted to: " + lastBPM);
        }
    }
    void CheckBPMChange()
    {
        if (lastBPM <= 60)
        {
            Debug.Log("BPM is out of range! Looping back.");
            lastBPM = 180;
            UpdateBPMText();
        }
        else if (lastBPM >= 180)
        {
            Debug.Log("BPM is out of range! Looping back.");
            lastBPM = 60;
            UpdateBPMText();
        }
    }
    void ChangeSong()
    {
        if (lastBPM == 60)
        {
            player.songAsset = sixtybpm; // Load the song for 60 BPM
            // Change to the song for 60 BPM
            Debug.Log("Changing to song for 60 BPM");
        }
        else if (lastBPM == 80)
        {
            player.songAsset = eightybpm; // Load the song for 80 BPM
            Debug.Log("Changing to song for 80 BPM");
        }
        else if (lastBPM == 100)
        {
            player.songAsset = hundredbpm; // Load the song for 100 BPM
            Debug.Log("Changing to song for 100 BPM");
        }
        else if (lastBPM == 120)
        {
            player.songAsset = hundredtwentybpm; // Load the song for 120 BPM
            Debug.Log("Changing to song for 120 BPM");
        }
        else if (lastBPM == 140)
        {
            player.songAsset = hundredfortybpm; // Load the song for 140 BPM
            Debug.Log("Changing to song for 140 BPM");
        }
        else if (lastBPM == 160)
        {
            player.songAsset = hundredsixtybpm; // Load the song for 160 BPM
            Debug.Log("Changing to song for 160 BPM");
        }
        else if (lastBPM == 180)
        {
            player.songAsset = hundredeightybpm; // Load the song for 180 BPM
            Debug.Log("Changing to song for 180 BPM");
        }
    }
}
