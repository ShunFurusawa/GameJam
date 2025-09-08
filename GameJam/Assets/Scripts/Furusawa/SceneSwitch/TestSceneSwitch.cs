
using UnityEngine;
namespace Scripts.Furusawa.SceneSwitch
{
    public class TestSceneSwitch : MonoBehaviour
    {
        [SerializeField] private FadeAndSceneTransition fadeAndSceneTransition;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fadeAndSceneTransition.StartTransition(); // 遷移先のシーン名を指定
            }
        }
    }
}