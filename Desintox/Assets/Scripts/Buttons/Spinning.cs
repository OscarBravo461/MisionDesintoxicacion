using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import this to use UI elements

public class Spinning : MonoBehaviour
{
    public GameObject roulette;  // Reference to the roulette GameObject
    public Button spinButton;     // Reference to the button to disable/enable
    public float spinSpeed = 500f;      // Initial spin speed
    public float deceleration = 50f;    // Deceleration rate
    public float finalSpinSpeed = 100f; // Speed when approaching the final angle
    public float snapThreshold = 0.1f;   // Threshold to consider when to snap to the target angle

    private float currentSpeed;         // Current speed of the roulette
    private bool isSpinning = false;    // To check if the roulette is spinning
    private int selectedIndex = -1;     // To store the index of the selected section
    private float targetAngle;           // Target angle for the roulette to stop at

    // Struct to hold chance and angle for each section
    [System.Serializable]
    public struct RouletteSection
    {
        public int chance; // Probability of the section
        public float angle; // Angle of the section
        public string name; // Name of the section
    }

    public RouletteSection[] sections = new RouletteSection[4]; // Array of sections

    void Start()
    {
        // Initialize sections with chances and angles
        sections[0] = new RouletteSection { chance = 25, angle = 22.5f, name = "Opción 1" };
        sections[1] = new RouletteSection { chance = 25, angle = 67.5f, name = "Opción 2" };
        sections[2] = new RouletteSection { chance = 25, angle = 112.5f, name = "Opción 3" };
        sections[3] = new RouletteSection { chance = 25, angle = 157.5f, name = "Opción 4" };
    }

    void Update()
    {
        // If the roulette is spinning
        if (isSpinning)
        {
            // Rotate the roulette using the GameObject
            roulette.transform.Rotate(0, 0, currentSpeed * Time.deltaTime);

            // Check if we need to decelerate towards the target angle
            if (selectedIndex >= 0)
            {
                // Calculate the angle difference
                float angleDifference = Mathf.DeltaAngle(roulette.transform.eulerAngles.z, targetAngle);

                // If we're close enough to the target angle, adjust speed
                if (Mathf.Abs(angleDifference) < snapThreshold)
                {
                    currentSpeed = Mathf.Max(0, currentSpeed - deceleration * Time.deltaTime);
                }
                else
                {
                    // If not close enough, continue spinning
                    currentSpeed = finalSpinSpeed; // Set a slower speed as we approach the target angle
                }

                // Stop spinning when speed reaches zero and close to the target
                if (currentSpeed <= 0 && Mathf.Abs(angleDifference) < snapThreshold)
                {
                    isSpinning = false; // Stop the spin
                    roulette.transform.rotation = Quaternion.Euler(0, 0, targetAngle); // Snap to target angle
                    DetermineOutcome();  // Call to determine the outcome
                    selectedIndex = -1; // Reset selected index

                    // Re-enable the spin button
                    spinButton.interactable = true;
                }
            }
            else
            {
                // Continue normal deceleration
                currentSpeed = Mathf.Max(0, currentSpeed - deceleration * Time.deltaTime);

                // When the speed reaches zero, stop the roulette
                if (currentSpeed == 0)
                {
                    isSpinning = false;

                    // Call to determine the outcome
                    DetermineOutcome(); // Ensure we determine the outcome at the end of spin

                    // Re-enable the spin button
                    spinButton.interactable = true;
                }
            }
        }
    }


    // Starts the spin of the roulette
    public void StartSpin()
    {
        currentSpeed = spinSpeed;
        isSpinning = true;

        // Disable the spin button while spinning
        spinButton.interactable = false;

        // Call to determine the outcome here
        DetermineOutcome(); // Ensure this is called when the spin starts
    }


    // Determines the outcome of the spin
    void DetermineOutcome()
    {
        int totalChance = 0;
        foreach (var section in sections)
        {
            totalChance += section.chance;
        }

        // Generate a random number based on total probabilities
        int randomChance = Random.Range(0, totalChance);
        int accumulatedChance = 0;

        // Determine which section the roulette falls into
        for (int i = 0; i < sections.Length; i++)
        {
            accumulatedChance += sections[i].chance;
            if (randomChance < accumulatedChance)
            {
                Debug.Log("Resultado: " + sections[i].name);
                selectedIndex = i; // Store the selected index
                targetAngle = sections[i].angle; // Set the target angle to the selected section
                ReduceChance(i);  // Reduce the probability of the selected section
                break;
            }
        }
    }

    // Reduces the probability of the selected section to 25% of its original value
    void ReduceChance(int index)
    {
        int originalChance = sections[index].chance;
        int reducedChance = Mathf.FloorToInt(originalChance * 0.25f); // Reduce to 25%
        int difference = originalChance - reducedChance;

        sections[index].chance = reducedChance; // Apply the reduced probability
        RedistributeChances(difference);       // Redistribute the remaining 75% among other sections
    }

    // Redistributes the remaining probability among the other sections
    void RedistributeChances(int difference)
    {
        int remainingSections = 0;
        foreach (var section in sections)
        {
            if (section.chance > 0) remainingSections++;
        }

        if (remainingSections > 0)
        {
            int redistribution = Mathf.FloorToInt(difference / remainingSections);
            for (int i = 0; i < sections.Length; i++)
            {
                if (sections[i].chance > 0 && redistribution > 0)
                {
                    sections[i].chance += redistribution;
                }
            }
        }
    }
}


