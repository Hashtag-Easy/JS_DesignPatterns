using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Samples
{
    internal class BuilderPattern
    {
        public void StringBuilder()
        {
            var builder = new StringBuilder("Hi there")
                .Append("and there")
                .ToString();
        }
    }


    
    public class HtmlBuilder
    {
        private HtmlTag root = new HtmlTag("html");

        public HtmlBuilder()
        {
            root.Tags.Add(new HtmlTag("header"));
            root.Tags.Add(new HtmlTag("body"));
        }

        public HtmlBuilder CreateNewTagInBody(string element)
        {
            root.Tags[1].Tags.Add(new HtmlTag(element));
            return this;
        }

        public HtmlBuilder CreateNewTagAtPosition(string element, int position)
        {
            root.Tags[1].Tags[position].Tags.Add(new HtmlTag(element));
            return this;
        }

        public string BuildHtmlPage()
        {
            var result = new StringBuilder();

            result.Append($"<{root.TagName}>");

            foreach (var item in root.Tags)
            {
                //
            }

            return result.ToString();
        }

        private class HtmlTag
        {
            public string TagName { get; private set; }

            public List<HtmlTag> Tags { get; set; }

            public HtmlTag(string tag)
            {
                TagName = tag;
            }
        }
    }


    public class TestBuilder
    {
        public void Test()
        {
            var html = new HtmlBuilder();

            html.CreateNewTagInBody("Div")
                .CreateNewTagAtPosition("il", 0)
                .CreateNewTagAtPosition("ul", 1)
                .BuildHtmlPage();
        }
    }
}
