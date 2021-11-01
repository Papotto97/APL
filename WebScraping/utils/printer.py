import csv

def movie_printer(data):
    header = ['_id', 'imdb_id', 'title', 'rating', 'date', 'summary', 'runtime', 'genres', 'timestamp']
    with open('new_movies.csv', 'w', encoding='UTF8', newline='') as file:
        writer = csv.DictWriter(file, fieldnames=header)
        writer.writeheader()
        writer.writerows(data)
        
