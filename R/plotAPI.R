#
# This is a Plumber API. You can run the API by clicking
# the 'Run API' button above.
#
# Find out more about building APIs with Plumber here:
#
#    https://www.rplumber.io/
#

library(plumber)
library(data.table) #Extension of data.frame
library(ggplot2) #Create plots
library(scales) #Scales for visualization

#* @apiTitle APL API
#* @apiDescription Get plots 👌.

#* Returns a plot of 'Relationship between Movie Runtime and IMDb Movie Rating'
#* @get /plot_apl1
#* @serializer contentType list(type='image/png')
function() {
  plotTitle <- 'APL1.png'
  movies <- read.csv("new_movies.csv",stringsAsFactors=FALSE)
  
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
  
  ggsave(plotTitle, plot, width=4, height=3)
  
  readBin(plotTitle, "raw", n = file.info(plotTitle)$size)
}


#* Returns a plot of 'Relationship between Movie Release Year and IMDb Movie Rating'
#* @get /plot_apl2
#* @serializer contentType list(type='image/png')
function() {
  plotTitle <- 'APL2.png'
  movies <- read.csv("new_movies.csv",stringsAsFactors=FALSE)
  
  ourRatings <- as.data.frame(cbind(movies[,2], movies[,3], movies[,4], movies[,7], movies[,5]))
  colnames(ourRatings) <- c("imdbId", "title", "rating", "runtime", "date")
  ourRatings %>% head()
  
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
  
  ggsave(plotTitle, plot, width=4, height=3)
  
  readBin(plotTitle, "raw", n = file.info(plotTitle)$size)
}