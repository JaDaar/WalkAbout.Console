using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace WalkAbout
{
    class Program
    {
        static void Main(string[] args)
        {


            var currentTime = DateTime.Now.Minute;
            var nextHour = DateTime.Now.Hour;
            Console.WriteLine($"\n\nEnter the INTERVAL for the Alarm.");
            var interVal = Console.ReadLine();
            int result;

            if (int.TryParse(interVal, out result))
            {
                Console.WriteLine($"\n\nStart Time: {DateTime.Now.ToShortTimeString()}");

                if (CheckTime(result, currentTime, nextHour) == false)
                {

                    InitAudio().controls.play();
                    Console.WriteLine($"\n\nPress any key to terminate WalkAbout");
                    Console.WriteLine($"\n\nStart Time: {DateTime.Now.ToShortTimeString()}");
                    Console.Read();
                }
            }
        }

        private static WindowsMediaPlayer InitAudio()
        {
            WindowsMediaPlayer mp3Player = new WindowsMediaPlayer();
            mp3Player.URL = "RedAlert.mp3";
            return mp3Player;
        }

        private static bool CheckTime(int timerInterval, int startTimeMinutes,int nextHour)
        {
            var updatedInterval = 0;
            if((startTimeMinutes + timerInterval) > 60)
            {
                updatedInterval = (startTimeMinutes + timerInterval) - 60;
                nextHour += 1;
            }
            else
            {
                updatedInterval = (startTimeMinutes + timerInterval);
            }
            for (; ; )
            {
                
                if (updatedInterval > 0)
                {
                    if (DateTime.Now.Minute > updatedInterval && DateTime.Now.Hour==nextHour)
                    {
                        break;
                    }
                    else
                    {
                        // Console.WriteLine($"Time Not Met");
                    }
                }
                else
                {
                    break;
                }
            }
            return false;
        }
    }
}
