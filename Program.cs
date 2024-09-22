using System.Buffers;
Directory.CreateDirectory(@"C:\Users\namiqrasullu\Desktop\Kamil");

var directories = Directory.GetDirectories(@"C:\Users\namiqrasullu\Desktop");

foreach (var directory in directories)
    Console.WriteLine(directory);

var files = Directory.GetFiles(@"C:\Users\namiqrasullu\Desktop");

foreach (var file in files)
    Console.WriteLine(file);

void CopyFile(string source, string destination)
{

    if (File.Exists(source))
    {
        try
        {
            using (var sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
            {

                if (!Path.HasExtension(destination))
                {
                    destination = $@"{destination}\{Path.GetFileNameWithoutExtension(source)}Copy{Path.GetExtension(source)}";
                }
                if (Path.GetExtension(source) == Path.GetExtension(destination))
                {
                    using (var desStream = new FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        var len = 20;
                        var bytes = new byte[len];
                        do
                        {
                            len = sourceStream.Read(bytes, 0, len);
                            desStream.Write(bytes, 0, len);
                            Thread.Sleep(100);

                        } while (0 < len);


                    }

                }
                else
                {
                    Console.WriteLine("Choose correct file extension");
                    Console.ReadKey();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong");
        }
    }
    else
    {
        Console.WriteLine("File not found");
        Console.WriteLine("Press any key for continue");
        Console.ReadKey();
    }
}
static void Main(string[] args)
{

    while (true)
    {
        Console.Write("Source path: ");
        string source = Console.ReadLine()!;
        Console.Write("Destination Path: ");
        string destination = Console.ReadLine()!;

        //Single Thread

        var thread = new Thread(() =>
        {
            CopyFile(source, destination);
        });
        thread.Start();

    }
}
