using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTest : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!button.IsInteractable())
        {
            button.transition = Selectable.Transition.ColorTint;

            ColorBlock co = button.colors;

            co.disabledColor = new Color(0, 0, 0, 130f);

            button.colors = co;
        }
    }

}
