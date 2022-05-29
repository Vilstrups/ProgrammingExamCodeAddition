using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Speedometer : MonoBehaviour
{
    private const float MAX_SPEED_ANGLE = -220;
    private const float ZERO_SPEED_ANGLE = 0;

    private Transform needleTransform;
    public Transform speedLabelTemplateTransform;


    private float speedMax;
    private float speed; 

    private void Awake() {
        needleTransform = transform.Find("needle");
        // speedLabelTemplateTransform = transform.Find("speedLabelTemplate");

        
        speed = 0f;
        speedMax = 200f;

        CreateSpeedLabels();

        speedLabelTemplateTransform.gameObject.SetActive(false);

    }


    
        private void Update() {

        speed += 30f * Time.deltaTime; 
        if (speed > speedMax) speed = speedMax;

        needleTransform.eulerAngles = new Vector3(0,0, GetSpeedRotation());

    }

    private void CreateSpeedLabels() {
        int labelAmount = 10;
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        for (int i = 0; i <= labelAmount; i++) {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalized = (float)i / labelAmount;
            float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
            speedLabelTransform.Find("dashImage").Find("speedText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();
            Debug.Log(i);
            speedLabelTransform.gameObject.SetActive(true);
        }   
    }
    
        private float GetSpeedRotation() {

             float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

             float speedNormalized = speed / speedMax; 
            

             return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;


        }
    }

