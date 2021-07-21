namespace KasperskyTask.Utils.DataManagers
{
    interface IDataReader
    {
        T ReadProperty<T>(string key);
        T ReadObject<T>();
    }
}
