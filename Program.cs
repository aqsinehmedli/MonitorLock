public class Program
{
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

}
    
while (true)
{
    Console.Write("Source path: ");
    var source = Console.ReadLine()!;
    Console.Write("Destination Path: ");
    var destination = Console.ReadLine()!;

    //copyFile(source, destination); // single thread

    var thread = new Thread(() =>
    {
        copyFile(source, destination);
    });
    thread.Start();

}