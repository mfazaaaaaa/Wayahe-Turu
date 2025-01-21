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
                    if (currentScene.nextScene == null)
                    {
                        // Pindah ke scene Gameplay jika berada di akhir StoryScene 4
                        if (currentScene == storyScene4)  // Pastikan storyScene4 adalah referensi ke scene terakhir (scene 4)
                        {
                            SceneManager.LoadScene("Gameplay");  // Gantilah dengan nama scene gameplay Anda
                        }
                        return;
                    }

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
