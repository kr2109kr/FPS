using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    GameObject childGameObject;

    [SerializeField] private float showAfterHitDuration;
    bool isTimerActive;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        childGameObject = transform.GetChild(0).gameObject;
    }



    public void UpdateHealthBar(float amount)
    {
        slider.value = amount;

        if (isTimerActive)
        {
            StopAllCoroutines();
            StartCoroutine(HealthbarShow(showAfterHitDuration));
        }

        else
        {
            isTimerActive = true;
            StartCoroutine(HealthbarShow(showAfterHitDuration));
        }
    }

    private IEnumerator HealthbarShow(float duration)
    {
        childGameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        childGameObject.SetActive(false);
        isTimerActive = false;
    }

}
