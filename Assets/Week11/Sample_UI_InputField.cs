using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Sample_UI_InputField : MonoBehaviour
{
    public TMP_InputField InputField_Focus;
    public TMP_InputField InputField_SetPlaceHolder;
    public TMP_InputField InputField_Get;
    public TMP_InputField InputField_Set;
    public TMP_InputField InputField_GetValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        InputField_Focus.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_ClearInputField()
    {
        InputField_Focus.GetComponent<TMP_InputField>().text = "";
        InputField_Focus.Select();
    }

    public void OnClick_SetPlaceHolder(string text)
    {
        //InputField_SetPlaceHolder.GetComponent<TMP_Text>().text = text;
        InputField_SetPlaceHolder.transform.GetChild(0).Find("Placeholder").GetComponent<TMP_Text>().text = text;
    }

    public void OnClick_GetInputField()
    {
        string text = InputField_Get.text;
        print(text);
        InputField_Get.text = "";
        InputField_Get.Select();
    }

    public void OnClick_SetInputField(string text)
    {
        InputField_SetPlaceHolder.text = text;
    }

    public void OnValueChanged_GetInputfield()
    {
        string text = InputField_GetValueChanged.text;
        print(text);
    }
}
