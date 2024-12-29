using UnityEngine;

namespace DemoGame
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        private void Start()
        {
            InitBuiltinComponents();
            //!!!todo: InitCustomComponents();
            //note：这里的InitCustomComponents()方法是自定义的，还没有加进来
            //InitCustomComponents();
        }
    }
}