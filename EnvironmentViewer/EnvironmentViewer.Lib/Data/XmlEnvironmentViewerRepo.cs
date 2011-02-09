using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using EnvironmentViewer.Lib.Domain;

namespace EnvironmentViewer.Lib.Data
{
    public class XmlEnvironmentViewerRepo : IEnvironmentViewerRepo
    {
        private readonly string _filePath;

        public XmlEnvironmentViewerRepo(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<EnvironmentData> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new EnvironmentData[0];
            }
            using (var stream = File.OpenRead(_filePath))
            {
                var serializer = new XmlSerializer(typeof(EnvironmentContainer));
                var container =  (EnvironmentContainer) serializer.Deserialize(stream);
                return container.Environments;
            }
        }

        public void SaveAll(IEnumerable<EnvironmentData> environments)
        {
            var container = new EnvironmentContainer{Environments = environments.ToList()};
            var serializer = new XmlSerializer(typeof (EnvironmentContainer));
            using (var stream = File.Create(_filePath))
            {
                serializer.Serialize(stream, container);
            }
        }
    }
}