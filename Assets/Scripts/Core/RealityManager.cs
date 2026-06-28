using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class RealityManager : MonoBehaviour
{
    public GameObject realityA;
    public GameObject realityB;
    public Volume globalVolume;
    public AudioClip realityShiftSound;
    public AudioSource audioSource;

    private ChromaticAberration chromatic;
    private LensDistortion lens;
    private Vignette vignette;
    private bool inRealityA = true;

    void Start()
    {
        globalVolume.profile.TryGet(out chromatic);
        globalVolume.profile.TryGet(out lens);
        globalVolume.profile.TryGet(out vignette);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(RealityShiftEffect());
        }
    }

    void ShiftReality()
    {
        inRealityA = !inRealityA;

        realityA.SetActive(inRealityA);
        realityB.SetActive(!inRealityA);
    }

    IEnumerator RealityShiftEffect()
    {
        float duration = 0.2f;

        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float t = timer / duration;

            chromatic.intensity.value =
                Mathf.Lerp(0f, 1f, t);

            lens.intensity.value =
                Mathf.Lerp(0f, -0.8f, t);

            vignette.intensity.value =
                Mathf.Lerp(0.15f, 0.5f, t);

            yield return null;
        }

        audioSource.PlayOneShot(realityShiftSound);

        yield return new WaitForSecondsRealtime(0.08f);

        Time.timeScale = 0.05f;
        yield return new WaitForSecondsRealtime(0.05f);
        Time.timeScale = 1f;

        ShiftReality();

        timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float t = timer / duration;

            chromatic.intensity.value =
             Mathf.Lerp(1f, 0f, t);

            lens.intensity.value =
             Mathf.Lerp(-0.8f, 0f, t);

            vignette.intensity.value =
             Mathf.Lerp(0.5f, 0.15f, t);

            yield return null;
        }
    }
}