namespace WikiMusic.ConsoleClient
{
    using System.Linq;
    using Data;

    public class StartUp
    {
       public static void Main()
        {
            var db = new WikiMusicDbContext();
           db.Albums.Count();
        }
    }
}
