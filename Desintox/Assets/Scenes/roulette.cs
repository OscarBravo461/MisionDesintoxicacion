using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roulette : MonoBehaviour
{

    [System.Serializable]
    public class RouletteSlice
    {
        public string name;
        public float weight;
        public RectTransform sliceTransform;
    }

    public List<RouletteSlice> slices;
    public float spinDuration = 3f;
    private bool isSpinning = false;

    void Start()
    {
        foreach (var slice in slices)
            slice.weight = 0.25f;

        UpdateSliceAngles();
    }


    public void Spin()
    {
        if (!isSpinning)
            StartCoroutine(SpinCoroutine());
    }

    IEnumerator SpinCoroutine()
    {
        isSpinning = true;

        // Weighted random selection
        float total = GetTotalWeight();
        float rand = Random.Range(0, total);
        float sum = 0f;
        int selected = 0;

        for (int i = 0; i < slices.Count; i++)
        {
            sum += slices[i].weight;
            if (rand <= sum)
            {
                selected = i;
                break;
            }
        }

        float targetAngle = GetSliceMidAngle(selected);

        // Log selected slice
        Debug.Log($" Selected Slice: {slices[selected].name} (Index: {selected}, Weight: {slices[selected].weight})");

        // Spin animation
        float startAngle = transform.eulerAngles.z;
        float endAngle = 360f * Random.Range(3, 6) + targetAngle;

        float elapsed = 0f;
        while (elapsed < spinDuration)
        {
            float angle = Mathf.Lerp(startAngle, endAngle, elapsed / spinDuration);
            transform.eulerAngles = new Vector3(0, 0, angle);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = new Vector3(0, 0, endAngle);

        Debug.Log(" Final Angle: " + transform.eulerAngles.z);

        // Adjust weights
        AdjustWeights(selected);
        UpdateSliceAngles();

        isSpinning = false;
    }

    void AdjustWeights(int selectedIndex)
    {
        float reductionFactor = 0.75f;
        float lostWeight = slices[selectedIndex].weight * (1f - reductionFactor);
        slices[selectedIndex].weight *= reductionFactor;

        float redistribute = lostWeight / (slices.Count - 1);
        for (int i = 0; i < slices.Count; i++)
        {
            if (i != selectedIndex)
                slices[i].weight += redistribute;
        }

        NormalizeWeights();
    }

    void NormalizeWeights()
    {
        float total = GetTotalWeight();
        foreach (var s in slices)
            s.weight /= total;
    }

    float GetTotalWeight()
    {
        float sum = 0f;
        foreach (var s in slices)
            sum += s.weight;
        return sum;
    }

    float GetSliceMidAngle(int index)
    {
        float angle = 0f;
        for (int i = 0; i < index; i++)
        {
            angle += slices[i].weight * 360f;
        }
        float mid = angle + (slices[index].weight * 360f) / 2f;
        return 360f - mid; // UNITY DOES TIS COUNTERCLOCK
    }

    void UpdateSliceAngles()
    {
        float currentAngle = 0f;

        for (int i = 0; i < slices.Count; i++)
        {
            float angleSize = slices[i].weight * 360f;

            // Rotate the slice to its starting angle(BREAKS THE DISPLAY )
            //slices[i].sliceTransform.localEulerAngles = new Vector3(0, 0, -currentAngle);

            // TRANSFORMS THE IMAGES, WONKY AF BUT IT JUST WORKS
            slices[i].sliceTransform.localScale = new Vector3(slices[i].weight * 4f, 1f, 1f); // scale so 0.25 weight = 1

            Debug.Log($" Slice '{slices[i].name}': {angleSize:F1}°, StartAngle: {currentAngle:F1}°");

            currentAngle += angleSize;
        }
    }
}


