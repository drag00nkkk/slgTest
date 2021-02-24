namespace Base
{
    /*
        单例，全局唯一，通常用在Manager和一些特殊窗口上
        比如退出弹窗之类的只需要一个的窗口
     */
    public class StandSingleton<T> where T : new()
    {
        private static T _instance;

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }
    }
}