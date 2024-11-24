namespace Facade
{
    class Facade
    {
        static void Main(string[] args)
        {
            // Subsystems
            Television tv = new Television();
            AudioSystem audio = new AudioSystem();
            MediaPlayer player = new MediaPlayer();

            // Facade
            HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audio, player);

            // Client interacts with the facade
            homeTheater.WatchMovie();
            Console.WriteLine();
            homeTheater.EndMovie();
            
            Console.ReadLine();
        }
    }
    // Subsystem 1
    class Television
    {
        public void TurnOn() => Console.WriteLine("Television: Turning on...");
        public void TurnOff() => Console.WriteLine("Television: Turning off...");
    }

    // Subsystem 2
    class AudioSystem
    {
        public void TurnOn() => Console.WriteLine("AudioSystem: Turning on...");
        public void TurnOff() => Console.WriteLine("AudioSystem: Turning off...");
    }

    // Subsystem 3
    class MediaPlayer
    {
        public void Play() => Console.WriteLine("MediaPlayer: Playing media...");
        public void Stop() => Console.WriteLine("MediaPlayer: Stopping media...");
    }

    // Facade
    class HomeTheaterFacade
    {
        private readonly Television _television;
        private readonly AudioSystem _audioSystem;
        private readonly MediaPlayer _mediaPlayer;

        public HomeTheaterFacade(Television television, AudioSystem audioSystem, MediaPlayer mediaPlayer)
        {
            _television = television;
            _audioSystem = audioSystem;
            _mediaPlayer = mediaPlayer;
        }

        public void WatchMovie()
        {
            Console.WriteLine("Starting movie mode...");
            _television.TurnOn();
            _audioSystem.TurnOn();
            _mediaPlayer.Play();
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting down movie mode...");
            _mediaPlayer.Stop();
            _audioSystem.TurnOff();
            _television.TurnOff();
        }
    }
}
