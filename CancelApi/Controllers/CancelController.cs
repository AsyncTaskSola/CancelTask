using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


//---------------注意事项-----------------
//api/[controller]/[action] 这里只要写明白【httpGet】这些请求就行了
//api/[controller] 这里要写明[HttpGet("GetResult")] 只能在同等请求类型相互跳转
//---------------注意事项-----------------


namespace CancelApi.Controllers
{
    /// <summary>
    /// Cancel
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CancelController : ControllerBase
    {
        private static ILog log = LogManager.GetLogger(Startup.Repository.Name, "WeatherForecastController");
        private readonly ILogger<CancelController> _logger;
        RunTask t = new RunTask();
        static Entity entity = new Entity();

        public CancelController(ILogger<CancelController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// 0 不进行跳转控制器 
        /// 1 跳转到GetNumberSum 并自动运行
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("GetResult")]
        public ActionResult<object> GetResult(int number = 0)
        {
            try
            {
                //_logger.LogInformation("CancelController:GetResult");
                log.Info("程序入口");
                log.Info("CancelController:GetResult");
                if (number == 1)
                {
                    return RedirectToAction("GetNumberSum", "Cancel");
                    //return Redirect("/api/Cancel/NumberSum");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"{e}");
            }
            return "不进行跳转控制器";
        }

        /// <summary>
        /// 取当前数字
        /// </summary>
        /// <param name="lastnumber">上次择取数字</param>
        /// <param name="Cancel">默认为null,传入参数【取消】  “暂停择取当前数字”</param>
        /// <returns></returns>
        [HttpGet("NumberSum")]
        public ActionResult<object> GetNumberSum(int lastnumber = 0, string Cancel = null)
        {
            log.Info("CancelController:GetNumberSum");
            var result = t.Sum(lastnumber, Cancel);
            return result;
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <returns></returns>
        [HttpGet("DeleteLogFile")]
        public Task<ResultModel<string>> DeleteLogFile()
        {
            var result =Directory.GetCurrentDirectory() + $@"\logs\{DateTime.Now.ToString("yyyyMMdd")}.log";
            if (System.IO.File.Exists(result))
            {
                System.IO.File.Delete(result);
                //log.Info("路径存在，删除成功");
                return Task.Run(() =>  new ResultModel<string> {State = ResultType.Success, Message = "删除成功"});
            }

            return Task.Run(() => new ResultModel<string> {State = ResultType.Error, Message = "删除失败"});
        }

        public class RunTask
        {
            static RunTask instance = null;
            //private static readonly object padlock = new object();
            //private RunTask() { }

            public int Sum(int lastnumber, string Cancel)
            {
                try
                {
                    List<Task> List = new List<Task>();
                    if (lastnumber > 0)
                    {
                        entity.LastNumber = lastnumber;
                        instance = null;
                    }

                    if (instance == null)
                    {
                        CancellationTokenSource cancel = new CancellationTokenSource();
                        CancellationToken cts;
                        instance = new RunTask();
                        var o = new object();
                        var tag = entity.LastNumber;
                        var count = 0;
                        var max = int.MaxValue;

                        // var cancel = new CancellationTokenSource();
                        cts = cancel.Token; //取消令牌
                        entity.Cts = cts;
                        entity.Cancel = cancel;
                        //var List = new List<Task>();
                        for (int i = 0; i < 3; i++)
                        {
                            var t = Task.Run(() =>
                            {
                                var currentTag = 0; //值
                                while (tag < max)
                                {
                                    lock (o)
                                    {
                                        if (cts.IsCancellationRequested)
                                        {
                                            break;
                                        }
                                        /*(!token.IsCancellationRequested)*/

                                        // SpinWait.SpinUntil(() => Cancel == "取消");
                                        SpinWait.SpinUntil(() => false, 200); //延迟200ms
                                        tag += 1;
                                        currentTag = tag;
                                        // Thread.Sleep(300);
                                        entity.Sum = currentTag;
                                        log.Info($"当前值{currentTag}");
                                        //Console.WriteLine($"当前值{currentTag}");

                                    }
                                }
                            }, cts);
                            List.Add(t);
                        }
                        entity.List = List;

                        #region 之前写法

                        //object o = new object();
                        ////var tag = 0;
                        //var tag = entity.tag = 0;
                        //var count = 0;
                        //var max = int.MaxValue;
                        //try
                        //{
                        //    var cancel = new CancellationTokenSource();
                        //    var token = cancel.Token;

                        //    var List = new List<Task>();
                        //    for (int i = 0; i < 3; i++)
                        //    {
                        //        var t = Task.Run(() =>
                        //        {
                        //            var currentTag = 0;//值
                        //            while (tag < max)
                        //            {
                        //                lock (o)
                        //                {

                        //                    if (!token.IsCancellationRequested)
                        //                    {
                        //                        // SpinWait.SpinUntil(() => Cancel == "取消");
                        //                        SpinWait.SpinUntil(() => false, 100);
                        //                        tag += 1;
                        //                        currentTag = tag;
                        //                        // Thread.Sleep(300);
                        //                        Console.WriteLine($"当前值{currentTag}");
                        //                        entity.Sum = tag;
                        //                    }
                        //                }
                        //            }
                        //        }, token);
                        //        List.Add(t);
                        //    }


                        #endregion
                    }

                    if (Cancel == "取消")
                    {
                        entity.Cancel.Cancel();
                        var cl = entity.Cancel.IsCancellationRequested;
                        var result = entity.Cts.IsCancellationRequested;
                        entity.Cts.Register(() =>
                        {
                            //不返回了，直接实体赋值
                            log.Info($"Canceled 当前值为{entity.Sum}");
                            //Console.WriteLine($"Canceled 当前值为{entity.Sum}");
                        });
                        //System.Environment.Exit(0); 全部线程退出
                    }
                    //var result = Task.WhenAll(List).ConfigureAwait(true).GetAwaiter();
                    //var result = Task.WhenAll(List).GetAwaiter().GetResult();
                    Task.WaitAll(List.ToArray());
                    return entity.Sum;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //throw;
                }
                finally
                {
                    entity.Cancel.Dispose();
                }
                return entity.Sum;  //设置了200ms延迟 要想正常就去掉延迟就行了
            }
        }
    }
    public class Entity
    {
        public int Sum { get; set; }
        //public int Tag { get; set; }
        public int LastNumber { get; set; }
        public CancellationToken Cts { get; set; }
        public CancellationTokenSource Cancel { get; set; }
        public List<Task> List { get; set; }
    }

}
