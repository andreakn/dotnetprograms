﻿using DbTool.Lib.Configuration;

namespace DbTool.Lib.Tasks
{
    public interface ITaskFactory
    {
        IBackupTask CreateBackupTask(ConnectionData connection);
        IRestoreTask CreateRestoreTask(ConnectionData connection);
        ICreateDbTask CreateCreateDbTask(ConnectionData connection);
        IDeleteDbTask CreateDeleteDbTask(ConnectionData defaultConnection);
        IListDbTask CreateListDbTask(ConnectionData connection);
        IPopulateContextTask CreatePopulateContextTask(ConnectionData connection);
    }
}