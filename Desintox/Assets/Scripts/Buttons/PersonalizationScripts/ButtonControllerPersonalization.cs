using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ButtonControllerPersonalization : MonoBehaviour
{
    public Button P1;
    public Button P2;
    public Button P3;
    public Button P4;

    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 selectedScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float animationDuration = 0.2f;
    public Button[] colorButtons; // Arreglo de botones de colores
    public TMP_InputField nameInputField; // Espacio para escribir el nombre
    public ConfirmButtonControllerPer ConfirmButtonControllerPer;
    public ConfirmButtonNext ConfirmButtonNext;
    public GameController gameController;
    private bool colorButtonSelected = false;
    public int PlayerSelectTurn;
    public string ColorPlayer1 = null;
    public string ColorPlayer2 = null;
    public string ColorPlayer3 = null;
    public string ColorPlayer4 = null;

    public Image imageForP1;
    public Image imageForP2;
    public Image imageForP3;
    public Image imageForP4;

    private Button selectedButton;
    private const int MaxNameLength = 10; // Límite de caracteres para el nombre

    void Start()
    {
        PlayerSelectTurn = GameController.NumJugadores;
        // Asignamos los listeners a los botones específicos
        P1.onClick.AddListener(() => OnButtonClick(P1));
        P2.onClick.AddListener(() => OnButtonClick(P2));
        P3.onClick.AddListener(() => OnButtonClick(P3));
        P4.onClick.AddListener(() => OnButtonClick(P4));

        // Asignamos los listeners a los botones de colores usando un bucle
        foreach (Button colorButton in colorButtons)
        {
            colorButton.onClick.AddListener(() => OnColorButtonClick(colorButton));
        }

        // Asignamos un listener al campo de entrada
        nameInputField.onValueChanged.AddListener(OnNameInputValueChanged);
    }

    void OnButtonClick(Button clickedButton)
    {
        int selectedAvatar = 0; // Inicializamos con un valor que no corresponde a ningún avatar

        if (clickedButton == P1)
            selectedAvatar = 1;
        else if (clickedButton == P2)
            selectedAvatar = 2;
        else if (clickedButton == P3)
            selectedAvatar = 3;
        else if (clickedButton == P4)
            selectedAvatar = 4;

        if (selectedAvatar > 0 && PlayerSelectTurn >= 1 && PlayerSelectTurn <= 4)
        {
            switch (PlayerSelectTurn)
            {
                case 1:
                    GameController.avatarP1 = selectedAvatar;
                    break;
                case 2:
                    GameController.avatarP2 = selectedAvatar;
                    break;
                case 3:
                    GameController.avatarP3 = selectedAvatar;
                    break;
                case 4:
                    GameController.avatarP4 = selectedAvatar;
                    break;
            }

            PlayerSelectTurn--;
        }

        if (selectedButton != clickedButton)
        {
            if (selectedButton != null)
            {
                // Detenemos la animación anterior si existe en el GameController
                gameController.StartRestoreNormalScaleAnimation(selectedButton);
            }

            // Escalamos el botón recién seleccionado en el GameController
            gameController.StartScaleAnimation(clickedButton, selectedScale);
            selectedButton = clickedButton;

            // Encendemos la imagen correspondiente
            UpdateImageState(clickedButton);

            // Llamamos a la función para actualizar el estado del botón de confirmación
            ConfirmButtonControllerPer.EnableConfirmButton();
        }
    }

    void OnColorButtonClick(Button colorButton)
    {
        if (selectedButton != colorButton)
        {
            if (selectedButton != null)
            {
                // Detenemos la animación anterior si existe en el GameController
                gameController.StartRestoreNormalScaleAnimation(selectedButton);
            }

            // Escalamos el botón recién seleccionado en el GameController
            gameController.StartScaleAnimation(colorButton, selectedScale);
            selectedButton = colorButton;
            colorButtonSelected = true;

            // Actualizamos el estado del botón ConfirmButtonNext
            UpdateConfirmButtonState();

            // Guardamos el nombre del botón según el valor de PlayerSelectTurn
            switch (PlayerSelectTurn)
            {
                case 1:
                    ColorPlayer1 = colorButton.name;
                    GameController.ColorP1 = ColorPlayer1;
                    break;
                case 2:
                    ColorPlayer2 = colorButton.name;
                    GameController.ColorP2 = ColorPlayer2;
                    break;
                case 3:
                    ColorPlayer3 = colorButton.name;
                    GameController.ColorP3 = ColorPlayer3;
                    break;
                case 4:
                    ColorPlayer4 = colorButton.name;
                    GameController.ColorP4 = ColorPlayer4;
                    break;
                default:
                    // Manejar caso inesperado (por ejemplo, mostrar un mensaje de error)
                    break;
            }
        }
    }

    void OnNameInputValueChanged(string newName)
    {
        switch (PlayerSelectTurn)
        {
            case 1:
                // Limitamos la longitud del nombre
                if (newName.Length > MaxNameLength)
                {
                    nameInputField.text = newName.Substring(0, MaxNameLength);
                    GameController.NameP1 = nameInputField.text;
                }
                break;
            case 2:
                if (newName.Length > MaxNameLength)
                {
                    nameInputField.text = newName.Substring(0, MaxNameLength);
                    GameController.NameP2 = nameInputField.text;
                }
                break;
            case 3:
                if (newName.Length > MaxNameLength)
                {
                    nameInputField.text = newName.Substring(0, MaxNameLength);
                    GameController.NameP3 = nameInputField.text;
                }
                break;
            case 4:
                if (newName.Length > MaxNameLength)
                {
                    nameInputField.text = newName.Substring(0, MaxNameLength);
                    GameController.NameP4 = nameInputField.text;
                }
                break;
        }

        // Actualizamos el estado del botón ConfirmButtonNext
        UpdateConfirmButtonState();
    }

    void UpdateImageState(Button button)
    {
        // Apagamos todas las imágenes
        imageForP1.gameObject.SetActive(false);
        imageForP2.gameObject.SetActive(false);
        imageForP3.gameObject.SetActive(false);
        imageForP4.gameObject.SetActive(false);

        // Encendemos la imagen correspondiente al botón seleccionado
        if (button == P1) imageForP1.gameObject.SetActive(true);
        else if (button == P2) imageForP2.gameObject.SetActive(true);
        else if (button == P3) imageForP3.gameObject.SetActive(true);
        else if (button == P4) imageForP4.gameObject.SetActive(true);
    }

    void UpdateConfirmButtonState()
    {
        Debug.Log(GameController.NameP1);
        // Verificamos si se ha seleccionado un ColorButton y si hay texto en el InputField
        bool canProceed = colorButtonSelected &&
                          !string.IsNullOrEmpty(nameInputField.text);
        // Activamos o desactivamos el botón según las condiciones
        if (canProceed)
        {
            ConfirmButtonNext.EnableConfirmButtonNextScene();
        }
        else
        {
            ConfirmButtonNext.DisableConfirmButtonNextScene();
        }
    }
}