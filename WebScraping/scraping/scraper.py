from bs4 import BeautifulSoup
import requests
from datetime import datetime
from time import sleep, time
from random import randint
import logging

#To ensure our requests are accepted and not termed as a bot.
headers = {'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36'}

class Movie:
    def __init__(self, title, userscore, metascore, date, summary):
        self.title = title
        self.userscore = userscore
        self.metascore = metascore
        self.date = date
        self.summary = summary
        self.timestamp = datetime.now()

def movie_scraper():
    movie_list = []
    # Downloading metacrtic top 500 movie's data
    pages = [str(i) for i in range(0, 5)]
    # Monitoring the loop
    start_time = time()
    count = 0
    for page in pages:
        # Make GET request
        url = 'https://www.metacritic.com/browse/movies/score/userscore/all/filtered?page=' + str(page)
        print('Requesting ', url)
        response = requests.get(url, headers = headers)
        count += 1
        # Pause the loop for 2-5 seconds
        sleep(randint(2,5))

        # Checking the response
        print('Parsing response...')
        #show a warning if a non 200 status code is returned
        if response.status_code != 200:
            logging.warning('Request: {}; Status code: {}'.format(requests, response.status_code))
    

        soup = BeautifulSoup(response.text, 'html.parser')
        rows = soup.find_all('td', class_ = 'clamp-summary-wrap')
        print('Found', len(rows), 'rows')
        for row in rows:
            title = row.find('h3').text
            userscore = row.find('div', class_ = 'metascore_w user large movie positive').text
            metascore = row.find('div', class_ = 'clamp-metascore').find('a').find('div').text
            date = row.find('div', class_ = 'clamp-details').find('span').text
            summary = row.find('div', class_ = 'summary').text
            movie = Movie(title, userscore, metascore, date, summary)
            # Returning the dictionary for the defined attributes
            movie_list.append(movie.__dict__)
    return movie_list

