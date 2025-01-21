using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    public StoryScene storyScene4;
    public StoryScene winScene;
    public StoryScene loseScene;

    void Start()
    {
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence())
                {
                    // Jika berada di scene 4 dan percakapan selesai, pindah ke scene Gameplay
                    if (currentScene == storyScene4)
                    {
                        SceneManager.LoadScene("Tutorial");  // Gantilah dengan nama scene gameplay Anda
                        return;
                    }

                    // Jika berada di scene Win dan percakapan selesai, pindah ke MainMenu
                    if (currentScene == winScene)
                    {
                        SceneManager.LoadScene("MainMenu");  // Pindah ke scene MainMenu
                        return;
                    }

                    // Jika berada di scene Lose dan percakapan selesai, pindah ke MainMenu
                    if (currentScene == loseScene)
                    {
                        SceneManager.LoadScene("MainMenu");  // Pindah ke scene MainMenu
                        return;
                    }

                    if (currentScene.nextScene == null) return;

                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                }
                else
                {
                    bottomBar.PlayNextSentence();
                }
            }
            else
            {
                bottomBar.SkipOrCompleteText(); // Skip animasi teks
            }
        }
    }
}
