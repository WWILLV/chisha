# -*- coding: UTF-8 -*-
__author__ = 'WILL_V'

import re
import json
import requests
from bs4 import BeautifulSoup

root = 'http://www.xiachufang.com'
headers = {
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.80 Safari/537.36',
    'Referer': root
}
data = list()


def getRecipes():
    recipes = list()
    count = 0
    for i in range(1, 10 + 1):
        url = 'http://www.xiachufang.com/explore/?page=%d' % i
        rsp = requests.get(url=url, headers=headers)
        for r in re.compile(r"/recipe/\d*/").findall(rsp.text):
            if count % 2 == 0:
                recipes.append(r)
            count += 1
        print("已获取%i个菜单" % (count / 2))

    return recipes


def getDetail(recipe):
    # 抓取详细信息
    url = root + recipe
    rsp = requests.get(url=url, headers=headers)
    soup = BeautifulSoup(rsp.text, 'lxml')
    row = dict()

    row['url'] = recipe

    # 获取标题
    row['title'] = soup.find('h1', class_='page-title').text.strip().replace('\n', '')
    print(row['title'], url)

    # 获取配方
    row['ins'] = dict()
    ings = soup.find('div', class_='ings').table
    for tr in ings.find_all('tr'):
        ings_name = tr.find('td', class_='name').text.strip().replace('\n', '')
        ings_unit = tr.find('td', class_='unit').text.strip().replace('\n', '')
        row['ins'][ings_name] = ings_unit

    # 获取烹饪步骤
    row['steps'] = list()
    steps = soup.find('div', class_='steps').ol
    for li in steps.find_all('li', class_='container'):
        step = dict()
        step['text'] = li.p.text
        if li.img is not None:
            step['img'] = li.img.get('src')
        else:
            step['img'] = ""
        row['steps'].append(step)

    data.append(row)


def main():
    for r in getRecipes():
        getDetail(r)

    # 写入文件
    with open('data.json', 'w', encoding='utf-8') as f:
        f.write(json.dumps(data, ensure_ascii=False))


if __name__ == '__main__':
    main()
