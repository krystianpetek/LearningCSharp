using System.Dynamic;
using System.Xml.Linq;

namespace Rozdzial18_3
{
    internal class DynamicXml : DynamicObject
    {
        private XElement Element { get; set; }

        public DynamicXml(XElement element)
        {
            Element = element;
        }

        public static DynamicXml Parse(string text)
        {
            return new DynamicXml(XElement.Parse(text));
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            bool success = false;
            result = null;
            XElement firstDescendant = Element.Descendants(binder.Name).FirstOrDefault()!;
            if (firstDescendant != null)
            {
                if (firstDescendant.Descendants().Any())
                    result = new DynamicXml(firstDescendant);
                else
                    result = firstDescendant.Value;

                success = true;
            }
            return success;
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            bool success = false;
            XElement firstDescendant = Element.Descendants(binder.Name).FirstOrDefault()!;
            if (firstDescendant != null)
            {
                if (value.GetType() == typeof(XElement))
                    firstDescendant.ReplaceWith(value);
                else
                    firstDescendant.Value = value.ToString();

                success = true;
            }
            return success;
        }
    }
}
