import os
from dotenv import load_dotenv
from scraping.scraper import movie_scraper

def main():
    load_dotenv()
    print("Top 500 Metacritic Movie Scraper v",  os.environ.get("VERSION"))
    movies = movie_scraper()
    print("Scraped movies:", len(movies))
    # client = MongoDBClient()
    # client.insertMany(movie_list)

if __name__ == "__main__":
    main()
