movies <- read.csv("new_movies.csv",stringsAsFactors=FALSE)

library(recommenderlab)
library(ggplot2)
library(tidyverse)
library(scales)
library(data.table)
library(plumber) #develop API

## Data pre-processing
genres <- as.data.frame(movies$genres, stringsAsFactors=FALSE)
genres2 <- as.data.frame(tstrsplit(genres[,1], '[|]', type.convert=TRUE), stringsAsFactors=FALSE)
colnames(genres2) <- c(1:3)

genre_list <- c("Action",
                "Adventure",
                "Animation",
                "Biography",
                "Comedy",
                "Crime",
                "Documentary",
                "Drama",
                "Family",
                "Fantasy",
                "Film-Noir",
                "History",
                "Horror",
                "Music",
                "Musical",
                "Mystery",
                "Romance",
                "Sci-Fi",
                "Short",
                "Sport",
                "Superhero",
                "Thriller",
                "War",
                "Western") # we have 24 genres in total (https://www.imdb.com/feature/genre/)

genre_matrix <- matrix(0,1001,24) #empty matrix, 1000=no of movies+1, 18=no of genres
genre_matrix[1,] <- genre_list #set first row to genre list
colnames(genre_matrix) <- genre_list #set column names to genre list

#iterate through matrix
for (i in 1:nrow(genres2)) {
  for (c in 1:ncol(genres2)) {
    genmat_col = which(genre_matrix[1,] == genres2[i,c])
    genre_matrix[i+1,genmat_col] <- 1
  }
}

#convert into dataframe
genre_matrix2 <- as.data.frame(genre_matrix[-1,], stringsAsFactors=FALSE) #remove first row, which was the genre list
for (c in 1:ncol(genre_matrix2)) {
  genre_matrix2[,c] <- as.integer(genre_matrix2[,c])
} #convert from characters to integers

#Create a matrix to search for a movie by genre:
years <- as.data.frame(movies$date, stringsAsFactors=FALSE)
library(data.table)
substrRight <- function(x, n){
  substr(x, nchar(x)-n+1, nchar(x))
}

search_matrix <- cbind(movies[,2], movies[,3], years, genre_matrix2)
colnames(search_matrix) <- c("imdbId", "title", "year", genre_list)

write.csv(search_matrix, "search.csv")
search_matrix <- read.csv("search.csv", stringsAsFactors=FALSE)

# Example of search an Action movie produced in 1997:
subset(search_matrix, Action == 1 & year == 1997)$title

ourRatings <- as.data.frame(cbind(movies[,2], movies[,3], movies[,4], movies[,7], movies[,5]))
colnames(ourRatings) <- c("imdbId", "title", "rating", "runtime", "date")
ourRatings %>% head()


#Relationship between Movie Runtime and IMDb Movie Rating
plot <- ggplot(ourRatings, aes(x = as.numeric(runtime), y = as.numeric(rating))) +
  geom_bin2d() +
  scale_x_continuous(labels = comma) +
  scale_y_continuous(breaks = 0:10) +
  scale_fill_viridis_c(option = "inferno") +
  theme_dark(base_size = 6) +
  labs(title="Relationship between Movie Runtime and IMDb Movie Rating",
       x="Runtime (mins)",
       y="IMDb Rating",
       fill="# Movies")

ggsave("APL1.png", plot, width=4, height=3)


#Relationship between Movie Release Year and IMDb Movie Rating
  plot <- ggplot(ourRatings, aes(x = as.numeric(date), y = as.numeric(rating))) +
  geom_bin2d() +
  #geom_smooth(color="black") +
  scale_x_continuous() +
  scale_y_continuous(breaks = 0:10) +
  scale_fill_viridis_c(option = "inferno") +
  theme_dark(base_size = 6) +
  labs(title="Relationship between Movie Release Year and IMDb Movie Rating",
       x="Year Movie was Released",
       y="IMDb Movie Rating",
       fill="# Movies")

ggsave("..\FE\APL_FE\Resources\R\APL2.png", plot, width=4, height=3)