package main

import (
	"log"
	"net/http"
	"unictapl/models"
	"unictapl/services"
	"unictapl/utils"

	"github.com/gin-gonic/gin"
)

func handleGetMovie(c *gin.Context) {
	movieId := c.Param("movieId")
	if len(movieId) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "movieId not populated"})
		return
	}

	movie := services.FindMovieById(movieId)
	if utils.IsMovieEmpty(movie) {
		c.JSON(http.StatusNotFound, gin.H{"msg": "Movie not found"})
		return
	}
	c.JSON(http.StatusOK, gin.H{"movie": movie})

}
func handleGetUserByUsername(c *gin.Context) {
	username := c.Param("username")
	if len(username) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "username not populated"})
		return
	}

	user := services.FindUserByUsername(username)
	if (models.User{}) == user {
		c.JSON(http.StatusNotFound, gin.H{"msg": "User not found"})
		return
	}
	c.JSON(http.StatusOK, gin.H{"user": user})

}
func handleGetUserByEmail(c *gin.Context) {
	email := c.Param("email")
	if len(email) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "email not populated"})
		return
	}

	user := services.FindUserByEmail(email)
	if (models.User{}) == user {
		c.JSON(http.StatusNotFound, gin.H{"msg": "User not found"})
		return
	}
	c.JSON(http.StatusOK, gin.H{"user": user})

}

func handleGetAllMovies(c *gin.Context) {

	movies := services.FindAllMovies()
	c.JSON(http.StatusOK, gin.H{"movies": movies})

}
func handleGetAllUsers(c *gin.Context) {

	users := services.FindAllUsers()
	c.JSON(http.StatusOK, gin.H{"users": users})

}

func handleCreateMovie(c *gin.Context) {
	log.Printf("Start creating ")

	var movie models.Movie
	if err := c.ShouldBindJSON(&movie); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	id, err := services.CreateMovie(&movie)
	if len(err) == 0 {
		c.JSON(http.StatusInternalServerError, gin.H{"msg": err})
		return
	}
	c.JSON(http.StatusOK, gin.H{"id": id, "msg": err})

}
func handleCreateUser(c *gin.Context) {
	log.Printf("Start creating user ")

	var user models.User
	if err := c.ShouldBindJSON(&user); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	id, err := services.CreateUser(&user)
	if len(err) == 0 {
		c.JSON(http.StatusInternalServerError, gin.H{"msg": err})
		return
	}
	c.JSON(http.StatusOK, gin.H{"id": id, "msg": err})

}

func handleAddFavourites(c *gin.Context) {
	log.Printf("Start creating user ")

	var favourite models.Favourites
	if err := c.ShouldBindJSON(&favourite); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	string := services.AddFavourite(&favourite)
	//if len(err) == 0 {
	//	c.JSON(http.StatusInternalServerError, gin.H{"msg": err})
	//	return
	//}
	c.JSON(http.StatusOK, gin.H{"msg": string})

}
func handleInsertSearch(c *gin.Context) {
	var search models.Searches
	if err := c.ShouldBindJSON(&search); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	string := services.InsertNewSearch(&search)

	c.JSON(http.StatusOK, gin.H{"msg": string})

}
func handleAddGetAllFavouritesByUser(c *gin.Context) {
	username := c.Query("username")
	if len(username) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "username not populated"})
		return
	}

	favourites := services.FindAllFavouritesByUsername(username)

	if len(favourites) == 0 {
		c.JSON(http.StatusNotFound, gin.H{"msg": "Favourites not found"})
		return
	}
	c.JSON(http.StatusOK, gin.H{"favourites": favourites})

}

func main() {
	r := gin.Default()

	//movies routes
	r.PUT("/movie/", handleCreateMovie)
	r.GET("/movies/:movieId", handleGetMovie)
	r.GET("/movies/all", handleGetAllMovies)
	//users routes
	r.PUT("/user/", handleCreateUser)
	r.GET("/users/username/:username", handleGetUserByUsername)
	r.GET("/users/email/:email", handleGetUserByEmail)
	r.GET("/users/all", handleGetAllUsers)
	//favourites routes
	r.PUT("/favourites/", handleAddFavourites)
	r.GET("/favourites/", handleAddGetAllFavouritesByUser)
	//searches routes
	r.PUT("/search/", handleInsertSearch)

	r.Run("localhost:8081")
}
