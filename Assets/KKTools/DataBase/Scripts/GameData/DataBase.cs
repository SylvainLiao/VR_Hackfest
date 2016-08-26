public abstract class DataBase
{
    public DataBase()
    {
        Init();
    }

    /// <summary>
    /// 重新刷新資料層參數
    /// </summary>
    public void RefreshGameData()
    {
        RefreshData();
    }

    /// <summary>
    /// 重新刷新資料層參數
    /// </summary>
    protected abstract void RefreshData();

    /// <summary>
    /// 初始化
    /// </summary>
    protected abstract void Init();
}
