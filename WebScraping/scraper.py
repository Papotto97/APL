import logging
from bs4 import BeautifulSoup
import requests
import re

#To ensure our requests are accepted and not termed as a bot.
headers = {'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36'}

# Downloading metacrtic top 500 movie's data
page = 0
url = 'https://www.metacritic.com/browse/movies/score/userscore/all/filtered?page=' + str(page)
print('Requesting ', url)
response = requests.get(url, headers = headers)
print('Parsing response...')
soup = BeautifulSoup(response.text, 'html.parser')
rows = soup.find_all('td', class_ = 'clamp-summary-wrap')
print('Found', len(rows), 'rows')
for row in rows:
    print('Title: ', row.find('h3').text)
    print('User Score: ', row.find('div', class_ = 'metascore_w user large movie positive').text)
    print('Meta Score: ', row.find('div', class_ = 'clamp-metascore').find('a').find('div').text)
    print('Date: ', row.find('div', class_ = 'clamp-details').find('span').text)
    row.find('div', class_ = 'summary')
