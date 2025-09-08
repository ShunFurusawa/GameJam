namespace Scripts.Furusawa.SceneSwitch
{
    public interface IFadeHandler
    {
        void StartFadeOut();        // フェードアウトを開始する
        bool IsFadeOutComplete();   // フェードアウトが完了したかを確認する
    }
}