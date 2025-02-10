using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Gameplay Settings")]
    public TMP_Dropdown difficultyDropdown;     // Difficulty Settings
    public Slider sensitivitySlider;            // Sensitivity Setting
    public Toggle autoReloadToggle;             // Auto Reload Setting

    [Header("Control Settings")]
    public TMP_Dropdown movementTypeDropdown;   // Movement Settings
    public TMP_Dropdown turnTypeDropDown;       // Turning Setting
    public Toggle handDominanceToggle;          // Hand Dominance Setting Left/Right

    [Header("Accessibility Settings")]
    public Slider uiScaleSlider;                // UI Scaler Settings
    public Toggle subtitlesToggle;              // Subtitles Setting


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadSettings();

        // Listeners for Settings
        difficultyDropdown.onValueChanged.AddListener(UpdateDifficulty);             // Difficulty Listener for Settings
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);             // Sensitivity Listener for slider
        autoReloadToggle.onValueChanged.AddListener(UpdateAutoReload);               // Auto Reload Listener for Reload Setting

        // Control Listeners
        movementTypeDropdown.onValueChanged.AddListener(UpdateMovementType);         // Movement Listener for Movement Settings
        turnTypeDropDown.onValueChanged.AddListener(UpdateTurnType);                 // Turning Listener for Turn Type
        handDominanceToggle.onValueChanged.AddListener(UpdateHandDominance);         // Hand Dominance Listener for Hand Settings Left/Right

        // Accessibility Listeners
        uiScaleSlider.onValueChanged.AddListener(UpdateUIScale);                     // UI Scaler Listener for UI scaling
        subtitlesToggle.onValueChanged.AddListener(UpdateSubtitles);                 // Subtitles Listener for Subtitles setting
    }

    // Update is called once per frame
    public void LoadSettings()
    {
        // Load Gameplay Settings
        difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty", 1);              // Loads "Difficulty" setting default is "Normal" ->1
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 1.0f);         // Loads Interaction Sensitivity default 1.0f
        autoReloadToggle.isOn = PlayerPrefs.GetInt("AutoReload", 1) == 1;            // Loads Reload (1 = On, 0 = Off)

        // Load Control Settings
        movementTypeDropdown.value = PlayerPrefs.GetInt("MovementType", 0);          // Loads Movement (0 = Teleport, 1 = Smooth Locomotion)
        turnTypeDropDown.value = PlayerPrefs.GetInt("TurnType", 0);                  // Loads Turn Type (0 = Snap Turn, 1 = Smooth Turn)
        handDominanceToggle.isOn = PlayerPrefs.GetInt("HandDominance", 0) == 1;      // Loads Hand selection (0 = Right, 1 = Left)

        // Load Accessibility Settings
        uiScaleSlider.value = PlayerPrefs.GetFloat("UIScale", 1.0f);                 // Loads UI Scale (1) is Default size
        subtitlesToggle.isOn = PlayerPrefs.GetInt("Subtitles", 0) == 1;              // Loads Subtitles (1 = On, 0 = Off)
    }

    public void UpdateDifficulty(int value)                                         // Updates and Saves (0 = Easy, 1 = Normal, 2 = Hard)
    {
        PlayerPrefs.SetInt("Difficulty", value);                                     // Selected Difficulty
        PlayerPrefs.Save();                                                          // Saves data and is stored   
    }

    public void UpdateSensitivity(float value)                                      // Updates Sensitivity slider setting
    {
        PlayerPrefs.SetFloat("Sensitivity", value);                                  // Selected setting
        PlayerPrefs.Save();                                                          // Saves data and stored   
    }

    public void UpdateAutoReload(bool isOn)                                         // Updates Toggle On/Off
    {
        PlayerPrefs.SetInt("AutoReload", isOn ? 1 : 0);                             // Selected data (True if Auto, False if Disabled)
        PlayerPrefs.Save();                                                          // Saves data and store
    }

    public void UpdateMovementType(int value)                                       // Updates Movement type setting (Teleport, Smooth)
    {
        PlayerPrefs.SetInt("MovementType", value);                                   // Selected setting for Movement (0 = Teleport, 1 = Smooth)
        PlayerPrefs.Save();                                                          // Saves and store
    }

    public void UpdateTurnType(int value)                                           // Updates Turn type setting (Snap, Smooth)
    {
        PlayerPrefs.SetInt("TurnType", value);                                       // Selected setting (0 = Snap, 1 = Smooth)
        PlayerPrefs.Save();                                                          // Saves and store
    }

    public void UpdateHandDominance(bool isOn)                                      // Updates Hand Dominance (Left, Right)
    {
        PlayerPrefs.SetInt("HandDominance", isOn ? 1 : 0);                          // Selected Hand setting (Left, Right)
        PlayerPrefs.Save();                                                          // Saves and store
    }

    public void UpdateUIScale(float value)                                         // Updates UI Scale
    {
        PlayerPrefs.SetFloat("UIScale", value);                                     // Selected UI Scale
        PlayerPrefs.Save();                                                         // Saves and stores
    }

    public void UpdateSubtitles(bool isOn)                                         // Updates Subtitles On/Off
    {
        PlayerPrefs.SetInt("Subtitles", isOn ? 1 : 0);                              // True if enabled, False if disabled
        PlayerPrefs.Save();                                                         // Saves and stores
    }
}
