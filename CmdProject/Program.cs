using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CmdProject
{
    class Program
    {
        private DelegateParam paramModel = new DelegateParam();
        private delegate UserInfo ParamDelegate(UserInfo param);
        private delegate string ContinueString(string name);

        static void Main(string[] args)
        {

            #region 简单多线程
            //ThreadDemo demo = new ThreadDemo();
            //Thread thread = new Thread(demo.Run);
            //thread.IsBackground = true;
            //thread.Start();
            ////等待直到线程完成
            //thread.Join();
            //Console.WriteLine("Main thread working...");
            //Console.WriteLine("Main thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
            //Console.ReadKey();
            #endregion

            #region 有参数&返回值线程处理
            //DelegateParam param = new DelegateParam();
            //ThreadDemoClass demo = new ThreadDemoClass();
            //ParameterizedThreadStart threadStart = new ParameterizedThreadStart(demo.Run);

            //Thread thread = new Thread(threadStart);
            //thread.IsBackground = true;
            //param.name = "Jhon";
            //param.age = "12";
            //thread.Start(param);
            //thread.Join();
            //Console.WriteLine("Main thread working...");
            //Console.WriteLine("Main thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
            //Console.Read();
            #endregion


            #region 线程池
            //ThreadDemoClass demoClass = new ThreadDemoClass();
            ////设置当没有请求时线程池维护的空闲线程数
            ////第一个参数为辅助线程数
            ////第二个参数为异步 I/O 线程数
            //ThreadPool.SetMinThreads(5, 5);

            ////设置同时处于活动状态的线程池的线程数，所有大于次数目的请求将保持排队状态，直到线程池变为可用
            ////第一个参数为辅助线程数
            ////第二个参数为异步 I/O 线程数
            //ThreadPool.SetMaxThreads(100, 100);
            ////使用委托排入队列，在线程池可变为可用时执行(无参数)
            //WaitCallback waitCallback = new WaitCallback(demoClass.Run);
            //ThreadPool.QueueUserWorkItem(waitCallback);
            ////使用委托排入队列，

            //WaitCallback waitCallback1 = new WaitCallback(demoClass.Run);
            //ThreadPool.QueueUserWorkItem(waitCallback1, "强");

            //DelegateParam param = new DelegateParam();
            //param.name = "Jhon";
            //param.age = "12";
            //WaitCallback waitCallback2 = new WaitCallback(demoClass.Run2);
            //ThreadPool.QueueUserWorkItem(waitCallback2, param);

            //Console.WriteLine();
            //Console.WriteLine("Main thread working...");
            //Console.WriteLine("Main thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
            //Console.ReadKey();

            #endregion

            #region 异步委托（线程返回值）
            //List<UserInfo> userInfos = new List<UserInfo>();
            //ThreadDemo2 demo2 = new ThreadDemo2();
            //UserInfo userInfo = null;
            //UserInfo userInfoRes = null;
            //ParamDelegate paramDele = new ParamDelegate(demo2.Run);
            //for (int i = 0; i < 3; i++)
            //{
            //    userInfo = new UserInfo();
            //    userInfo.Name = "Jhon" + i.ToString();
            //    userInfo.Age = "99" + i.ToString();
            //    IAsyncResult asyncResult = paramDele.BeginInvoke(userInfo, null, null);
            //    ////异步操作是否完成
            //    //while (!asyncResult.IsCompleted)
            //    //{
            //    //    Thread.Sleep(100);
            //    //    Console.WriteLine("Main thread working...");
            //    //    Console.WriteLine("Main thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
            //    //    Console.WriteLine();
            //    //}
            //    //阻止当前线程，直到 WaitHandle 收到信号，参数为指定等待的毫秒数
            //    while (!asyncResult.AsyncWaitHandle.WaitOne(1000))
            //    {
            //        Thread.Sleep(100);
            //        Console.WriteLine("Main thread working...");
            //        Console.WriteLine("Main thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
            //        Console.WriteLine();
            //    }
            //    userInfoRes = paramDele.EndInvoke(asyncResult);
            //    userInfos.Add(userInfoRes);
            //}
            //foreach (UserInfo user in userInfos)
            //{
            //    Console.WriteLine("My name is " + user.Name);
            //    Console.WriteLine("I'm " + user.Age + " years old this year");
            //    Console.WriteLine("Thread ID is:" + user.ThreadId);
            //}

            //Console.ReadKey();
            #endregion


            #region Task生命周期
            //var task1 = new Task(() =>
            // {
            //     Console.WriteLine("Begin");
            //     Thread.Sleep(2000);
            //     Console.WriteLine("Finish");
            // });
            //Console.WriteLine("Before start:" + task1.Status);
            //task1.Start();
            //Console.WriteLine("After start:" + task1.Status);
            //task1.Wait();
            //Console.WriteLine("After Finish:" + task1.Status);

            //Console.ReadKey();

            #endregion

            #region Task等待所有任务结束
            //var task1 = new Task(() =>
            //{
            //    Console.WriteLine("Task 1 Begin");
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Task 1 Finish");
            //});

            //var task2 = new Task(() =>
            //{

            //    Console.WriteLine("Task 2 Begin");
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Task 2 Finish");
            //});
            //task1.Start();
            //task2.Start();
            ////等待所有执行完成
            //Task.WaitAll(task1, task2);
            //Console.WriteLine("WaitAll task finished!");
            ////等待任一任务完成
            ////Task.WaitAny(new Task[] { task1, task2 });
            ////Console.WriteLine("WaitAny task finished!");
            //Console.ReadLine();
            #endregion


            #region Task任务回调方法  
            //var task1 = new Task(() =>
            //{
            //    Console.Write("Task 1 Begin");
            //    Thread.Sleep(3000);
            //    Console.Write("Task 1 Finish");
            //});
            //var task2 = new Task(() =>
            //{
            //    Console.Write("Task 2 Begin");
            //    Thread.Sleep(3000);
            //    Console.Write("Task 2 Finish");
            //});
            //task1.Start();
            //task2.Start();


            //var result1 = task1.ContinueWith<string>(task =>
            //  {
            //      Console.WriteLine("task1 finished!");
            //      return GetContinueString("task1");
            //  });

            //Console.WriteLine("Task1结果：" + result1.Result.ToString());
            //var result2 = task2.ContinueWith<string>(task =>
            //{
            //    Console.WriteLine("task2 finished!");
            //    return GetContinueString("task2");
            //});

            //Console.WriteLine("Task2结果：" + result2.Result.ToString());
            //Console.ReadLine();
            #endregion


            #region Task取消任务
            //var tokenSource = new CancellationTokenSource();
            //var token = tokenSource.Token;
            //var task = Task.Factory.StartNew(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine("Working ..." + i.ToString());
            //        Thread.Sleep(500);
            //        if (token.IsCancellationRequested)
            //        {
            //            Console.WriteLine("Abort mission success!");
            //            return;
            //        }
            //    }
            //}, token);
            //token.Register(() =>
            //{
            //    Console.WriteLine("Canceled");
            //});
            //Console.WriteLine("Press enter to cancel task...");
            //Console.ReadKey();
            //tokenSource.Cancel();

            //Console.ReadKey();
            #endregion


            #region Task父子任务关联
            //var pTask = Task.Factory.StartNew(() =>
            //{
            //    var cTask = Task.Factory.StartNew(() =>
            //    {
            //        Thread.Sleep(2000);
            //        Console.WriteLine("Childen task finished!");
            //    }, TaskCreationOptions.AttachedToParent);
            //    Console.WriteLine("Parent task finished!");
            //});
            //pTask.Wait();
            //Console.WriteLine("Flag");
            //Console.ReadLine();
            #endregion

            #region 多级任务关联
            //Task.Factory.StartNew(() =>
            //{
            //    var t1 = Task.Factory.StartNew<int>(() =>
            //    {
            //        Console.WriteLine("Task 1 running...");
            //        Thread.Sleep(2000);
            //        return 1;
            //    });
            //    t1.Wait(); //等待任务一完成
            //    var t3 = Task.Factory.StartNew<int>(() =>
            //    {
            //        Console.WriteLine("Task 3 running...");
            //        Thread.Sleep(2000);
            //        return t1.Result + 3;
            //    });
            //    var t4 = Task.Factory.StartNew<int>(() =>
            //    {
            //        Console.WriteLine("Task 2 running...");
            //        Thread.Sleep(1000);
            //        return t1.Result + 2;
            //    }).ContinueWith<int>(task =>
            //    {
            //        Console.WriteLine("Task 4 running...");
            //        Thread.Sleep(1000);
            //        return task.Result + 4;
            //    });
            //    Task.WaitAll(t3, t4);  //等待任务三和任务四完成
            //    var result = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Task Finished! The result is {0}", t3.Result + t4.Result);
            //    });
            //});
            //Console.WriteLine("FINISH");
            //Console.ReadLine();
            #endregion

            #region 单例调用

            //Stopwatch watch = new Stopwatch();
            //watch.Start(); //  开始监视代码运行时间

            //for (int i = 0; i < 4; i++)
            //{


            //    //President p = new President();
            //    //p.Name = "Hello" + i.ToString() + "\n";
            //    //Console.Write(p.Name);

            //    //Singleton singletonExample = Singleton.GetSingleton();
            //    //singletonExample.Name = "飞飞飞飞"+i.ToString() + "\n";
            //    //Console.Write(singletonExample.Name);

            //    //President singletonExample = SingletonExample<President>.GetSingleton();
            //    //President.instance.Name = "HELLOWORLD飞飞飞飞" + i.ToString() + "\n";
            //    //President.instance.Country = "中国" + i.ToString() + "\n";
            //    //Console.Write(singletonExample.Name + singletonExample.Country);

            //    TestOpreation opreation = CommonModel.GetModel();


            //    string result = opreation.GetString("你好世界" + i.ToString());
            //    Console.WriteLine(result);


            //}
            //watch.Stop(); //  停止监视
            //TimeSpan timespan = watch.Elapsed; //  获取当前实例测量得出的总时间
            //Console.WriteLine("时间：" + timespan.TotalSeconds);
            #endregion

       
            Console.ReadLine();
        }

        public static string GetContinueString(string name)
        {
            return "MyName is " + name;
        }

        public static void Complete(IAsyncResult result)
        {
            UserInfo userInfoRes = null;
            AsyncResult asyncResult = (AsyncResult)result;

            //获取在其上调用异步调用的委托对象
            ParamDelegate myDelegate = (ParamDelegate)asyncResult.AsyncDelegate;

            //结束在其上调用的异步委托，并获取返回值
            userInfoRes = myDelegate.EndInvoke(result);

            Console.WriteLine("My name is " + userInfoRes.Name);
            Console.WriteLine("I'm " + userInfoRes.Age + " years old this year");
            Console.WriteLine("Thread ID is:" + userInfoRes.ThreadId);
        }


    }

    class DelegateParam
    {
        public string name { get; set; }
        public string age { get; set; }
    }

    class ThreadDemoClass
    {

        public void Run(object param)
        {

            string name = param as string;
            Console.WriteLine("Child Run thread working...");
            Console.WriteLine("My name is " + name);
            Console.WriteLine("Child thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        public void Run2(object param)
        {
            DelegateParam p = (DelegateParam)param;

            Console.WriteLine();
            Console.WriteLine("Child Run2 thread working...");
            Console.WriteLine("My name is " + p.name);
            Console.WriteLine("I'm " + p.age + " years old this year");
            Console.WriteLine("Child thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }

    class UserInfo
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public int ThreadId { get; set; }

    }
    class ThreadDemo2
    {
        public UserInfo Run(UserInfo userInfo)
        {
            userInfo.ThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Child thread working...");
            Console.WriteLine("Child thread ID is:" + userInfo.ThreadId);
            Console.WriteLine();
            return userInfo;
        }
    }
    class ThreadDemo
    {
        public void Run()
        {
            Console.WriteLine("Child thread working...");
            Console.WriteLine("Child thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
