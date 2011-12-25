using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbTool.Lib.Configuration;
using DbTool.Lib.Logging;
using DbTool.Lib.Tasks;

namespace DbTool.Commands
{
    public class CommandProvider : ICommand, ICommandProvider
    {
        public string Usage { get { return string.Empty; } }
        public string Example { get { return string.Empty; } }
        public string Name { get { return "usage"; } }

        private readonly IDictionary<string, ICommand> _tasks = new Dictionary<string, ICommand>();

        private readonly IDbToolLogger _logger;
        private readonly IDbToolSettings _settings;
        private readonly ITaskFactory _taskFactory;

        public CommandProvider(IDbToolConfig config, IDbToolLogger logger, ITaskFactory taskFactory)
        {
            _logger = logger;
            _settings = config.Settings;
            _taskFactory = taskFactory;
            Add(new RestoreDatabase(_logger, _settings, _taskFactory),
                new DeleteDatabase(_logger, _settings, _taskFactory),
                new BackupDatabase(_logger, _settings, _taskFactory),
                new CreateDatabase(_logger, _settings, _taskFactory),
                new ListeDatabases(_logger, _settings, _taskFactory),
                new PopulateContext(_logger, _settings, _taskFactory),
                new MigrateDatabase(_logger, _settings, _taskFactory),
                new ViewDatabaseVersion(_logger, _settings, _taskFactory),
                new ViewDbToolVersion(_logger, _settings),
                new ContextCommand(_logger, _settings),
                new SetSettings(_logger, _settings),
                this);
        }

        private void Add(params ICommand[] commands)
        {
            foreach (var task in commands)
            {
                _tasks.Add(task.Name, task);    
            }
        }

        public ICommand GetCommand(IList<string> args)
        {
            if (args.Count == 0 || !_tasks.ContainsKey(args[0]))
            {
                return this;
            }
            return _tasks[args[0]];
        }

        public void Execute(IList<string> args)
        {
            _logger.WriteLine(PrintUsage(args));
        }

        private string PrintUsage(IList<string> args)
        {
            if (args.Count == 0 || !_tasks.ContainsKey(args[0]))
            {
                return GenerateUsageText();
            }
            var taskName = args[0];
            return _tasks[taskName].GenerateUsageText();
        }

        public string GenerateUsageText()
        {
            var tasks = _tasks.Keys.OrderBy(t => t);
            return new StringBuilder()
                .AppendLine("Supported tasks: ")
                    .Append(string.Join(Environment.NewLine, tasks))
                    .ToString();
        }
    }
}