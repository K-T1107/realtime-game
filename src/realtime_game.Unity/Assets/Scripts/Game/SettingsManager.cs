using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;

    // ★ 視点制御スクリプトを参照
    public PlayerLook playerLook;
    public CameraLook cameraLook;

    bool isOpen = false;

    void Start()
    {
        settingsPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
                CloseSettings();
            else
                OpenSettings();
        }
    }

    public void OpenSettings()
    {
        isOpen = true;
        settingsPanel.SetActive(true);

        // ゲーム停止
        Time.timeScale = 0f;

        // ★ 視点停止
        if (playerLook != null) playerLook.enabled = false;
        if (cameraLook != null) cameraLook.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseSettings()
    {
        isOpen = false;
        settingsPanel.SetActive(false);

        // ゲーム再開
        Time.timeScale = 1f;

        // ★ 視点再開
        if (playerLook != null) playerLook.enabled = true;
        if (cameraLook != null) cameraLook.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}