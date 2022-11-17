using CCESymp.Data.Mapping;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CCESymp.API.Utilities
{
    public class FilesUtility
    {
        public static List<GlobalConnectionModel> GetTemplateUIElements(string template)
        {
            List<GlobalConnectionModel> uiElementsList = new List<GlobalConnectionModel>();
            XDocument xml = XDocument.Parse("<root>" + template + "</root>");
            var CCESolutionConfiguration = xml.Element("root").Element("CCESolutionConfiguration");
            var UIInput = CCESolutionConfiguration.Element("UIInput");
            var UIElements = UIInput.Descendants("UIElement");
            foreach (var item in UIElements)
            {
                GlobalConnectionModel newElement = new GlobalConnectionModel()
                {
                    Name = item.Attribute("name").Value,
                    Type = item.Attribute("type").Value,
                    Description = item.Attribute("desc").Value
                };
                uiElementsList.Add(newElement);
            }

            return uiElementsList;
        }

    }
}
