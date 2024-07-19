using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons;
    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 selectedScale = new Vector3(1.2f, 1.2f, 1.2f);
    public ConfirmButtonController confirmButtonController;

    private Button selectedButton;

    void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        if (selectedButton != null)
        {
            selectedButton.transform.localScale = normalScale;
        }

        if (selectedButton == clickedButton)
        {
            // Si el botón seleccionado es el mismo que se hizo clic, deseleccionarlo
            selectedButton = null;
            confirmButtonController.DisableConfirmButton();
        }
        else
        {
            clickedButton.transform.localScale = selectedScale;
            selectedButton = clickedButton;
            confirmButtonController.EnableConfirmButton();
        }
    }

    public void DeselectAllButtons()
    {
        if (selectedButton != null)
        {
            selectedButton.transform.localScale = normalScale;
            selectedButton = null;
            confirmButtonController.DisableConfirmButton();
        }
    }
}
