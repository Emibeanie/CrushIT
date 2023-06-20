using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerControl : MonoBehaviour
{

    public Transform hammerTransform;
    public float rotationSpeed = 60f;

    public GameObject bug1;
    public GameObject bug2;
    public Button button;
    private bool isButtonPressed = false;
    private Quaternion originalRotation;
    private bool hasCollided = false;

    private void Start()
    {
        originalRotation = hammerTransform.localRotation;

        button.onClick.AddListener(OnClickButton);
    }

    private void Update()
    {
        if (isButtonPressed)
        {
            RotateHammer();
        }
        else if (hammerTransform.localRotation != originalRotation)
        {
            hammerTransform.localRotation = Quaternion.Lerp(hammerTransform.localRotation, originalRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void RotateHammer()
    {
        hammerTransform.localRotation *= Quaternion.Euler(rotationSpeed * Time.deltaTime, 0f, 0f);

        if (!hasCollided && hammerTransform.localEulerAngles.x >= 60f)
        {
            Collider[] colliders = Physics.OverlapBox(hammerTransform.position, hammerTransform.localScale / 2f);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject == bug1)
                {
                    bug1.SetActive(false);
                    bug2.SetActive(true);
                    hasCollided = true;
                    break;
                }
            }
        }
    }

    private void ResetHammerAndBugs()
    {
        hammerTransform.localRotation = originalRotation;
        bug1.SetActive(true);
        bug2.SetActive(false);
        hasCollided = false;
    }

    public void OnClickButton()
    {
        isButtonPressed = true;
        Invoke("ReleaseButton", 1f);
    }

    private void ReleaseButton()
    {
        isButtonPressed = false;
        ResetHammerAndBugs();
    }
}


