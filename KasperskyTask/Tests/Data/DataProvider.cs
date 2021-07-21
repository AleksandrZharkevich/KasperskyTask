using KasperskyTask.Utils.DataManagers;
using System.Collections.Generic;

namespace KasperskyTask.Tests.Data
{
    class DataProvider
    {
        public static List<string[]> GetData()
        {
            IDataReader dataManager = new JsonDataReader(Constants.TestCaseSourcePath);
            return dataManager.ReadProperty<List<string[]>>("data");
        }
    }
}
