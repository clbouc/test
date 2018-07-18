

ASC 文件 读
CSV 文件 读
Model 文件夹 空中国王的数据

Procedure 创建数据库，数据入库

## Server
1 数据查询//part
2 进度显示 //ok
3 异常处理 //part
4 数据库类事务, 数据库连接 要用 配置文件 //ok
5 日志 //log4net part ok, 配置文件 在 log4net.config
6 合并 // part ok,不知道具体如何处理，所以简单合并并加简单的重命名策略


## 创建kingdata
步骤
1 解析asc 文件,并支持 formula 字段对应fml.300文件
生成格式较好的 csv文件
2 利用csv文件来配置生成表的字段
```
fieldname	datatype filename
```
重命名策略是 fieldname_filename_i，并生成reaname.last文件

3 利用重命名策略+csv文件，并指定数据表名即可创建

不足 
1 希望全自动，或者实现formula字段的解析，以及字段别名，以及注释

## 批量导入
步骤
1 通过预先写好entity类，字段名是对应相应数据库字段名，就像ORM框架那样
2 读取文件夹里的csv文件，（文件名已hardcode）,文件夹要有日期，否则有些csv文件的sceondsMidnight字段无法处理
3 将读取的csv建立List<ModelCommon> 实例，每个文件一个
4 然后进行按时间的合并
5 用反射将数据库的Insert 语句生成，并批量插入（需提供 插入的表，默认是一次500行）

不足
1 数据库的表，主键必须自动生成，或者说主键不填也能插入
2 数据表的字段必须严格和entity里的字段一致
3 暂时没有UI
## 网页
