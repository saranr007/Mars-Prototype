using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    public TouchEvent TouchFeedback;
    public float FuelRate;
    private float DefaulFuelRate;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        DefaulFuelRate = FuelRate;
        slider.maxValue = DefaulFuelRate;
        slider.minValue = 0;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseFuel();
        FuelSliderVisual();
        
    }
    void DecreaseFuel()
    {
        if (TouchFeedback.IsMoving)
        {
            FuelRate -= TouchFeedback.Thruster_RigidBody.velocity.magnitude * Time.deltaTime;
        }
        if (FuelRate<=0)
        {
            Respawner.respawner.BackToPosition();
            FuelRate = DefaulFuelRate;
        }
    }
    public void AddFuel()
    {
        FuelRate += (DefaulFuelRate - FuelRate);
    }
    void FuelSliderVisual()
    {
        slider.value = Mathf.Lerp(slider.value, FuelRate, Time.deltaTime);
        slider.value = FuelRate;
        slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, FuelRate*7*Time.fixedDeltaTime);
    }

}
