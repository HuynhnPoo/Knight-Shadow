using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public abstract class SliderBase : MonoBehaviour
{
    [SerializeField] protected Slider slider;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        LoadSilder();

        this.AddChangeEvent();
       
    }
   
    void LoadSilder()
    {
        if (this.slider == null) this.slider = GetComponent<Slider>();
    }


   protected void AddChangeEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChange);
    }

    protected abstract void OnChange(float amount);
}
