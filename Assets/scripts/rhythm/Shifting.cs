using UnityEngine;
using TMPro;
public class Shifting : MonoBehaviour
{
    public float shiftCooldown = 4.5f; // Time in seconds between shifts
    private float lastShiftTime = -Mathf.Infinity; // Time of the last shift
    public TMP_Text BPMText; // Reference to the TextMeshPro text component
    private int lastBPM = 0; // Store the last BPM value to detect changes
    public int starterBPM = 120; // Starting BPM value

    private GameInput inputActions;
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
}
