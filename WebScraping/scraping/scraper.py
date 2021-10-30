from bs4 import BeautifulSoup
import requests
from datetime import datetime
from time import sleep, time
from random import randint
import logging

#To ensure our requests are accepted and not termed as a bot.
headers = {'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36'}
base_path = 'https://www.imdb.com'
class Movie:
    def __init__(self, title, rating, date, summary, genres):
        self.title = title
        self.rating = rating
        self.date = date
        self.summary = summary
        self.genres = genres
        self.timestamp = datetime.now()

def movie_scraper():
    movie_list = []
    # Downloading imdb top 500 movie's data
    # Pages are sorted in groups of 50
    pages = [str(i + 1) for i in range(0, 500) if i % 50 == 0]
    # Monitoring the loop
    start_time = time()
    count = 0
    for page in pages:
        # Make GET request
        url = '{}/search/title/?groups=top_1000&view=simple&sort=user_rating,desc&start={}&ref_=adv_nxt'.format(base_path, page)
        print('Requesting ', url)
        response = requests.get(url, headers = headers)
        count += 1
        elapsed_time = time() - start_time
        # Pause the loop for 2-5 seconds
        sleep(randint(2,5))

        # Checking the response
        print('Parsing response...')
        #show a warning if a non 200 status code is returned
        if response.status_code != 200:
            logging.warning('Request: {}; Status code: {}'.format(requests, response.status_code))
    

        soup = BeautifulSoup(response.text, 'html.parser')
        rows = soup.find_all('div', class_ = 'lister-item mode-simple')
        print('Found', len(rows), 'rows')
        for row in rows:
            title_tag = row.find('span', class_='lister-item-header').find('a', href=True)
            title = title_tag.text
            rating = row.find('div', class_ = 'col-imdb-rating').find('strong').text
            date = row.find('span', class_='lister-item-header').find('span', class_='lister-item-year text-muted unbold').text
            # For each movie in the list we need to open the page for collecting more details
            link = title_tag['href']
            movie_url = base_path + link
            movie_page = requests.get(movie_url, headers = headers)
            count += 1
            if movie_page.status_code != 200:
                logging.warning('Request: {}; Status code: {}'.format(requests, movie_page.status_code))
                break

            movie_soup = BeautifulSoup(movie_page.text, 'html.parser')
            summary = movie_soup.find('span', class_='GenresAndPlot__TextContainerBreakpointXL-cum89p-2 gCtawA').text
            genres = []
            genres_div = movie_soup.find('div', class_='ipc-chip-list GenresAndPlot__GenresChipList-cum89p-4 gtBDBL')
            if genres_div:
                for genre in genres_div.find_all('a'):
                    genres.append(genre.text)
            
            movie = Movie(title, clean_string(rating), date, summary, genres)   
            movie_list.append(movie)

    print("Total requests: {}; Elapsed time: {}s".format(count, round(elapsed_time, 2)))
    # Returning the dictionary for the defined attributes whit list comprehension
    return [movie.__dict__ for movie in movie_list]

def clean_string(string):
    return string.replace("\n", "").replace(" ", "")

if __name__ == "__main__":
    movie_scraper()