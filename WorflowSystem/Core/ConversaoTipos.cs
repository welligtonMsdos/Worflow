namespace Worflow.Core
{
    public static class ConversaoTipos
    {
        public static bool IsNumber(string value)
        {
            return int.TryParse(value, out int valor);
        }
    }
}
