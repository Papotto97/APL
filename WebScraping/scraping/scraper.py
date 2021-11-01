from bs4 import BeautifulSoup
import requests
from datetime import datetime
from time import sleep, time
from random import randint
import logging

#To ensure our requests are accepted and not termed as a bot.
headers = {'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36',
           'content-language': 'en-EN',
           'accept-language': 'en-EN'}
base_path = 'https://www.imdb.com'
class Movie:
    def __init__(self, imdb_id, title, rating, date, summary, runtime, genres):
        self.imdb_id = imdb_id
        self.title = title
        self.rating = rating
        self.date = date
        self.summary = summary
        self.runtime = runtime
        self.genres = genres
        self.timestamp = datetime.now()

def movie_scraper():
    movie_list = []
    # Downloading imdb top 1000 movie's data
    # Pages are sorted in groups of 50
    pages = [str(i + 1) for i in range(0, 1000) if i % 50 == 0]
    # Monitoring the loop
    start_time = time()
    count = 0
    for page in pages:
        # Make GET request
        url = '{}/search/title/?groups=top_1000&sort=user_rating,desc&start={}&ref_=adv_nxt'.format(base_path, page)
        print('Requesting: {} ...'.format(url))
        response = requests.get(url, headers = headers)
        count += 1
        elapsed_time = time() - start_time
        # Pause the loop for 2-5 seconds
        #sleep(randint(2,5))

        # Checking the response
        print('Parsing response...')
        #show a warning if a non 200 status code is returned
        if response.status_code != 200:
            logging.warning('Request: {}; Status code: {}'.format(requests, response.status_code))
    
        soup = BeautifulSoup(response.text, 'html.parser')
        
        rows = soup.find_all('div', class_ = 'lister-item mode-advanced')
        print('Found', len(rows), 'rows')
        for row in rows:
            imdb_id = row.find("div", class_='lister-item-image float-left').find('a', href=True).find("img", class_='loadlate')['data-tconst']
            print('imdb_id: {}'.format(imdb_id))
            
            title_tag = row.find('h3', class_='lister-item-header').find('a', href=True)
            title = title_tag.text
            print('title: {}'.format(title))
            
            rating = row.find('div', class_ = 'inline-block ratings-imdb-rating').find('strong').text
            print('rating: {}'.format(rating))
            
            date = row.find('h3', class_='lister-item-header').find('span', class_='lister-item-year text-muted unbold').text
            print('date: {}'.format(clean_year(date)))
                        
            summary = row.find('div', class_='lister-item-content').select('div > p')[1].text
            print('summary: {}'.format(clean_string(summary)))
            
            runtime_ = row.find('p', class_='text-muted').find('span', class_='runtime').text
            print('runtime: {}'.format(runtime_))
            
            genres_list = row.find('p', class_='text-muted').find('span', class_='genre').text
            genres = clean_genres(genres_list).split(",")
            print('genres: {}'.format(genres))
            
            movie = Movie(imdb_id, title, clean_string(rating), clean_year(date), clean_string(summary), runtime_, genres)   
            movie_list.append(movie)
            print('')
        
        '''
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
            print('Requesting: {} ...'.format(movie_url))
            movie_page = requests.get(movie_url, headers = headers)
            count += 1
            if movie_page.status_code != 200:
                logging.warning('Request: {}; Status code: {}'.format(requests, movie_page.status_code))
                break

            movie_soup = BeautifulSoup(movie_page.text, 'html.parser')

            imdb_id = movie_soup.find("meta", property="imdb:pageConst").attrs.get("content")
            print(imdb_id)
            # imdb_id = meta_tag["content"]        
            summary = movie_soup.find('span', class_='GenresAndPlot__TextContainerBreakpointXL-cum89p-2 gCtawA').text

            genres = []
            genres_div = movie_soup.find('div', class_='ipc-chip-list GenresAndPlot__GenresChipList-cum89p-4 gtBDBL')
            if genres_div:
                for genre in genres_div.find_all('a'):
                    genres.append(genre.text)
            
            movie = Movie(imdb_id, title, clean_string(rating), clean_year(date), summary, genres)   
            movie_list.append(movie)
            '''

    print("Total requests: {}; Elapsed time: {}s".format(count, round(elapsed_time, 2)))
    # Returning the dictionary for the defined attributes whit list comprehension
    return [movie.__dict__ for movie in movie_list]

def clean_genres(string):
    return string.replace("\n", "").replace(" ", "")

def clean_string(string):
    return string.replace("\n", "")

def clean_year(string):
    return string.replace("\n", "").replace("(", "").replace(")", "").replace(" ", "")

if __name__ == "__main__":
    movie_scraper()