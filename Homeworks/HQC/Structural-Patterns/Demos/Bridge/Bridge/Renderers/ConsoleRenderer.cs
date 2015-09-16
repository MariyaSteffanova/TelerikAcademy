namespace Bridge.Renderers
{
    public class ConsoleRenderer : IRenderer
    {
        public string Render(string key, string value)
        {
            return $"{key,10} : {value}";
        }
    }
}
