import csv

def movie_printer(data):
    header = ['title', 'userscore', 'metascore', 'date', 'summary', 'timestamp', '_id']
    with open('movies.csv', 'w', encoding='UTF8', newline='') as file:
        writer = csv.DictWriter(file, fieldnames=header)
        writer.writeheader()
        writer.writerows(data)
