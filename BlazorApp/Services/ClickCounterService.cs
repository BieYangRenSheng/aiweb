namespace BlazorApp.Services
{
    public class ClickCounterService
    {
        private int _dailyClickCount = 0;
        private DateTime _lastResetDate = DateTime.Today; // 记录上次重置日期
        private const int MaxClicksPerDay = 50; // 每日最大点击次数

        public int DailyClickCount => _dailyClickCount; // 公开只读的每日点击次数
        public int MaxDailyClicks => MaxClicksPerDay; // 公开只读的每日最大点击次数

        public ClickCounterService()
        {
            ResetDailyCountIfNeeded(); // 服务创建时检查是否需要重置
        }

        private void ResetDailyCountIfNeeded()
        {
            // 如果上次重置日期不是今天，则重置计数器
            if (_lastResetDate.Date < DateTime.Today.Date)
            {
                _dailyClickCount = 0;
                _lastResetDate = DateTime.Today;
            }
        }

        public bool IncrementClickCount()
        {
            ResetDailyCountIfNeeded(); // 每次增加计数前检查是否需要重置

            if (_dailyClickCount < MaxClicksPerDay)
            {
                _dailyClickCount++;
                return true; // 点击成功
            }
            return false; // 达到每日限制
        }

        public int GetClickCount()
        {
            ResetDailyCountIfNeeded(); // 获取计数前，确保计数器状态是最新的
            return _dailyClickCount;
        }
    }
}
