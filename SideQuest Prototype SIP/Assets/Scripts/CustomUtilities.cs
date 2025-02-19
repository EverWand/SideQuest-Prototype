using UnityEngine;

namespace CustomUtil
{
    public static class TimeConverter
    {
        public static float TimeToSeconds(int hrs, int mins)
        {
            return ((hrs * 60) + mins) * 60;
        }

        public static int GetTimeDifference(float time, float targetTime)
        {
            return Mathf.FloorToInt(Mathf.Abs(targetTime - time));
        }

        public static (int hours, int minutes) GetTimeFormatted(float seconds)
        {
            int totalSeconds = Mathf.FloorToInt(seconds);
            return (totalSeconds / 3600, (totalSeconds % 3600) / 60);
        }
    }

    public interface ISaveData
    {
        void Save(ref AppData data);

        void Load(AppData data);
    }
}