using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ChiSha
{

    public class HttpProcessor
    {
        public TcpClient socket;
        public HttpServer srv;

        private Stream inputStream;
        public StreamWriter outputStream;

        public String http_method;
        public String http_url;
        public String http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();


        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        public HttpProcessor(TcpClient s, HttpServer srv)
        {
            this.socket = s;
            this.srv = srv;
        }


        private string streamReadLine(Stream inputStream)
        {
            int next_char;
            string data = "";
            while (true)
            {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }
            return data;
        }
        public void process()
        {
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try
            {
                parseRequest();
                readHeaders();
                if (http_method.Equals("GET"))
                {
                    handleGETRequest();
                }
                else if (http_method.Equals("POST"))
                {
                    handlePOSTRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                writeFailure();
            }
            outputStream.Flush();
            // bs.Flush(); // flush any remaining output
            inputStream = null; outputStream = null; // bs = null;            
            socket.Close();
        }

        public void parseRequest()
        {
            String request = streamReadLine(inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("invalid http request line");
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
            http_protocol_versionstring = tokens[2];

            Console.WriteLine("starting: " + request);
        }

        public void readHeaders()
        {
            Console.WriteLine("readHeaders()");
            String line;
            while ((line = streamReadLine(inputStream)) != null)
            {
                if (line.Equals(""))
                {
                    Console.WriteLine("got headers");
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }

                string value = line.Substring(pos, line.Length - pos);
                Console.WriteLine("header: {0}:{1}", name, value);
                httpHeaders[name] = value;
            }
        }

        public void handleGETRequest()
        {
            srv.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            Console.WriteLine("get post data start");
            int content_len = 0;
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("Content-Length"))
            {
                content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
                if (content_len > MAX_POST_SIZE)
                {
                    throw new Exception(
                        String.Format("POST Content-Length({0}) too big for this simple server",
                          content_len));
                }
                byte[] buf = new byte[BUF_SIZE];
                int to_read = content_len;
                while (to_read > 0)
                {
                    Console.WriteLine("starting Read, to_read={0}", to_read);

                    int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                    Console.WriteLine("read finished, numread={0}", numread);
                    if (numread == 0)
                    {
                        if (to_read == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    to_read -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            Console.WriteLine("get post data end");
            srv.handlePOSTRequest(this, new StreamReader(ms));

        }

        public void writeSuccess()
        {
            outputStream.WriteLine("HTTP/1.0 200 OK");
            outputStream.WriteLine("Content-Type: text/html;charset=utf-8");
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }

        public void writeFailure()
        {
            outputStream.WriteLine("HTTP/1.0 404 File not found");
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }
    }

    public abstract class HttpServer
    {

        protected int port;
        TcpListener listener;
        bool is_active = true;
        List<CancellationTokenSource> ctsList = new List<CancellationTokenSource>();
        List<Task> taskList = new List<Task>();
        //List<Thread> threadList = new List<Thread>();
        //List<HttpProcessor> processorList = new List<HttpProcessor>();
        //List<TcpClient> tcpClientList = new List<TcpClient>();

        public HttpServer(int port)
        {
            this.port = port;
        }

        public void listen()
        {
            listener = new TcpListener(port);
            listener.Start();
            while (is_active)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                TcpClient s = listener.AcceptTcpClient();
                //tcpClientList.Add(s);
                HttpProcessor processor = new HttpProcessor(s, this);
                //processorList.Add(processor);
                Task task = new Task(() =>
                {
                    try
                    {
                        processor.process();
                        cts.Token.ThrowIfCancellationRequested();
                    }
                    catch (Exception ex)
                    {
                    }
                }, cts.Token);
                //Thread thread = new Thread(new ThreadStart(processor.process));
                //threadList.Add(thread);
                //thread.Start();
                //Thread.Sleep(1);
                task.Start();
                taskList.Add(task);
                ctsList.Add(cts);
                task.Wait(1);
            }
        }

        public void close()
        {
            foreach(CancellationTokenSource cts in ctsList)
            {
                cts.Cancel();
            }
        }

        public abstract void handleGETRequest(HttpProcessor p);
        public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
    }

    public class MyHttpServer : HttpServer
    {
        public MyHttpServer(int port)
            : base(port)
        {
        }
        private String getRecipe()
        {
            List<Data> data = new DataHandle(new ConfigHandle("config.json").getConfig().dataPath).getData();
            String html = "";
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iSeed);
            Data d = data[random.Next(0, data.Count)];
            html += "<h1><a href='https://www.xiachufang.com" + d.url + "'>" + d.title + "</a></h1>";
            html += "<h3>配料：</h3>";
            foreach (var ing in d.ins.Keys)
            {
                html += "<li>" + ing + " @ " + d.ins[ing] + "</li>";
            }
            html += "<h3>步骤：</h3>";
            html += "<ol>";
            foreach (Dictionary<String, String> step in d.steps)
            {
                html += "<li>" + step["text"] + "</li>";
            }
            html += "</ol>";
            html += "<a href='https://www.xiachufang.com" + d.url + "'>==>查看详情<==</a><br><br><br>";
            html += "<input style='width: 200px; height: 60px; font-size:30px;' type='button' value='再来一个' onclick='location.reload();'>";

            return html;
        }
        public override void handleGETRequest(HttpProcessor p)
        {
            Console.WriteLine("request: {0}", p.http_url);
            p.writeSuccess();
            p.outputStream.WriteLine(getRecipe());
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();

            p.outputStream.WriteLine(getRecipe());


        }
    }

    class ChishaServer
    {
        //static Thread thread;
        HttpServer httpServer;
        static Task task;

        CancellationTokenSource cts;

        public ChishaServer(int port)
        {
            httpServer = new MyHttpServer(port);
            cts = new CancellationTokenSource();
            //thread = new Thread(new ThreadStart(httpServer.listen));
            task = new Task(() =>
            {
                try
                {
                    httpServer.listen();
                    cts.Token.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                }
            }, cts.Token);
        }
        public void start()
        {
            //thread.Start();
            task.Start();
        }
        public void kill()
        {
            //thread.Abort();
            httpServer.close();
            cts.Cancel();
            //task.Dispose();
        }
    }
}