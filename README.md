# CancelApi
### 多线程择取数据
[![GitHub issues](https://img.shields.io/github/issues/AsyncTaskSola/CancelTask)](https://github.com/AsyncTaskSola/CancelTask/issues)
[![GitHub forks](https://img.shields.io/github/forks/AsyncTaskSola/CancelTask)](https://github.com/AsyncTaskSola/CancelTask/network)
[![GitHub stars](https://img.shields.io/github/stars/AsyncTaskSola/CancelTask)](https://github.com/AsyncTaskSola/CancelTask/stargazers)
[![GitHub license](https://img.shields.io/github/license/AsyncTaskSola/CancelTask)](https://github.com/AsyncTaskSola/CancelTask)    	
[![Twitter](https://img.shields.io/twitter/url?style=social)](https://twitter.com/intent/tweet?text=Wow:&url=https%3A%2F%2Fgithub.com%2FAsyncTaskSola%2FCancelTask)
### 为什么要有这个项目：吐槽 现在网上能搜到的都是 多线程用在winfrom,wpf的列子太多了，加上很多形成了默认的内部委托，事件调用，很少有详细的列子写到控制台，并用上最新的技术点。有没有一个新技术点的集合，看起来很死板 该项目只是一个简单的技术点结合，为新视频下载开源做铺垫

----------
----------

## 特点
* 采用.ntf4.0的task语法糖写法，比起网上很多找到的thread写法简便
* 采用swagger来配置 Swagger 可以贯穿于整个 API 生态，如 API 的设计、编写 API 文档、测试和部署。（小型项目不实现REST/RESTful风格）若要实现请
  转到最新视频下载开源
* 采用线程的数据择取，恢复继续进行。若你还不懂线程请另转教程
* 本次主要采用CancellationTokenSource 根据Token值来控制线程问题
* 使用单例模式，lock锁定线程
* 使用log4日志记录
* 添加docker部署

## 一、安装
* 你在此之前必须具备.netcore 3.1，git,docker环境
* Nuget: Swashbuckle.AspNetCore ,log4netcore
* docker你可以使用pc win10专业版Hyper-V,linux版 
* docker 镜像地址 https://hub.docker.com/r/hexsola/cancelapiswagger  默认发布为Linux64
* 拉取docker镜像 docker pull hexsola/cancelapiswagger

## 二、注意
* dockerfile 路径必须放到和sln的一个目录下面
* dockerfile vs自动生成的时候默认是release路径，这里用到swagger的小伙伴们需要把配置设置和debug的一样，不然生成镜像的时候带不上.xml文件
* 程序端口默认是5000，docker启动的时候必须端口映射到5000
* docker 命令参考 https://docs.docker.com/get-started/

## 三、使用
* 程序
  * GetResult   0 不进行跳转控制器 ， 1 跳转到GetNumberSum 并自动运行 并0时候自动跳转到下一操作并自动计时开始
    * GetNumberSum 输入参数 取消 可以截取当前数据
      * DeleteLogFile 删除日志而用

* Docker
 若用到docker的命令参考
```
[
docker run --name cancelapiswagger -d -p 8080:5000 hexsola/cancelapiswagger 运行镜像
docker exec -it 容器名 /bin/sh 查看发布的镜像文件
docker logs 容器名 -f 查看启动日志
]
```
* 程序启动成功
 
## 四.联系方式
* 作者：删库跑路
* 最近新项目：https://github.com/AsyncTaskSola/HaoKanVideoDownLoad
* Wechat：Atlantis314 欢迎提wiki  
