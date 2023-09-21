using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraDrunkness : MonoBehaviour
{
    private Volume postProcessingVolume;
    private Bloom bloom;
    private LensDistortion lensDistortion;
    private DepthOfField depthOfField;

    public BeerDrinking beerDrinking;
    private float drunkness = 0.0f;
    public float globalIntensity = 1.0f;
    public float globalChangeSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (beerDrinking == null) {
            Debug.LogError("BeerDrinking script is missing in cameraDrunkness script");
        }
        postProcessingVolume = GetComponent<Volume>();
        if (postProcessingVolume == null) {
            Debug.LogError("Volume is missing in cameraDrunkness script");
        }
        postProcessingVolume.profile.TryGet<Bloom>(out bloom);
        if (bloom == null) {
            Debug.LogError("Bloom is missing in cameraDrunkness script");
        }
        postProcessingVolume.profile.TryGet<LensDistortion>(out lensDistortion);
        if (lensDistortion == null) {
            Debug.LogError("LensDistortion is missing in cameraDrunkness script");
        }
        postProcessingVolume.profile.TryGet<DepthOfField>(out depthOfField);
        if (depthOfField == null) {
            Debug.LogError("DepthOfField is missing in cameraDrunkness script");
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        drunkness = beerDrinking.getDrunkness();
        BloomUpdate(drunkness);
        LensDistortionUpdate(drunkness);
        DepthOfFieldUpdate(drunkness);
    }

    public float bloomIntensity = 1.0f;
    public float bloomChangeSpeed = 1.0f;

    void BloomUpdate(float drunkness) 
    {
        float finalIntensity = drunkness * 10.0f * globalIntensity * bloomIntensity;
        float finalChangeSpeed = Time.deltaTime * 0.05f * globalChangeSpeed * bloomChangeSpeed;
        bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, finalIntensity, finalChangeSpeed);
    }


    public float lensDistortionIntensity = 1.0f;
    public float lensDistortionChangeSpeed = 1.0f;
    private float lastLensDistortionChange = 0.0f;
    public float lensDistortionChangeInterval = 1.0f;

    private float randomIntensity = 0.0f;
    private float randomCenterX = 0.5f;
    private float randomCenterY = 0.5f;

    void LensDistortionUpdate(float drunkness)
    {
        float finalIntensity = drunkness * globalIntensity * lensDistortionIntensity;
        float finalChangeSpeed = Time.deltaTime * 0.5f * globalChangeSpeed * lensDistortionChangeSpeed;
        lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, randomIntensity, finalChangeSpeed);
        lensDistortion.center.value = Vector2.Lerp(lensDistortion.center.value, new Vector2(randomCenterX, randomCenterY), finalChangeSpeed);

        if (lastLensDistortionChange < lensDistortionChangeInterval) {
            lastLensDistortionChange += Time.deltaTime;
            return;
        }
        lastLensDistortionChange = 0.0f;

        randomIntensity = UnityEngine.Random.Range(-drunkness, -drunkness / 2);
        randomCenterX = UnityEngine.Random.Range(-drunkness * lensDistortionIntensity, drunkness * lensDistortionIntensity) / 2 + 0.5f;
        randomCenterY = UnityEngine.Random.Range(-drunkness * lensDistortionIntensity, drunkness * lensDistortionIntensity) / 2 + 0.5f;


    }

    public float depthOfFieldIntensity = 1.0f;
    public float depthOfFieldChangeSpeed = 1.0f;
    void DepthOfFieldUpdate(float drunkness)
    {
        float finalIntensity = 1 - drunkness * globalIntensity * depthOfFieldIntensity;
        float finalChangeSpeed = Time.deltaTime * 0.5f * globalChangeSpeed * depthOfFieldChangeSpeed;
        depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, finalIntensity, finalChangeSpeed);
    }
}
