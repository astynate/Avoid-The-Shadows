namespace Assets.Scenes.Global
{
    public static class Utils
    {
        public static bool IsValueInRange(float leftBorder, float rightBorder, float value)
        {
            return value >= leftBorder && value <= rightBorder;
        }
    }
}