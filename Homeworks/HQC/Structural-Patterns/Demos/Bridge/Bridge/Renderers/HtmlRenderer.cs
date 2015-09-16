namespace Bridge.Renderers
{
    public class HtmlRenderer : IRenderer
    {
        public string Render(string key, string value)
        {
            return string.Format($"<div id=\"{key.ToLower()}\">\n\t{value}\n</div>");
        }
    }
}
