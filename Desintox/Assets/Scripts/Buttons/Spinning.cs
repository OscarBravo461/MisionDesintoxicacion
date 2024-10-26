using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import this to use UI elements

public class Spinning : MonoBehaviour
{
    public GameObject rouletteWheel; // Reference to the roulette GameObject
    public Button spinButton;        // Reference to the button

    public float baseSpinSpeed = 50f;   // Base speed of the spin
    public float slowDownSpeed = 1f;     // How quickly it slows down
    private bool isSpinning = false;
    private float currentSpeed;

    // Section weights (start with equal chances)
    private List<float> sectionWeights = new List<float> { 0.25f, 0.25f, 0.25f, 0.25f };
    private List<float> originalWeights = new List<float>(); // Store original weights
    private List<int> pickedSections = new List<int>(); // Track picked sections

    void Start()
    {
        originalWeights = new List<float>(sectionWeights); // Store original weights
        spinButton.onClick.AddListener(StartSpin); // Attach button click event
    }

    void Update()
    {
        if (isSpinning)
        {
            rouletteWheel.transform.Rotate(0, 0, currentSpeed * Time.deltaTime); // Spin the wheel
            currentSpeed -= slowDownSpeed * Time.deltaTime; // Slow down gradually

            if (currentSpeed <= 0)
            {
                isSpinning = false;
                currentSpeed = 0;
                int selectedSection = DetermineSection();
                ReduceChance(selectedSection); // Reduce chances of selected section
                spinButton.interactable = true; // Re-enable the button
            }
        }
    }

    public void StartSpin()
    {
        if (!isSpinning)
        {
            isSpinning = true;

            // Apply some randomization to the starting spin speed
            currentSpeed = baseSpinSpeed + Random.Range(100f, 500f); // Random spin speed range

            spinButton.interactable = false; // Disable the button while spinning
        }
    }

    int DetermineSection()
    {
        // Normalize the rotation of the wheel to the range [0, 360)
        float currentRotation = rouletteWheel.transform.eulerAngles.z % 360;

        // Randomize the final landing position a bit to break patterns
        currentRotation += Random.Range(-10f, 10f);

        int selectedSection = 0;

        if (currentRotation >= 0 && currentRotation < 90) selectedSection = 0;
        else if (currentRotation >= 90 && currentRotation < 180) selectedSection = 1;
        else if (currentRotation >= 180 && currentRotation < 270) selectedSection = 2;
        else selectedSection = 3;

        Debug.Log($"Landed on Section {selectedSection + 1}");
        return selectedSection;
    }

    void ReduceChance(int sectionIndex)
    {
        // Apply the reduction to the current section regardless if it's already picked
        sectionWeights[sectionIndex] *= 0.75f;

        // Add the current section to the picked sections list if not already in it
        if (!pickedSections.Contains(sectionIndex))
        {
            pickedSections.Add(sectionIndex);
        }

        // Check if all sections have been picked
        if (pickedSections.Count == sectionWeights.Count)
        {
            ResetWeights();
        }
        else
        {
            NormalizeWeights();
        }
    }

    void ResetWeights()
    {
        // Reset all weights to original values
        sectionWeights = new List<float>(originalWeights);
        pickedSections.Clear(); // Clear the picked sections
        Debug.Log("Weights reset to original values.");
    }

    void NormalizeWeights()
    {
        float totalWeight = 0f;
        foreach (float weight in sectionWeights) totalWeight += weight;

        for (int i = 0; i < sectionWeights.Count; i++)
        {
            // Skip applying the normalization to sections that have been picked already,
            // except for the currently picked section (which should still apply the reduction).
            if (!pickedSections.Contains(i) || i == pickedSections[pickedSections.Count - 1])
            {
                sectionWeights[i] /= totalWeight;
            }
        }

        Debug.Log("Normalized Weights: " + string.Join(", ", sectionWeights));
    }
}

