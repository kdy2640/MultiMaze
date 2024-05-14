
using MazeClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MazeClient.Scenes;
using MazeClient.Share;

namespace MazeClient
{
    class SceneManager
    {
        GameManager Manager;
        public BaseScene baseScene;
        public SceneManager()
        { 
        }
        public Form GetSceneInstance(Define.GameState gameState)
        {
            Form newScene;
            switch (gameState)
            { 
                case Define.GameState.MainScene:
                    newScene = new MainScene();
                    break;
                case Define.GameState.SettingScene:
                    newScene = new SettingScene();
                    break;
                case Define.GameState.WaitScene:
                    newScene = new WaitScene();
                    break;
                case Define.GameState.InGameScene:
                    newScene = new InGameScene();
                    break;
                case Define.GameState.RoundOverScene:
                    newScene = new RoundOverScene();
                    break;
                case Define.GameState.GameOverScene:
                    newScene = new GameOverScene();
                    break;
                default:
                    newScene = null;
                    break;
            }
            return newScene;
        }
        public void ChangeGameState(Form sender, Define.GameState gameState)
        {
            Manager = GameManager.Instance;
            Manager.state = gameState;
            Form waitScene = GetSceneInstance(gameState);
            sender.Hide();
            waitScene.Top = sender.Top;
            waitScene.Left = sender.Left;

            waitScene.FormClosing += Scene_FormClosing;
            BaseScene.formCount += 1;

            waitScene.Show();
            sender.Close();
        }
        public void Scene_FormClosing(object sender, FormClosingEventArgs e)
        { 
            BaseScene.formCount -= 1;
            baseScene.CountUpdate();
        }
        private void Scene_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
