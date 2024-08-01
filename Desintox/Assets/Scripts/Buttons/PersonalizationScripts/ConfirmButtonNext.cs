using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ConfirmButtonNext : MonoBehaviour
{
    public CanvasGroup ConfirmButtonNextSceneCanvasGroup;
    public Button ConfirmButtonNextScene;
    public GameObject Canvas1; // Asigna el canvas desde el Inspector
    public string nombreSiguienteEscena = "NombreDeTuOtraEscena"; // Asigna el nombre de la siguiente escena
    private int clicksRequired; // Ahora esta variable tendrá el mismo valor que savedNumJug
    public ConfirmButtonControllerPer ConfirmButtonControllerPer;
    public Button[] colorButtons; // Arreglo de botones de colores
    public GameController gameController;
    public Button P1;
    public Button P2;
    public Button P3;
    public Button P4;
    public Button ConfirmButton;
    string nombreDelColor;
    private Button selectedButton;

    void Start()
    {
        foreach (Button colorButton in colorButtons)
        {
            colorButton.onClick.AddListener(() => OnColorButtonClick(colorButton));
        }

        clicksRequired = GameController.NumJugadores;
        DisableConfirmButtonNextScene();

        // Asignamos un listener al botón para manejar el clic
        ConfirmButtonNextScene.onClick.AddListener(OnConfirmButtonNextClick);
    }

    public void EnableConfirmButtonNextScene()
    {
        // Habilita el botón de confirmación
        ConfirmButtonNextScene.interactable = true;
        ConfirmButtonNextSceneCanvasGroup.alpha = 1f; // Opacidad completa (sin transparencia)
    }

    public void DisableConfirmButtonNextScene()
    {
        // Deshabilita el botón de confirmación
        ConfirmButtonNextScene.interactable = false;
        ConfirmButtonNextSceneCanvasGroup.alpha = 0.5f; // Opacidad reducida (transparencia)
    }

    public void OnConfirmButtonNextClick()
    {
        if (nombreDelColor == GameController.ColorP1 || nombreDelColor == GameController.ColorP2 || nombreDelColor == GameController.ColorP3 || nombreDelColor == GameController.ColorP4)
        {
            selectedButton.interactable = false;
            Color P1selectedButton = selectedButton.image.color;
            P1selectedButton.a = 0.5f;
            selectedButton.image.color = P1selectedButton;
        }

        if (GameController.avatarP1 >= 1 && GameController.avatarP1 <= 4)
        {
            Button p1Button = GetButtonForAvatar(GameController.avatarP1);
            p1Button.interactable = false;
            Color p1ButtonColor = p1Button.image.color;
            p1ButtonColor.a = 0.5f;
            p1Button.image.color = p1ButtonColor;
        }
        if (GameController.avatarP2 >= 1 && GameController.avatarP2 <= 4)
        {
            Button p2Button = GetButtonForAvatar(GameController.avatarP2);
            p2Button.interactable = false;
            Color p2ButtonColor = p2Button.image.color;
            p2ButtonColor.a = 0.5f;
            p2Button.image.color = p2ButtonColor;
        }
        if (GameController.avatarP3 >= 1 && GameController.avatarP3 <= 4)
        {
            Button p3Button = GetButtonForAvatar(GameController.avatarP3);
            p3Button.interactable = false;
            Color p3ButtonColor = p3Button.image.color;
            p3ButtonColor.a = 0.5f;
            p3Button.image.color = p3ButtonColor;
        }
        if (GameController.avatarP4 >= 1 && GameController.avatarP4 <= 4)
        {
            Button p4Button = GetButtonForAvatar(GameController.avatarP4);
            p4Button.interactable = false;
            Color p4ButtonColor = p4Button.image.color;
            p4ButtonColor.a = 0.5f;
            p4Button.image.color = p4ButtonColor;
        }

        Button GetButtonForAvatar(int avatar)
        {
            switch (avatar)
            {
                case 1: return P1;
                case 2: return P2;
                case 3: return P3;
                case 4: return P4;
                default: return null;
            }
        }

        if (clicksRequired == 1)
        {
            SceneManager.LoadScene(nombreSiguienteEscena);
        }
        else
        {
            clicksRequired--;
            Canvas1.SetActive(true);
            ConfirmButtonControllerPer.DisableConfirmButton();
            DisableConfirmButtonNextScene();
        }
    }

    public void OnColorButtonClick(Button colorButton)
    {
        selectedButton = colorButton;
        nombreDelColor = selectedButton.name;
        Debug.Log(nombreDelColor);
    }
}
//Debug.Log($"Starting {name}!", this);