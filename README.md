## Chisha 吃啥

![ganfan](https://github.com/WWILLV/chisha/raw/master/ganfan.JPG)

简而言之，就是不知道吃啥，就写了一个软件。

先用Python爬取菜单（默认250个，爬太多会ban），然后用软件随机选取菜单并展示。

下载在release里。

### 注意

- 关闭服务器时由于连接未释放，不能再次立即开启服务器，可以重启软件解决该问题
- 需要提前进行软件设置
- 用了一下午写完的，长的丑了点，能用就行

### requirements.txt

bs4

requests

### screenshot

![](https://github.com/WWILLV/chisha/raw/master/screenshot/chisha.png)

![](https://github.com/WWILLV/chisha/raw/master/screenshot/recipe.png)

![](https://github.com/WWILLV/chisha/raw/master/screenshot/phone.png)