# CancelApi
### ���߳���ȡ����
[![GitHub issues](https://img.shields.io/github/issues/AsyncTaskSola/CancelTask)](https://github.com/AsyncTaskSola/CancelTask/issues)
[![GitHub forks](https://img.shields.io/github/forks/AsyncTaskSola/CancelTask)](https://github.com/AsyncTaskSola/CancelTask/network)
[![GitHub stars](https://img.shields.io/github/stars/AsyncTaskSola/CancelTask)](https://github.com/AsyncTaskSola/CancelTask/stargazers)
[![GitHub license](https://img.shields.io/github/license/AsyncTaskSola/CancelTask)](https://github.com/AsyncTaskSola/CancelTask)    	
[![Twitter](https://img.shields.io/twitter/url?style=social)](https://twitter.com/intent/tweet?text=Wow:&url=https%3A%2F%2Fgithub.com%2FAsyncTaskSola%2FCancelTask)
### ΪʲôҪ�������Ŀ���²� �����������ѵ��Ķ��� ���߳�����winfrom,wpf������̫���ˣ����Ϻܶ��γ���Ĭ�ϵ��ڲ�ί�У��¼����ã���������ϸ������д������̨�����������µļ����㡣��û��һ���¼�����ļ��ϣ�������������

----------
----------

## �ص�
* ����.ntf4.0��task�﷨��д�����������Ϻܶ��ҵ���threadд�����
* ����swagger������ Swagger ���Թᴩ������ API ��̬���� API ����ơ���д API �ĵ������ԺͲ��𡣣�С����Ŀ��ʵ��REST/RESTful�����Ҫʵ����
  ת��������Ƶ���ؿ�Դ
* �����̵߳�������ȡ���ָ��������С����㻹�����߳�����ת�̳�
* ������Ҫ����CancellationTokenSource ����Tokenֵ�������߳�����
* ʹ�õ���ģʽ��lock�����߳�
* ʹ��log4��־��¼
* ���docker����

## һ����װ
* ���ڴ�֮ǰ����߱�.netcore 3.1��git,docker����
* Nuget: Swashbuckle.AspNetCore ,log4netcore
* docker�����ʹ��pc win10רҵ��Hyper-V,linux�� 
* docker �����ַ https://hub.docker.com/r/hexsola/cancelapiswagger  Ĭ�Ϸ���ΪLinux64
* ��ȡdocker���� docker pull hexsola/cancelapiswagger

## ����ע��
* dockerfile ·������ŵ���sln��һ��Ŀ¼����
* dockerfile vs�Զ����ɵ�ʱ��Ĭ����release·���������õ�swagger��С�������Ҫ���������ú�debug��һ������Ȼ���ɾ����ʱ�������.xml�ļ�
* ����˿�Ĭ����5000��docker������ʱ�����˿�ӳ�䵽5000
* docker ����ο� https://docs.docker.com/get-started/

## ����ʹ��
* ����
  * GetResult   0 ��������ת������ �� 1 ��ת��GetNumberSum ���Զ����� ��0ʱ���Զ���ת����һ�������Զ���ʱ��ʼ
    * GetNumberSum ������� ȡ�� ���Խ�ȡ��ǰ����
      * DeleteLogFile ɾ����־����

* Docker
 ���õ�docker������ο�
```
[
docker run --name cancelapiswagger -d -p 8080:5000 hexsola/cancelapiswagger ���о���
docker exec -it ������ /bin/sh �鿴�����ľ����ļ�
docker logs ������ -f �鿴������־
]
```
* ���������ɹ�
 
## ��.��ϵ��ʽ
* ���ߣ�ɾ����·
* �������Ŀ��https://github.com/AsyncTaskSola/HaoKanVideoDownLoad
* Wechat��Atlantis314 ��ӭ��wiki  