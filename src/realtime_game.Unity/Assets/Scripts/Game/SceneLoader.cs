using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ボタンから呼ぶ関数
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // 終了ボタン用（任意）
    public void QuitGame()
    {
        Application.Quit();
    }
}
