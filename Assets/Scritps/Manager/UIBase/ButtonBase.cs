using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    [SerializeField] protected Button Button;
   

    // Start is called before the first frame update
    protected virtual void Start()
    {
        LoadComponment();

        this.AddEventListener();
    }

    //ham load componment button
    void LoadComponment()
    {
        if (this.Button != null) return;
        this.Button = GetComponent<Button>();
    }

    //ham them su kien onlclick va addlistener 
    protected virtual void AddEventListener()
    {
        this.Button.onClick.AddListener(this.OnClick);
    }

    //khai bao abstract onclick
    protected abstract void OnClick();


}
